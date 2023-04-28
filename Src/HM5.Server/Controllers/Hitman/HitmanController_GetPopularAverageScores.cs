using HM5.Server.Attributes;
using HM5.Server.Enums;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    /**
     * Invoke: ZLeaderboard::GetSpecialAveragePopular @ 00895B20
     * Callback: ZLeaderboard::GetAverageScoresCallback @ 00760350
     * ReturnType: ZOServiceOperationResult
     */
    public partial class HitmanController
    {
        [EdmFunctionImport(
            "GetPopularAverageScores",
            HttpMethods.GET,
            $"Collection({EdmTypes.String})"
        )]
        public class GetPopularAverageScoresRequest : BaseGetAverageScoresRequest
        {
            //Do nothing
        }

        [HttpGet]
        [Route("GetPopularAverageScores")]
        public IActionResult GetPopularAverageScores([FromQuery] GetPopularAverageScoresRequest request)
        {
            return JsonOperationListResponse(_mockedGetAverageScoresResponse);
        }
    }
}
