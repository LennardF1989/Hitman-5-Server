using HM5.Server.Enums;
using HM5.Server.Models.Base;
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
        private static readonly EdmFunctionImport _getAverageScores = new()
        {
            Name = "GetAverageScores",
            HttpMethod = HttpMethods.GET,
            ReturnType = $"Collection({EdmTypes.String})",
            Parameters = new List<SFunctionParameter>
            {
                new()
                {
                    Name = "leaderboardtype",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "leaderboardid",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "userid",
                    Type = EdmTypes.String
                }
            }
        };

        [HttpGet]
        [Route("GetAverageScores")]
        public IActionResult GetAverageScores()
        {
            return JsonOperationListResponse(_mockedGetAverageScoresResponse);
        }
    }
}
