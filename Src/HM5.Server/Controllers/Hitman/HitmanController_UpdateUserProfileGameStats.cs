using HM5.Server.Enums;
using HM5.Server.Models.Base;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    /**
     * Invoke: ZOnlineManager::UploadProfileGameStats @ 0090A2D0
     * Callback: None
     */
    public partial class HitmanController
    {
        private static readonly EdmFunctionImport _updateUserProfileGameStats = new()
        {
            Name = "UpdateUserProfileGameStats",
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
                    Name = "data",
                    Type = EdmTypes.String
                }
            }
        };

        [HttpGet]
        [Route("UpdateUserProfileGameStats")]
        public IActionResult UpdateUserProfileGameStats()
        {
            //NOTE: data contains a data that needs to be parsed
            return Ok();
        }
    }
}
