using HM5.Server.Enums;
using HM5.Server.Models.Base;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    /**
     * Invoke: ZOnlineManager::UploadProfileLevelProgression @ 004613F0
     * Callback: None
     */
    public partial class HitmanController
    {
        private static readonly EdmFunctionImport _updateUserProfileLevelProgression = new()
        {
            Name = "UpdateUserProfileLevelProgression",
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
        [Route("UpdateUserProfileLevelProgression")]
        public IActionResult UpdateUserProfileLevelProgression()
        {
            //NOTE: data contains a data that needs to be parsed
            return Ok();
        }
    }
}
