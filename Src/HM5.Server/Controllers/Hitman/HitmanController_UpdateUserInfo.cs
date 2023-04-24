using HM5.Server.Enums;
using HM5.Server.Models.Base;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    /**
     * Invoke: ZOnlineManager::UploadProfile @ 007ADF30
     * Callback: ZOnlineManager::OnUpdateUserProfile @ 006FB440
     * ReturnType: None, but 200 - OK.
     */
    public partial class HitmanController
    {
        private static readonly EdmFunctionImport _updateUserInfo = new()
        {
            Name = "UpdateUserInfo",
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
                    Name = "displayName",
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
        [Route("UpdateUserInfo")]
        public IActionResult UpdateUserInfo()
        {
            return Ok();
        }
    }
}
