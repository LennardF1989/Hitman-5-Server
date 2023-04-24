using HM5.Server.Enums;
using HM5.Server.Models.Base;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    /**
     * Invoke: ZLeaderboard::GetSpecialDeadliest @ 00791C00
     * Callback: ZLeaderboard::GetScoresCallback @ 007FD3D0
     * ReturnType: ZOFeed
     */
    public partial class HitmanController
    {
        private static readonly EdmFunctionImport _getDeadliestScores = new()
        {
            Name = "GetDeadliestScores",
            HttpMethod = HttpMethods.GET,
            ReturnType = $"Collection({SchemaNamespace}.ScoreEntry)",
            Parameters = new List<SFunctionParameter>
            {
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
        [Route("GetDeadliestScores")]
        public IActionResult GetDeadliestScores()
        {
            return JsonFeedResponse(_mockedGetScoresResponse);
        }
    }
}
