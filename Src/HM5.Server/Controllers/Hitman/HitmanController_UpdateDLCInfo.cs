using HM5.Server.Enums;
using HM5.Server.Models.Base;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    /**
     * Invoke: ZOnlineManager::UploadDLCToken @ 0042AA0
     * Callback: None
     */
    public partial class HitmanController
    {
        private static readonly EdmFunctionImport _updateDLCInfo = new()
        {
            Name = "UpdateDLCInfo",
            HttpMethod = HttpMethods.GET,
            ReturnType = null,
            Parameters = new List<SFunctionParameter>
            {
                new()
                {
                    Name = "dlctokens",
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
        [Route("UpdateDLCInfo")]
        public IActionResult UpdateDLCInfo()
        {
            return Ok();
        }
    }
}
