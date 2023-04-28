using HM5.Server.Attributes;
using HM5.Server.Enums;
using HM5.Server.Interfaces;
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
        [EdmFunctionImport("ReportContract", HttpMethods.GET, null)]
        public class ReportContractRequest : IEdmFunctionImport
        {
            [NormalizedString]
            [SFunctionParameter("userid", EdmTypes.String)]
            public string UserId { get; set; }

            [NormalizedString]
            [SFunctionParameter("contractId", EdmTypes.String)]
            public string ContractId { get; set; }

            [SFunctionParameter("reason", EdmTypes.Int32)]
            public int Reason { get; set; }
        }

        [HttpGet]
        [Route("ReportContract")]
        public IActionResult ReportContract([FromQuery] ReportContractRequest request)
        {
            return Ok();
        }
    }
}
