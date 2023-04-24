using HM5.Server.Enums;
using HM5.Server.Models.Base;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    /**
     * Invoke: ZContractCreator::SaveContract @ 005A7150
     * Callback: None
     */
    public partial class HitmanController
    {
        private static readonly EdmFunctionImport _uploadContract = new()
        {
            Name = "UploadContract",
            HttpMethod = HttpMethods.GET,
            ReturnType = null,
            Parameters = new List<SFunctionParameter>
            {
                new()
                {
                    Name = "levelIndex",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "checkpointIndex",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "difficulty",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "exitId",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "userId",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "title",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "description",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "score",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "startingweapontoken",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "startingoutfittoken",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "competitionParticipants",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "competitionAllowInvites",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "competitionDuration",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "targetsJson",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "restrictionsJson",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "metacategoriesJson",
                    Type = EdmTypes.String
                }
            }
        };

        [HttpGet]
        [Route("UploadContract")]
        public IActionResult UploadContract()
        {
            return Ok();
        }
    }
}
