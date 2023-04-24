using HM5.Server.Enums;
using HM5.Server.Models.Base;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Sniper
{
    /**
     * Invoke: ZLeaderboard::GetScores @ 0080E630
     * Callback: ZLeaderboard::GetScoresCallback @ 0080DF80
     * ReturnType: ZOFeed
     */
    public partial class SniperController
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
            //NOTE: leaderboardid is always 0
            return JsonFeedResponse(_mockedGetScoresResponse);
        }
    }
}
