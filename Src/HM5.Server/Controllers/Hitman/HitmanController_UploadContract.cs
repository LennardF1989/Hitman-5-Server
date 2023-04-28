using HM5.Server.Attributes;
using HM5.Server.Enums;
using HM5.Server.Interfaces;
using HM5.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    /**
     * Invoke: ZContractCreator::SaveContract @ 005A7150
     * Callback: None
     */
    public partial class HitmanController
    {
        [EdmFunctionImport("UploadContract", HttpMethods.GET, null)]
        public class UploadContractRequest : IEdmFunctionImport
        {
            [SFunctionParameter("levelIndex", EdmTypes.Int32)]
            public int LevelIndex { get; set; }

            [SFunctionParameter("checkpointIndex", EdmTypes.Int32)]
            public int CheckpointIndex { get; set; }

            [SFunctionParameter("difficulty", EdmTypes.Int32)]
            public int Difficulty { get; set; }

            [SFunctionParameter("exitId", EdmTypes.Int32)]
            public int ExitId { get; set; }

            [NormalizedString]
            [SFunctionParameter("userId", EdmTypes.String)]
            public string UserId { get; set; }

            [NormalizedString]
            [SFunctionParameter("title", EdmTypes.String)]
            public string Title { get; set; }

            [NormalizedString]
            [SFunctionParameter("description", EdmTypes.String)]
            public string Description { get; set; }

            [SFunctionParameter("score", EdmTypes.Int32)]
            public int Score { get; set; }

            [SFunctionParameter("startingweapontoken", EdmTypes.Int32)]
            public int StartingWeaponToken { get; set; }

            [SFunctionParameter("startingoutfittoken", EdmTypes.Int32)]
            public int StartingOutfitToken { get; set; }

            [SplitNormalizedString]
            [SFunctionParameter("competitionParticipants", EdmTypes.String)]
            public List<string> CompetitionParticipants { get; set; }

            [SFunctionParameter("competitionAllowInvites", EdmTypes.Boolean)]
            public bool CompetitionAllowInvites { get; set; }

            [SFunctionParameter("competitionDuration", EdmTypes.Int32)]
            public int CompetitionDuration { get; set; }

            [NormalizedJsonString("targetsJson")]
            [SFunctionParameter("targetsJson", EdmTypes.String)]
            public List<Target> Targets { get; set; }

            [NormalizedJsonString("restrictionsJson")]
            [SFunctionParameter("restrictionsJson", EdmTypes.String)]
            public List<ERestrictionType> Restrictions { get; set; }

            [NormalizedJsonString("metacategoriesJson")]
            [SFunctionParameter("metacategoriesJson", EdmTypes.String)]
            public List<int> Metacategories { get; set; }
        }

        [HttpGet]
        [Route("UploadContract")]
        public IActionResult UploadContract([FromQuery] UploadContractRequest request)
        {
            return Ok();
        }
    }
}
