using HM5.Server.Enums;
using HM5.Server.Models.Base;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Sniper
{
    /**
     * Invoke: ZOnlineManager::UploadProfile @ 0080DB10
     * Callback: None
     */
    public partial class SniperController
    {
        private static readonly EdmFunctionImport _updateUserProfile = new()
        {
            Name = "UpdateUserProfile",
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
                    Name = "country",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "friends",
                    Type = EdmTypes.String
                }
            }
        };

        [HttpGet]
        [Route("UpdateUserProfile")]
        public IActionResult UpdateUserProfile()
        {
            return Ok();
        }
    }
}
