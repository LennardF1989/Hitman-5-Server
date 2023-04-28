using HM5.Server.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    /**
     * Invoke: ZLeaderboard::GetSpecialRichest @ 00868C30
     * Callback: ZLeaderboard::GetScoresCallback @ 007FD3D0
     * ReturnType: ZOFeed
     */
    public partial class HitmanController
    {
        [EdmFunctionImport(
            "GetRichestScores",
            HttpMethods.GET,
            $"Collection({SchemaNamespace}.ScoreEntry)"
        )]
        public class GetRichestScoresRequest : BaseGetScoresRequest
        {
            //Do nothing
        }

        [HttpGet]
        [Route("GetRichestScores")]
        public IActionResult GetRichestScores([FromQuery] GetRichestScoresRequest request)
        {
            return JsonFeedResponse(_mockedGetScoresResponse);
        }
    }
}
