using HM5.Server.Attributes;
using HM5.Server.Enums;
using HM5.Server.Interfaces;
using HM5.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    /**
     * Invoke: ZOnlineManager::UploadProfileSpecialRatings @ 0054AB20
     * Callback: None
     */
    public partial class HitmanController
    {
        [EdmFunctionImport("UpdateUserProfileSpecialRatings", HttpMethods.GET, null)]
        public class UpdateUserProfileSpecialRatingsRequest : IEdmFunctionImport
        {
            [NormalizedString]
            [SFunctionParameter("userid", EdmTypes.String)]
            public string UserId { get; set; }

            [NormalizedJsonString]
            [SFunctionParameter("data", EdmTypes.String)]
            public UserProfileSpecialRatings Data { get; set; }
        }

        [HttpGet]
        [Route("UpdateUserProfileSpecialRatings")]
        public IActionResult UpdateUserProfileSpecialRatings([FromQuery] UpdateUserProfileSpecialRatingsRequest request)
        {
            return Ok();
        }
    }
}
