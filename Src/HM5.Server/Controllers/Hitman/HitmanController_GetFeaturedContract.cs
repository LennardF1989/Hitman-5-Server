using HM5.Server.Enums;
using HM5.Server.Models.Base;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    /**
     * Invoke: ZContractManager::Start @ 806E20
     * Callback: ZContractManager::RetrieveFeaturedContractCallback @ 964FE0
     * ReturnType: ZOEntry
     */
    public partial class HitmanController
    {
        private static readonly EdmFunctionImport _getFeaturedContract = new()
        {
            Name = "GetFeaturedContract",
            HttpMethod = HttpMethods.GET,
            ReturnType = $"{SchemaNamespace}.Contract",
            Parameters = new List<SFunctionParameter>
            {
                new()
                {
                    Name = "levelindex",
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
        [Route("GetFeaturedContract")]
        public IActionResult GetFeaturedContract()
        {
            return JsonEntryResponse(_mockedContractWithCompetition);
        }
    }
}
