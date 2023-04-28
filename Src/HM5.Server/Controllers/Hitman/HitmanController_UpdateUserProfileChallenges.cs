using HM5.Server.Attributes;
using HM5.Server.Enums;
using HM5.Server.Interfaces;
using HM5.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    /**
     * Invoke: ZOnlineManager::UploadProfileChallenges @ 008DE580
     * Callback: None
     */
    public partial class HitmanController
    {
        [EdmFunctionImport("UpdateUserProfileChallenges", HttpMethods.GET, null)]
        public class UpdateUserProfileChallengesRequest : IEdmFunctionImport
        {
            [NormalizedString]
            [SFunctionParameter("userid", EdmTypes.String)]
            public string UserId { get; set; }

            [NormalizedJsonString]
            [SFunctionParameter("data", EdmTypes.String)]
            public UserProfileChallenges Data { get; set; }
        }

        [HttpGet]
        [Route("UpdateUserProfileChallenges")]
        public IActionResult UpdateUserProfileChallenges([FromQuery] UpdateUserProfileChallengesRequest request)
        {
            return Ok();
        }
    }
}
