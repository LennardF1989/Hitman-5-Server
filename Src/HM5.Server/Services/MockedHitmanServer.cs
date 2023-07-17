using HM5.Server.Controllers.Hitman;
using HM5.Server.Enums;
using HM5.Server.Interfaces;
using HM5.Server.Models;

namespace HM5.Server.Services
{
    public class MockedHitmanServer : IHitmanServer
    {
        //NOTE: Rating seems unused in UI?
        private static readonly List<ScoreEntry> _mockedGetScoresResponse = new()
        {
            new ScoreEntry
            {
                UserId = "LennardF1989",
                Rank = 1,
                Rating = 5,
                Score = 1989
            },
            new ScoreEntry
            {
                UserId = "RDIL",
                Rank = 2,
                Rating = 5,
                Score = 1989
            },
            new ScoreEntry
            {
                UserId = "AnthonyFuller",
                Rank = 3,
                Rating = 5,
                Score = 1989
            },
            new ScoreEntry
            {
                //NOTE: SteamID
                UserId = "76561198161220058",
                Rank = 4,
                Rating = 5,
                Score = 1989
            },
            new ScoreEntry
            {
                //NOTE: CountryID
                UserId = "73",
                Rank = 5,
                Rating = 5,
                Score = 1989
            }
        };

        private static readonly List<int> _mockedGetAverageScoresResponse = new()
        {
            1, //World Average
            2, //Country Average
            3, //Friends Average
            4 //Score: Deadliest / Richest / Most Popular Assassin
        };

        private static readonly Contract _mockedContractWithoutCompetition = new()
        {
            Id = "1",
            DisplayId = "FakeContract47",
            UserId = "76561198161220058",
            UserName = "Wingz of Death",
            Title = "Kill Diana",
            Description = "Lol, joke.",
            HighestScoringFriendName = "76561198161220058",
            HighestScoringFriendScore = 101,
            Targets = new TargetsWrapper
            {
                Targets = new List<Target>
                {
                    new()
                    {
                        Name = "David Thorhauge",
                        AmmoType = 0,
                        OutfitToken = -947477428,
                        SpecialSituation = 0,
                        WeaponToken = 1575676105
                    },
                    new()
                    {
                        Name = "Francois Munguia",
                        AmmoType = 0,
                        OutfitToken = -947477428,
                        SpecialSituation = 0,
                        WeaponToken = 0
                    }
                }
            },
            Restrictions = new RestrictionsWrapper
            {
                Restrictions = new List<ERestrictionType>
                {
                    ERestrictionType.NoWitnesses,
                    ERestrictionType.PerfectShooter
                }
            },
            ExitId = 2,
            Difficulty = 2,
            LevelIndex = 0,
            CheckpointIndex = 40,
            Dislikes = 0,
            Likes = 0,
            Plays = 0,
            StartingOutfitToken = -947477428,
            StartingWeaponToken = 1575676105,
            UserScore = 241953
        };

        private static readonly Contract _mockedContractWithCompetition = new()
        {
            Id = "2",
            DisplayId = "FakeContract48",
            UserId = "76561198161220058",
            UserName = "Wingz of Death",
            Title = "Kill Diana",
            Description = "Lol, joke.",
            CompetitionLeader = "76561198161220058",
            CompetitionHighestScore = 101,
            HighestScoringFriendName = "76561198161220058",
            HighestScoringFriendScore = 101,
            Targets = new TargetsWrapper
            {
                Targets = new List<Target>
                {
                    new()
                    {
                        Name = "David Thorhauge",
                        AmmoType = 0,
                        OutfitToken = -947477428,
                        SpecialSituation = 0,
                        WeaponToken = 1575676105
                    },
                    new()
                    {
                        Name = "Francois Munguia",
                        AmmoType = 0,
                        OutfitToken = -947477428,
                        SpecialSituation = 0,
                        WeaponToken = 0
                    }
                }
            },
            Restrictions = new RestrictionsWrapper
            {
                Restrictions = new List<ERestrictionType>
                {
                    ERestrictionType.NoWitnesses,
                    ERestrictionType.PerfectShooter
                }
            },
            Competition = new CompetitionWrapper
            {
                Competition = new List<Competition>
                {
                    new()
                    {
                        Id = 1,
                        AllowInvites = true,
                        DaysRemaining = 3,
                        CompetitionCreator = "76561198161220058",
                        EndTimeUTC = DateTime.UtcNow.AddDays(3)
                    }
                }
            },
            ExitId = 2,
            Difficulty = 2,
            LevelIndex = 0,
            CheckpointIndex = 40,
            Dislikes = 0,
            Likes = 0,
            Plays = 0,
            StartingOutfitToken = -947477428,
            StartingWeaponToken = 1575676105,
            UserScore = 241953
        };

        private readonly Options _options;

        public MockedHitmanServer(Options options)
        {
            _options = options;
        }

        public void Initialize()
        {
            //Apply options to the mocked contracts
            _mockedContractWithoutCompetition.UserId = _options.MockedContractSteamId;
            _mockedContractWithoutCompetition.HighestScoringFriendName = _options.MockedContractSteamId;

            _mockedContractWithCompetition.UserId = _options.MockedContractSteamId;
            _mockedContractWithCompetition.CompetitionLeader = _options.MockedContractSteamId;
            _mockedContractWithCompetition.HighestScoringFriendName = _options.MockedContractSteamId;
            _mockedContractWithCompetition.Competition.Competition[0].CompetitionCreator = _options.MockedContractSteamId;
        }

        public int ExecuteWalletTransaction(HitmanController.ExecuteWalletTransactionRequest request)
        {
            return 101;
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
            var templateDataKeyValues = new Dictionary<string, string>
            {
                ["{ContractId}"] = _mockedContractWithoutCompetition.Id,
                ["{ContractName}"] = _mockedContractWithoutCompetition.DisplayId,
                ["{userid}"] = "userid: LennardF1989",
                ["{CompetitionCreatorName}"] = "CompetitionCreatorName: LennardF1989",
                ["{WinnerName}"] = "WinnerName: LennardF1989",
                ["{WinnerScore}"] = "WinnerScore: 101",
                ["{PlayerScore}"] = "PlayerScore: 101",
                ["{NumberOfParticipants}"] = "NumberOfParticipants: 47",
                ["{TrophiesEarned}"] = "TrophiesEarned: 47"
            };

            var templateData = string.Join(
                "|||",
                templateDataKeyValues.Select(x => $"{x.Key}|||{x.Value}")
            );

            var messages = Enum
                .GetNames<EMessageTextTemplate>()
                .OrderBy(x => x)
                .Skip(request.Skip)
                .Take(request.Limit)
                .Select(x => (EMessageTextTemplate)Enum.Parse(typeof(EMessageTextTemplate), x))
                .Select((textTemplateId, i) =>
                {
                    var actualTemplateData = textTemplateId switch
                    {
                        EMessageTextTemplate.None =>
                            "Diana, she..." +
                            "|||" +
                            "Always talks about him.<BR><BR>Way back when they first worked together.",
                        EMessageTextTemplate.Silverballer => HitmanController.MasterCraftedSilverballer(
                            "Kill Diana with a Silverballer",
                            "Or maybe don't?",
                            _mockedContractWithoutCompetition.Id
                        ),
                        _ => templateData
                    };

                    return new Message
                    {
                        Id = 5000 + i,
                        FromId = "LennardF1989",
                        IsRead = true,
                        Category = EMessageCategory.Medal,
                        TextTemplateId = textTemplateId,
                        TemplateData = actualTemplateData,
                        TimestampUTC = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
                    };
                })
                .ToList();

            return messages;
        }

        public Contract GetFeaturedContract(HitmanController.GetFeaturedContractRequest request)
        {
            return _mockedContractWithCompetition;
        }

        public int GetNewMessageCount(HitmanController.GetNewMessageCountRequest request)
        {
            return 10;
        }

        public GetUserOverviewData GetUserOverviewData(HitmanController.GetUserOverviewDataRequest request)
        {
            return new GetUserOverviewData
            {
                ContractPlays = 1337,
                CompetitionPlays = 1337,
                ContractsCreated = 1337,
                ContractsCreatedLikes = 1337,
                DeadliestAverage = 1337,
                DeadliestRank = 1337,
                PopularAverage = 1337,
                PopularRank = 1337,
                RichestAverage = 1337,
                RichestRank = 1337,
                TrophiesEarned = 1337,
                WalletAmount = _options.WalletAmount
            };
        }

        public int GetUserWallet(HitmanController.GetUserWalletRequest request)
        {
            return _options.WalletAmount;
        }

        public void MarkContractAsPlayed(HitmanController.MarkContractAsPlayedRequest request)
        {
            //Do nothing
        }

        public int PutScore(HitmanController.PutScoreRequest request)
        {
            return 1337;
        }

        public void QueueAddContract(HitmanController.QueueAddContractRequest request)
        {
            //Do nothing
        }

        public void QueueRemoveContract(HitmanController.QueueRemoveContractRequest request)
        {
            //Do nothing
        }

        public List<Contract> SearchForContracts2(HitmanController.SearchForContracts2Request request)
        {
            return new List<Contract>
            {
                _mockedContractWithoutCompetition,
                _mockedContractWithCompetition
            };
        }

        public void UpdateUserInfo(HitmanController.UpdateUserInfoRequest request)
        {
            //Do nothing
        }

        public void UploadContract(HitmanController.UploadContractRequest request)
        {
            //Do nothing
        }
    }
}
