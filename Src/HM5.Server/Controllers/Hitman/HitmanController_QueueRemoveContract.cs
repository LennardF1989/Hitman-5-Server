using HM5.Server.Enums;
using HM5.Server.Models.Base;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    /**
     * Invoke: ZContractManager::ChangeLevel @ 00646AD0
     * Callback: None
     */
    public partial class HitmanController
    {
        private static readonly EdmFunctionImport _queueRemoveContract = new()
        {
            Name = "QueueRemoveContract",
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
                }
            }
        };

        [HttpGet]
        [Route("QueueRemoveContract")]
        public IActionResult QueueRemoveContract()
        {
            return Ok();
        }
    }
}
