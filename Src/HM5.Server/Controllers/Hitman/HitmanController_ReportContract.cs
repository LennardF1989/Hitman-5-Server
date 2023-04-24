using HM5.Server.Enums;
using HM5.Server.Models.Base;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    /**
     * Invoke:
     * - ZContractManager::ReportContract @ 0044DDF0
     * - ZContractManager::ReportContract @ 0049E220
     * Callback: None
     */
    public partial class HitmanController
    {
        private static readonly EdmFunctionImport _reportContract = new()
        {
            Name = "ReportContract",
            HttpMethod = HttpMethods.GET,
            ReturnType = null,
            Parameters = new List<SFunctionParameter>
            {
                new()
                {
                    Name = "userid",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "contractid",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "reason",
                    Type = EdmTypes.String
                }
            }
        };

        [HttpGet]
        [Route("ReportContract")]
        public IActionResult ReportContract()
        {
            return Ok();
        }
    }
}
