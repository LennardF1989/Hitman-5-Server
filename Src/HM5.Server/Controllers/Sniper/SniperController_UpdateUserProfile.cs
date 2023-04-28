using HM5.Server.Attributes;
using HM5.Server.Enums;
using HM5.Server.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Sniper
{
    /**
     * Invoke: ZOnlineManager::UploadProfile @ 0080DB10
     * Callback: None
     */
    public partial class SniperController
    {
        [EdmFunctionImport("UpdateUserProfile", HttpMethods.GET, null)]
        public class UpdateUserProfileRequest : IEdmFunctionImport
        {
            [NormalizedString]
            [SFunctionParameter("userid", EdmTypes.String)]
            public string UserId { get; set; }

            [SFunctionParameter("country", EdmTypes.Int32)]
            public int Country { get; set; }

            [SplitNormalizedString]
            [SFunctionParameter("friends", EdmTypes.String)]
            public List<string> Friends { get; set; }
        }

        [HttpGet]
        [Route("UpdateUserProfile")]
        public IActionResult UpdateUserProfile([FromQuery] UpdateUserProfileRequest request)
        {
            return Ok();
        }
    }
}
