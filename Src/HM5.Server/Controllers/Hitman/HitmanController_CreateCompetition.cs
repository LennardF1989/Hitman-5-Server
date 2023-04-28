using HM5.Server.Attributes;
using HM5.Server.Enums;
using HM5.Server.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    /**
     * Invoke: ZContractManager::UpdateCompetition @ 006E50B0
     * Callback: None
     */
    public partial class HitmanController
    {
        [EdmFunctionImport("CreateCompetition", HttpMethods.GET, null)]
        public class CreateCompetitionRequest : IEdmFunctionImport
        {
            [NormalizedString]
            [SFunctionParameter("fromId", EdmTypes.String)]
            public string FromId { get; set; }

            [SplitNormalizedString]
            [SFunctionParameter("participants", EdmTypes.String)]
            public List<string> Participants { get; set; }

            [NormalizedString]
            [SFunctionParameter("contractId", EdmTypes.String)]
            public string ContractId { get; set; }

            [SFunctionParameter("competitionLength", EdmTypes.Int32)]
            public int CompetitionLength { get; set; }

            [SFunctionParameter("allowInvites", EdmTypes.Boolean)]
            public bool AllowInvites { get; set; }
        }

        [HttpGet]
        [Route("CreateCompetition")]
        public IActionResult CreateCompetition([FromQuery] CreateCompetitionRequest request)
        {
            return Ok();
        }
    }
}
