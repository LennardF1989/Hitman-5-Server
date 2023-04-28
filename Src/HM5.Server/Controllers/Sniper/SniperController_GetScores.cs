using HM5.Server.Attributes;
using HM5.Server.Enums;
using HM5.Server.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Sniper
{
    /**
     * Invoke: ZLeaderboard::GetScores @ 0080E630
     * Callback: ZLeaderboard::GetScoresCallback @ 0080DF80
     * ReturnType: ZOFeed
     */
    public partial class SniperController
    {
        [EdmFunctionImport(
            "GetScores",
            HttpMethods.GET,
            $"Collection({SchemaNamespace}.ScoreEntry)"
        )]
        public class GetScoresRequest : IEdmFunctionImport
        {
            [SFunctionParameter("leaderboardid", EdmTypes.Int32)]
            public int LeaderboardId { get; set; }

            [SFunctionParameter("filter", EdmTypes.Int32)]
            public int Filter { get; set; }

            [SFunctionParameter("startindex", EdmTypes.Int32)]
            public int StartIndex { get; set; }

            [SFunctionParameter("range", EdmTypes.Int32)]
            public int Range { get; set; }

            [NormalizedString]
            [SFunctionParameter("userid", EdmTypes.String)]
            public string UserId { get; set; }
        }

        [HttpGet]
        [Route("GetScores")]
        public IActionResult GetScores([FromQuery] GetScoresRequest request)
        {
            //NOTE: leaderboardid is always 0
            return JsonFeedResponse(_mockedGetScoresResponse);
        }
    }
}
