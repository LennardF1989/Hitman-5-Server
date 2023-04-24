using HM5.Server.Enums;
using HM5.Server.Models;
using HM5.Server.Models.Base;
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
        private static readonly EdmFunctionImport _getUserOverviewData = new()
        {
            Name = "GetUserOverviewData",
            HttpMethod = HttpMethods.GET,
            ReturnType = $"{SchemaNamespace}.GetUserOverviewData",
            Parameters = new List<SFunctionParameter>
            {
                new()
                {
                    Name = "userid",
                    Type = EdmTypes.String
                }
            }
        };

        [HttpGet]
        [Route("GetUserOverviewData")]
        public IActionResult GetUserOverviewData()
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
