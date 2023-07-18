using System.Text.Json;
using HM5.Server.Controllers.Hitman;
using HM5.Server.Interfaces;
using HM5.Server.Models;

namespace HM5.Server.Services
{
    public class LocalHitmanServer : IHitmanServer
    {
        class UserProfile
        {
            public class PlayedContract
            {
                public int Plays { get; set; }
                public int Score { get; set; }
            }

            public string UserId { get; set; }
            public string DisplayName { get; set; }
            public int TotalEarnings { get; set; }
            public int WalletAmount { get; set; }
            public int ContractsCreated { get; set; }
            public Dictionary<string, PlayedContract> PlayedContracts { get; set; }
            public HashSet<string> ContractQueue { get; set; }
            public HashSet<string> Friends { get; set; }

            public UserProfile()
            {
                PlayedContracts = new Dictionary<string, PlayedContract>();
                ContractQueue = new HashSet<string>();
                Friends = new HashSet<string>();
            }
        }

        private const string USERPROFILE_PATH = "userprofile.json";

        private static readonly List<int> _mockedGetAverageScoresResponse = new()
        {
            0, //World Average
            0, //Country Average
            0, //Friends Average
            0 //Score: Deadliest / Richest / Most Popular Assassin
        };

        private static readonly List<ScoreEntry> _mockedGetScoresResponse = new();

        private static readonly object _profileLock = new();

        private readonly ISimpleLogger _logger;
        private readonly IContractsService _contractsService;

        private UserProfile _userProfile;

        public LocalHitmanServer(ISimpleLogger logger, IContractsService contractsService)
        {
            _logger = logger;
            _contractsService = contractsService;
        }

        public void Initialize()
        {
            Directory.CreateDirectory("Contracts");

            _contractsService.RebuildCache();

            _userProfile = LoadUserProfile();
        }

        public int ExecuteWalletTransaction(HitmanController.ExecuteWalletTransactionRequest request)
        {
            SaveUserProfile(() =>
            {
                //NOTE: This would allow wallet amount to go negative if the game doesn't do the proper validations.
                _userProfile.WalletAmount -= request.Amount;
            });

            return _userProfile.WalletAmount;
        }

        public List<int> GetAverageScores(HitmanController.BaseGetAverageScoresRequest request)
        {
            return _mockedGetAverageScoresResponse;
        }

        public List<ScoreEntry> GetScores(HitmanController.BaseGetScoresRequest request)
        {
            return _mockedGetScoresResponse;
        }

        public List<Message> GetMessages(HitmanController.GetMessagesRequest request)
        {
            return new List<Message>();
        }

        public Contract GetFeaturedContract(HitmanController.GetFeaturedContractRequest request)
        {
            var contract = _contractsService
                .GetContracts(new HitmanController.SearchForContracts2Request
                {
                    LevelIndex = request.LevelIndex,
                    StartIndex = 0,
                    Range = 1
                }, contract => !_userProfile.PlayedContracts.ContainsKey(contract.Id))
                .FirstOrDefault();

            return contract;
        }

        public int GetNewMessageCount(HitmanController.GetNewMessageCountRequest request)
        {
            return 0;
        }

        public GetUserOverviewData GetUserOverviewData(HitmanController.GetUserOverviewDataRequest request)
        {
            return new GetUserOverviewData
            {
                WalletAmount = _userProfile.TotalEarnings,
                ContractPlays = _userProfile.PlayedContracts.Sum(x => x.Value.Plays),
                ContractsCreated = _userProfile.ContractsCreated
            };
        }

        public int GetUserWallet(HitmanController.GetUserWalletRequest request)
        {
            return _userProfile.WalletAmount;
        }

        public void MarkContractAsPlayed(HitmanController.MarkContractAsPlayedRequest request)
        {
            SaveUserProfile(() =>
            {
                if (!_userProfile.PlayedContracts.TryGetValue(request.ContractId, out var playedContract))
                {
                    playedContract = new UserProfile.PlayedContract();

                    _userProfile.PlayedContracts[request.ContractId] = playedContract;
                }

                playedContract.Plays++;
            });
        }

        public int PutScore(HitmanController.PutScoreRequest request)
        {
            var difference = 0;

            SaveUserProfile(() =>
            {
                if (!_userProfile.PlayedContracts.TryGetValue(request.LeaderboardId, out var playedContract))
                {
                    playedContract = new UserProfile.PlayedContract();

                    _userProfile.PlayedContracts[request.LeaderboardId] = playedContract;
                }

                difference = request.Score - playedContract.Score;

                if (difference > 0)
                {
                    _userProfile.TotalEarnings += difference;
                    _userProfile.WalletAmount += difference;
                }

                _userProfile.PlayedContracts[request.LeaderboardId].Score = Math.Max(request.Score, playedContract.Score);
            });

            return difference;
        }

        public void QueueAddContract(HitmanController.QueueAddContractRequest request)
        {
            SaveUserProfile(() =>
            {
                _userProfile.ContractQueue.Add(request.ContractId);
            });
        }

        public void QueueRemoveContract(HitmanController.QueueRemoveContractRequest request)
        {
            SaveUserProfile(() =>
            {
                _userProfile.ContractQueue.Remove(request.ContractId);
            });
        }

        public List<Contract> SearchForContracts2(HitmanController.SearchForContracts2Request request)
        {
            var contracts = _contractsService
                .GetContracts(request, contract =>
                {
                    return request.View switch
                    {
                        0 => true,
                        10 => _userProfile.ContractQueue.Contains(contract.Id),
                        20 => _userProfile.PlayedContracts.ContainsKey(contract.Id),
                        50 => _userProfile.UserId == contract.UserId,
                        60 => true, //NOTE: For convenience in the UI, should actually be false.
                        70 => _userProfile.Friends.Contains(contract.UserId),
                        _ => false
                    };
                })
                .ToList();

            contracts.ForEach(x =>
            {
                if (!_userProfile.PlayedContracts.TryGetValue(x.Id, out var playedContract))
                {
                    return;
                }

                x.UserScore = playedContract.Score;
                x.Plays = playedContract.Plays;
            });

            return contracts;
        }

        public void UpdateUserInfo(HitmanController.UpdateUserInfoRequest request)
        {
            SaveUserProfile(() =>
            {
                _userProfile.UserId = request.UserId;
                _userProfile.DisplayName = request.DisplayName;

                request.Friends.ForEach(x => _userProfile.Friends.Add(x));
            });
        }

        public void UploadContract(HitmanController.UploadContractRequest request)
        {
            _contractsService.CreateContract(request);

            SaveUserProfile(() =>
            {
                _userProfile.ContractsCreated++;
            });
        }

        private UserProfile LoadUserProfile()
        {
            lock (_profileLock)
            {
                try
                {
                    if (File.Exists(USERPROFILE_PATH))
                    {
                        return JsonSerializer.Deserialize<UserProfile>(
                            File.ReadAllText(USERPROFILE_PATH)
                        );
                    }
                }
                catch
                {
                    if (File.Exists(USERPROFILE_PATH))
                    {
                        File.Move(
                            USERPROFILE_PATH,
                            $"{USERPROFILE_PATH}-{DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}"
                        );
                    }

                    _logger.WriteLine("Failed to load user profile! Backing up original and creating new one instead.");
                }

                return new UserProfile();
            }
        }

        private void SaveUserProfile(Action scope)
        {
            lock (_profileLock)
            {
                scope();

                File.WriteAllText(USERPROFILE_PATH, JsonSerializer.Serialize(_userProfile));
            }
        }
    }
}
