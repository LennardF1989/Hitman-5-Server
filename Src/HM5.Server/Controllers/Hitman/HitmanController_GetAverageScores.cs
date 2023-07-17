using HM5.Server.Attributes;
using HM5.Server.Enums;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    /**
     * Invoke: ZLeaderboard::GetAverageScores @ 0073C100
     * Callback: ZLeaderboard::GetAverageScoresCallback @ 00760350
     * ReturnType: ZOServiceOperationResult
     */
    public partial class HitmanController
    {
        [EdmFunctionImport(
            "GetAverageScores", 
            HttpMethods.GET, 
            $"Collection({EdmTypes.String})")
        ]
        public class GetAverageScoresRequest : BaseGetAverageScoresRequest
        {
            [SFunctionParameter("leaderboardtype", EdmTypes.Int32)]
            public int LeaderboardType { get; set; }

            [NormalizedString]
            [SFunctionParameter("leaderboardid", EdmTypes.String)]
            public string LeaderboardId { get; set; }
        }

        [HttpGet]
        [Route("GetAverageScores")]
        public IActionResult GetAverageScores([FromQuery] GetAverageScoresRequest request)
        {
            return JsonOperationListResponse(_hitmanServer.GetAverageScores(request));
        }
    }
}
