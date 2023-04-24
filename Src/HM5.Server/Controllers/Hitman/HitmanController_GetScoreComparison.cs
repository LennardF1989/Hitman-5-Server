using HM5.Server.Enums;
using HM5.Server.Models;
using HM5.Server.Models.Base;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    /**
     * Invoke: ZLeaderboard::GetScoreComparison @ 00458D00
     * Callback: ZLeaderboard::GetScoreComparisonCallback @ 00624360
     * ReturnType: ZOEntry
     */
    public partial class HitmanController
    {
        private static readonly EdmFunctionImport _getScoreComparison = new()
        {
            Name = "GetScoreComparison",
            HttpMethod = HttpMethods.GET,
            ReturnType = $"{SchemaNamespace}.ScoreComparison",
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
        [Route("GetScoreComparison")]
        public IActionResult GetScoreComparison()
        {
            return JsonEntryResponse(new ScoreComparison
            {
                //NOTE: Has to be a SteamID
                FriendName = "76561198161220058",
                FriendScore = 1337,
                CountryAverage = 101,
                WorldAverage = 101
            });
        }
    }
}
