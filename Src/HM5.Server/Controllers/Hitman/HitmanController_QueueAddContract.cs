using HM5.Server.Enums;
using HM5.Server.Models.Base;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    /**
     * Invoke: ZContractManager::AddContractToQueue @ 004DCF90
     * Callback: None
     */
    public partial class HitmanController
    {
        private static readonly EdmFunctionImport _queueAddContract = new()
        {
            Name = "QueueAddContract",
            HttpMethod = HttpMethods.GET,
            ReturnType = null,
            Parameters = new List<SFunctionParameter>
            {
                new()
                {
                    Name = "contractid",
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
        [Route("QueueAddContract")]
        public IActionResult QueueAddContract()
        {
            return Ok();
        }
    }
}
