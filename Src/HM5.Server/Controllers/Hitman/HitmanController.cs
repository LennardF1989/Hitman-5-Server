using HM5.Server.Attributes;
using HM5.Server.Enums;
using HM5.Server.Interfaces;
using HM5.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    [Route("hm5")]
    public partial class HitmanController : BaseController
    {
        public abstract class BaseGetScoresRequest : IEdmFunctionImport
        {
            [SFunctionParameter("filter", EdmTypes.Int32)]
            public int Filter { get; set; }

            [SFunctionParameter("startindex", EdmTypes.Int32)]
            public int StartIndex { get; set; }

            [SFunctionParameter("range", EdmTypes.Int32)]
            public int Range { get; set; }

            [NormalizedString]
            [SFunctionParameter("userid", EdmTypes.String)]
            public string UserId { get; set; }
        }

        public abstract class BaseGetAverageScoresRequest : IEdmFunctionImport
        {
            [NormalizedString]
            [SFunctionParameter("userid", EdmTypes.String)]
            public string UserId { get; set; }
        }

        public const string SchemaNamespace = "HM5";

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

        private static readonly Contract _mockedContractWithCompetition = new()
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
            IMetadataServiceForHitman metadataService,
            Options options
        )
            : base(simpleLogger)
        {
            _metadataService = metadataService;

            //Apply options to the mocked contracts
            _mockedContractWithoutCompetition.UserId = options.MockedContractSteamId;
            _mockedContractWithoutCompetition.HighestScoringFriendName = options.MockedContractSteamId;

            _mockedContractWithCompetition.UserId = options.MockedContractSteamId;
            _mockedContractWithCompetition.CompetitionLeader = options.MockedContractSteamId;
            _mockedContractWithCompetition.HighestScoringFriendName = options.MockedContractSteamId;
            _mockedContractWithCompetition.Competition.Competition[0].CompetitionCreator = options.MockedContractSteamId;
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

        public static List<Type> GetEdmFunctionImports()
        {
            return new List<Type>
            {
                typeof(CreateCompetitionRequest),
                typeof(ExecuteWalletTransactionRequest),
                typeof(GetAverageScoresRequest),
                typeof(GetDeadliestAverageScoresRequest),
                typeof(GetDeadliestScoresRequest),
                typeof(GetFeaturedContractRequest),
                typeof(GetMessagesRequest),
                typeof(GetNewMessageCountRequest),
                typeof(GetPopularAverageScoresRequest),
                typeof(GetPopularScoresRequest),
                typeof(GetRichestAverageScoresRequest),
                typeof(GetRichestScoresRequest),
                typeof(GetScoreComparisonRequest),
                typeof(GetScoresRequest),
                typeof(GetUserOverviewDataRequest),
                typeof(GetUserWalletRequest),
                typeof(InviteToCompetitionRequest),
                typeof(MarkContractAsPlayedRequest),
                typeof(MergeUserTokensRequest),
                typeof(PutScoreRequest),
                typeof(QueueAddContractRequest),
                typeof(QueueRemoveContractRequest),
                typeof(ReportContractRequest),
                typeof(SearchForContracts2Request),
                typeof(SendTemplatedMessageRequest),
                typeof(SetMessageReadStatusRequest),
                typeof(UpdateContractLikeDislikesRequest),
                typeof(UpdateDLCInfoRequest),
                typeof(UpdateUserInfoRequest),
                typeof(UpdateUserProfileChallengesRequest),
                typeof(UpdateUserProfileGameStatsRequest),
                typeof(UpdateUserProfileLevelProgressionRequest),
                typeof(UpdateUserProfileSpecialRatingsRequest),
                typeof(UploadContractRequest)
            };
        }
    }
}