using HM5.Server.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    /**
     * Invoke: ZLeaderboard::GetSpecialPopular @ 0095F6A0
     * Callback: ZLeaderboard::GetScoresCallback @ 007FD3D0
     * ReturnType: ZOFeed
     */
    public partial class HitmanController
    {
        [EdmFunctionImport(
            "GetPopularScores",
            HttpMethods.GET,
            $"Collection({SchemaNamespace}.ScoreEntry)"
        )]
        public class GetPopularScoresRequest : BaseGetScoresRequest
        {
            //Do nothing
        }

        [HttpGet]
        [Route("GetPopularScores")]
        public IActionResult GetPopularScores([FromQuery] GetPopularScoresRequest request)
        {
            return JsonFeedResponse(_mockedGetScoresResponse);
        }
    }
}
