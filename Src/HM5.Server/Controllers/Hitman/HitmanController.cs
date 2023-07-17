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

        private readonly IMetadataService _metadataService;
        private readonly IHitmanServer _hitmanServer;

        public HitmanController(
            ISimpleLogger simpleLogger,
            IMetadataServiceForHitman metadataService,
            IHitmanServer hitmanServer
        )
            : base(simpleLogger)
        {
            _metadataService = metadataService;
            _hitmanServer = hitmanServer;
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

        public static string MasterCraftedSilverballer(string title, string body, string contractId = null)
        {
            return contractId == null
                ? $"Silverballer|||{title}||{{baller}}|||{{baller}}||||{body}"
                : $"{{ContractId}}|||{contractId}|||Silverballer|||{title}||{{baller}}|||{{baller}}||||{body}";
        }
    }
}