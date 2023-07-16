using HM5.Server.Attributes;
using HM5.Server.Enums;
using HM5.Server.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    /**
     * Invoke: ZContractManager::ChangeLevel @ 00646AD0
     * Callback: None
     */
    public partial class HitmanController
    {
        [EdmFunctionImport("QueueRemoveContract", HttpMethods.GET, null)]
        public class QueueRemoveContractRequest : IEdmFunctionImport
        {
            [NormalizedString]
            [SFunctionParameter("contractid", EdmTypes.String)]
            public string ContractId { get; set; }

            [NormalizedString]
            [SFunctionParameter("userid", EdmTypes.String)]
            public string UserId { get; set; }
        }

        [HttpGet]
        [Route("QueueRemoveContract")]
        public IActionResult QueueRemoveContract([FromQuery] QueueRemoveContractRequest request)
        {
            return Ok();
        }
    }
}
