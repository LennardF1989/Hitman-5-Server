using HM5.Server.Attributes;
using HM5.Server.Enums;
using HM5.Server.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    /**
     * Invoke: ZContractPlayer::Activate @ 006DFD10
     * Callback: None
     */
    public partial class HitmanController
    {
        [EdmFunctionImport("MarkContractAsPlayed", HttpMethods.GET, null)]
        public class MarkContractAsPlayedRequest : IEdmFunctionImport
        {
            [NormalizedString]
            [SFunctionParameter("userId", EdmTypes.String)]
            public string UserId { get; set; }

            [NormalizedString]
            [SFunctionParameter("contractId", EdmTypes.String)]
            public string ContractId { get; set; }
        }

        [HttpGet]
        [Route("MarkContractAsPlayed")]
        public IActionResult MarkContractAsPlayed([FromQuery] MarkContractAsPlayedRequest request)
        {
            return Ok();
        }
    }
}
