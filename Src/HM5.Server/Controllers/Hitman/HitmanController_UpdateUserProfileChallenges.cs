using HM5.Server.Enums;
using HM5.Server.Models.Base;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    /**
     * Invoke: ZOnlineManager::UploadProfileChallenges @ 008DE580
     * Callback: None
     */
    public partial class HitmanController
    {
        private static readonly EdmFunctionImport _updateUserProfileChallenges = new()
        {
            Name = "UpdateUserProfileChallenges",
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
        [Route("UpdateUserProfileChallenges")]
        public IActionResult UpdateUserProfileChallenges()
        {
            //NOTE: data contains a data that needs to be parsed
            return Ok();
        }
    }
}
