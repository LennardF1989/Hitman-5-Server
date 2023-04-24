using HM5.Server.Enums;
using HM5.Server.Models.Base;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    /**
     * Invoke: ZContractPlayer::Activate @ 006DFD10
     * Callback: None
     */
    public partial class HitmanController
    {
        private static readonly EdmFunctionImport _markContractAsPlayed = new()
        {
            Name = "MarkContractAsPlayed",
            HttpMethod = HttpMethods.GET,
            ReturnType = null,
            Parameters = new List<SFunctionParameter>
            {
                new()
                {
                    Name = "userId",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "contractId",
                    Type = EdmTypes.String
                }
            }
        };

        [HttpGet]
        [Route("MarkContractAsPlayed")]
        public IActionResult MarkContractAsPlayed()
        {
            return Ok();
        }
    }
}
