using HM5.Server.Enums;
using HM5.Server.Models.Base;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    /**
     * Invoke: ZOnlineManager::UploadProfileSpecialRatings @ 0054AB20
     * Callback: None
     */
    public partial class HitmanController
    {
        private static readonly EdmFunctionImport _updateUserProfileSpecialRatings = new()
        {
            Name = "UpdateUserProfileSpecialRatings",
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
        [Route("UpdateUserProfileSpecialRatings")]
        public IActionResult UpdateUserProfileSpecialRatings()
        {
            //NOTE: data contains a data that needs to be parsed
            return Ok();
        }
    }
}
