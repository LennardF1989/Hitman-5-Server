using HM5.Server.Attributes;
using HM5.Server.Enums;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    /**
     * Invoke: ZLeaderboard::GetSpecialAverageDeadliest @ 00919C70
     * Callback: ZLeaderboard::GetAverageScoresCallback @ 00760350
     * ReturnType: ZOServiceOperationResult
     */
    public partial class HitmanController
    {
        [EdmFunctionImport(
            "GetDeadliestAverageScores", 
            HttpMethods.GET, 
            $"Collection({EdmTypes.String})"
        )]
        public class GetDeadliestAverageScoresRequest : BaseGetAverageScoresRequest
        {
            //Do nothing
        }

        [HttpGet]
        [Route("GetDeadliestAverageScores")]
        public IActionResult GetDeadliestAverageScores([FromQuery] GetDeadliestAverageScoresRequest request)
        {
            return JsonOperationListResponse(_mockedGetAverageScoresResponse);
        }
    }
}
