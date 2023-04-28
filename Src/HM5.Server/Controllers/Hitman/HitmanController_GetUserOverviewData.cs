using HM5.Server.Attributes;
using HM5.Server.Enums;
using HM5.Server.Interfaces;
using HM5.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    /**
     * Invoke: ZContractManager::RetrieveUserOverviewData @ 006DF920
     * Callback: ZContractManager::RetrieveUserOverviewDataCallback @ 00554640
     * ReturnType: ZOEntry
     */
    public partial class HitmanController
    {
        [EdmFunctionImport(
            "GetUserOverviewData", 
            HttpMethods.GET, 
            $"{SchemaNamespace}.GetUserOverviewData"
        )]
        public class GetUserOverviewDataRequest : IEdmFunctionImport
        {
            [NormalizedString]
            [SFunctionParameter("userid", EdmTypes.String)]
            public string UserId { get; set; }
        }
        
        [HttpGet]
        [Route("GetUserOverviewData")]
        public IActionResult GetUserOverviewData([FromQuery] GetUserOverviewDataRequest request)
        {
            return JsonEntryResponse(new GetUserOverviewData
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
                WalletAmount = 1337
            });
        }
    }
}
