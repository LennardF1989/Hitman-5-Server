using HM5.Server.Enums;
using HM5.Server.Models.Base;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    /**
     * Invoke: ZContractManager::UpdateCompetition @ 006E50B0
     * Callback: None
     */
    public partial class HitmanController
    {
        private static readonly EdmFunctionImport _inviteToCompetition = new()
        {
            Name = "InviteToCompetition",
            HttpMethod = HttpMethods.GET,
            ReturnType = null,
            Parameters = new List<SFunctionParameter>
            {
                new()
                {
                    Name = "fromId",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "participants",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "competitionId",
                    Type = EdmTypes.String
                }
            }
        };

        [HttpGet]
        [Route("InviteToCompetition")]
        public IActionResult InviteToCompetition()
        {
            return Ok();
        }
    }
}
