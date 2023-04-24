using HM5.Server.Enums;
using HM5.Server.Models;
using HM5.Server.Models.Base;
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
        private static readonly EdmFunctionImport _searchForContracts2 = new()
        {
            Name = "SearchForContracts2",
            HttpMethod = HttpMethods.GET,
            ReturnType = $"Collection({SchemaNamespace}.Contract)",
            Parameters = new List<SFunctionParameter>
            {
                new()
                {
                    Name = "view",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "sort",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "levelindex",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "checkpointid",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "categoryid",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "difficulty",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "contractid",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "contractname",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "startindex",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "range",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "userid",
                    Type = EdmTypes.String
                }
            }
        };

        [HttpGet]
        [Route("SearchForContracts2")]
        public IActionResult SearchForContracts2()
        {
            return JsonFeedResponse(new List<Contract>
            {
                _mockedContractWithoutCompetition,
                _mockedContractWithCompetition
            });
        }
    }
}
