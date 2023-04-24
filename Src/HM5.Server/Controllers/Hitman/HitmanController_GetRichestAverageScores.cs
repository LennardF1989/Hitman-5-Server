using HM5.Server.Enums;
using HM5.Server.Models.Base;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    /**
     * Invoke: ZLeaderboard::GetSpecialAverageRichest @ 0044D220
     * Callback: ZLeaderboard::GetAverageScoresCallback @ 00760350
     * ReturnType: ZOServiceOperationResult
     */
    public partial class HitmanController
    {
        private static readonly EdmFunctionImport _getRichestAverageScores = new()
        {
            Name = "GetRichestAverageScores",
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
        [Route("GetRichestAverageScores")]
        public IActionResult GetRichestAverageScores()
        {
            return JsonOperationListResponse(_mockedGetAverageScoresResponse);
        }
    }
}
