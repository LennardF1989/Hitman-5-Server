using HM5.Server.Enums;
using HM5.Server.Models.Base;
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
        private static readonly EdmFunctionImport _getDeadliestAverageScores = new()
        {
            Name = "GetDeadliestAverageScores",
            HttpMethod = HttpMethods.GET,
            ReturnType = $"Collection({EdmTypes.String})",
            Parameters = new List<SFunctionParameter>
            {
                new()
                {
                    Name = "userid",
                    Type = EdmTypes.String
                }
            }
        };

        [HttpGet]
        [Route("GetDeadliestAverageScores")]
        public IActionResult GetDeadliestAverageScores()
        {
            return JsonOperationListResponse(_mockedGetAverageScoresResponse);
        }
    }
}
