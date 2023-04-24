using HM5.Server.Enums;
using HM5.Server.Models.Base;
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
        private static readonly EdmFunctionImport _getPopularAverageScores = new()
        {
            Name = "GetPopularAverageScores",
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
        [Route("GetPopularAverageScores")]
        public IActionResult GetPopularAverageScores()
        {
            return JsonOperationListResponse(_mockedGetAverageScoresResponse);
        }
    }
}
