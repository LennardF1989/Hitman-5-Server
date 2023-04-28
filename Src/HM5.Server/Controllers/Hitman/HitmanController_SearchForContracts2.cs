using HM5.Server.Attributes;
using HM5.Server.Enums;
using HM5.Server.Interfaces;
using HM5.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    /**
     * Invoke: ZContractSearchEngine::Retrieve @ 0051C9F0
     * Callback: ZContractSearchEngine::RetrieveCallback @ 5DF560
     * ReturnType: ZOFeed
     */
    public partial class HitmanController
    {
        [EdmFunctionImport("SearchForContracts2", HttpMethods.GET, $"Collection({SchemaNamespace}.Contract)")]
        public class SearchForContracts2Request : IEdmFunctionImport
        {
            [SFunctionParameter("view", EdmTypes.Int32)]
            public int View { get; set; }

            [SFunctionParameter("sort", EdmTypes.Int32)]
            public int Sort { get; set; }

            [SFunctionParameter("levelindex", EdmTypes.Int32)]
            public int LevelIndex { get; set; }

            [SFunctionParameter("checkpointid", EdmTypes.Int32)]
            public int CheckpointId { get; set; }

            [SFunctionParameter("categoryid", EdmTypes.Int32)]
            public int CategoryId { get; set; }

            [SFunctionParameter("difficulty", EdmTypes.Int32)]
            public int Difficulty { get; set; }

            [NormalizedString]
            [SFunctionParameter("contractId", EdmTypes.String)]
            public string ContractId { get; set; }

            [NormalizedString]
            [SFunctionParameter("contractname", EdmTypes.String)]
            public string ContractName { get; set; }

            [SFunctionParameter("startindex", EdmTypes.Int32)]
            public int StartIndex { get; set; }

            [SFunctionParameter("range", EdmTypes.Int32)]
            public int Range { get; set; }

            [NormalizedString]
            [SFunctionParameter("userid", EdmTypes.String)]
            public string UserId { get; set; }
        }

        [HttpGet]
        [Route("SearchForContracts2")]
        public IActionResult SearchForContracts2([FromQuery] SearchForContracts2Request request)
        {
            return JsonFeedResponse(new List<Contract>
            {
                _mockedContractWithoutCompetition,
                _mockedContractWithCompetition
            });
        }
    }
}
