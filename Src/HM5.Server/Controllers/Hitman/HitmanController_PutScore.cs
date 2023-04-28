using HM5.Server.Attributes;
using HM5.Server.Enums;
using HM5.Server.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    /**
     * Invoke: ZLeaderboard::UploadScore @ 00915670
     * Callback: ZLeaderboard::UploadScoreCallback @ 004630A0
     * ReturnType: ZOServiceOperationResult
     */
    public partial class HitmanController
    {
        [EdmFunctionImport("PutScore", HttpMethods.GET, null)]
        public class PutScoreRequest : IEdmFunctionImport
        {
            [SFunctionParameter("leaderboardtype", EdmTypes.Int32)]
            public int LeaderboardType { get; set; }

            [NormalizedString]
            [SFunctionParameter("leaderboardid", EdmTypes.String)]
            public string LeaderboardId { get; set; }

            [NormalizedString]
            [SFunctionParameter("userid", EdmTypes.String)]
            public string UserId { get; set; }

            [SFunctionParameter("score", EdmTypes.Int32)]
            public int Score { get; set; }

            [SFunctionParameter("rating", EdmTypes.Int32)]
            public int Rating { get; set; }
        }

        [HttpGet]
        [Route("PutScore")]
        public IActionResult PutScore([FromQuery] PutScoreRequest request)
        {
            //NOTE: Appears to be the difference between your new and last (personal best) score
            return JsonOperationValueResponse(1337);
        }
    }
}
