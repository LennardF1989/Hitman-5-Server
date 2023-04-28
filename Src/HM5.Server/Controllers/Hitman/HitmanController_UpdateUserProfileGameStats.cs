using System.Text.Json;
using HM5.Server.Attributes;
using HM5.Server.Enums;
using HM5.Server.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    /**
     * Invoke: ZOnlineManager::UploadProfileGameStats @ 0090A2D0
     * Callback: None
     */
    public partial class HitmanController
    {
        [EdmFunctionImport("UpdateUserProfileGameStats", HttpMethods.GET, null)]
        public class UpdateUserProfileGameStatsRequest : IEdmFunctionImport
        {
            [NormalizedString]
            [SFunctionParameter("userid", EdmTypes.String)]
            public string UserId { get; set; }

            [NormalizedJsonString]
            [SFunctionParameter("data", EdmTypes.String)]
            public Dictionary<string, JsonDocument> Data { get; set; }
        }

        [HttpGet]
        [Route("UpdateUserProfileGameStats")]
        public IActionResult UpdateUserProfileGameStats([FromQuery] UpdateUserProfileGameStatsRequest request)
        {
            return Ok();
        }
    }
}
