using HM5.Server.Attributes;
using HM5.Server.Enums;
using HM5.Server.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    /**
     * Invoke: ZContractManager::AddContractToQueue @ 004DCF90
     * Callback: None
     */
    public partial class HitmanController
    {
        [EdmFunctionImport("QueueAddContract", HttpMethods.GET, null)]
        public class QueueAddContractRequest : IEdmFunctionImport
        {
            [NormalizedString]
            [SFunctionParameter("contractId", EdmTypes.String)]
            public string ContractId { get; set; }

            [NormalizedString]
            [SFunctionParameter("userid", EdmTypes.String)]
            public string UserId { get; set; }
        }

        [HttpGet]
        [Route("QueueAddContract")]
        public IActionResult QueueAddContract([FromQuery] QueueAddContractRequest request)
        {
            return Ok();
        }
    }
}
