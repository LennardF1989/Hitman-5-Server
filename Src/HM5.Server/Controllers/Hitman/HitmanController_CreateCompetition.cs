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
        private static readonly EdmFunctionImport _createCompetition = new()
        {
            Name = "CreateCompetition",
            HttpMethod = HttpMethods.GET,
            ReturnType = null,
            Parameters = new List<SFunctionParameter>
            {
                new()
                {
                    Name = "contractId",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "competitionLength",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "allowInvites",
                    Type = EdmTypes.String
                }
            }
        };

        [HttpGet]
        [Route("CreateCompetition")]
        public IActionResult CreateCompetition()
        {
            return Ok();
        }
    }
}
