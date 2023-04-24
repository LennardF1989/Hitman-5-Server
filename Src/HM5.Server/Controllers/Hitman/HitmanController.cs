using HM5.Server.Enums;
using HM5.Server.Interfaces;
using HM5.Server.Models;
using HM5.Server.Models.Base;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    [Route("hm5")]
    public partial class HitmanController : BaseController
    {
        public const string SchemaNamespace = "HM5";

        //NOTE: Rating seems unused in UI?
        private readonly List<ScoreEntry> _mockedGetScoresResponse = new()
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

        private readonly List<int> _mockedGetAverageScoresResponse = new()
        {
            1, //World Average
            2, //Country Average
            3, //Friends Average
            4 //Score: Deadliest / Richest / Most Popular Assassin
        };

        private readonly Contract _mockedContractWithoutCompetition = new()
        {
            Id = 1,
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

        private readonly Contract _mockedContractWithCompetition = new()
        {
            Id = 2,
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

        private readonly IMetadataService _metadataService;

        public HitmanController(
            ISimpleLogger simpleLogger,
            IMetadataServiceForHitman metadataService
        )
            : base(simpleLogger)
        {
            _metadataService = metadataService;
        }

        public static List<EdmFunctionImport> GetEdmFunctionImports()
        {
            return new List<EdmFunctionImport>
            {
                _updateDLCInfo,
                _getRichestAverageScores,
                _reportContract,
                _getScoreComparison,
                _updateUserProfileLevelProgression,
                _queueAddContract,
                _searchForContracts2,
                _getUserWallet,
                _updateUserProfileSpecialRatings,
                _uploadContract,
                _sendTemplatedMessage,
                _getMessages,
                _updateContractLikeDislikes,
                _queueRemoveContract,
                _mergeUserTokens,
                _executeWalletTransaction,
                _getUserOverviewData,
                _markContractAsPlayed,
                _inviteToCompetition,
                _createCompetition,
                _getAverageScores,
                _getDeadliestScores,
                _updateUserInfo,
                _getScores,
                _getFeaturedContract,
                _setMessageReadStatus,
                _getRichestScores,
                _getPopularAverageScores,
                _updateUserProfileChallenges,
                _updateUserProfileGameStats,
                _putScore,
                _getDeadliestAverageScores,
                _getPopularScores,
                _getNewMessageCount
            };
        }

        public static List<Type> GetEdmEntityTypes()
        {
            return new List<Type>
            {
                typeof(Contract),
                typeof(GetUserOverviewData),
                typeof(Message),
                typeof(ScoreComparison),
                typeof(ScoreEntry),
                typeof(UserTokenData)
            };
        }
    }
}