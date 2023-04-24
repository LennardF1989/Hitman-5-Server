using HM5.Server.Enums;
using HM5.Server.Models.Base;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    /**
     * Invoke: ZLeaderboard::GetScores @ 007FA160
     * Callback: ZLeaderboard::GetScoresCallback @ 007FD3D0
     * ReturnType: ZOFeed
     */
    public partial class HitmanController
    {
        private static readonly EdmFunctionImport _getScores = new()
        {
            Name = "GetScores",
            HttpMethod = HttpMethods.GET,
            ReturnType = $"Collection({SchemaNamespace}.ScoreEntry)",
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
                    Name = "filter",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "startindex",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "range",
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
        [Route("GetScores")]
        public IActionResult GetScores()
        {
            return JsonFeedResponse(_mockedGetScoresResponse);
        }
    }
}
