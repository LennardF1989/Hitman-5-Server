using HM5.Server.Enums;
using HM5.Server.Models.Base;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Sniper
{
    /**
     * Invoke: ZLeaderboard::UploadScore @ 0080DE00
     * Callback: None
     */
    public partial class SniperController
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
                }
            }
        };

        [HttpGet]
        [Route("PutScore")]
        public IActionResult PutScore()
        {
            return Ok();
        }
    }
}
