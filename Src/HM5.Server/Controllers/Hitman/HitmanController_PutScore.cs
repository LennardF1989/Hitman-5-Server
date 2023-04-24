using HM5.Server.Enums;
using HM5.Server.Models.Base;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    /**
     * Invoke: ZLeaderboard::UploadScore @ 00915670
     * Callback: ZLeaderboard::UploadScoreCallback @ 004630A0
     * ReturnType: ZOServiceOperationResult
     */
    public partial class HitmanController
    {
        private static readonly EdmFunctionImport _putScore = new()
        {
            Name = "PutScore",
            HttpMethod = HttpMethods.GET,
            ReturnType = null,
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
                },
                new()
                {
                    Name = "score",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "rating",
                    Type = EdmTypes.String
                }
            }
        };

        [HttpGet]
        [Route("PutScore")]
        public IActionResult PutScore()
        {
            //NOTE: Appears to be the difference between your new and last (personal best) score
            return JsonOperationValueResponse(1337);
        }
    }
}
