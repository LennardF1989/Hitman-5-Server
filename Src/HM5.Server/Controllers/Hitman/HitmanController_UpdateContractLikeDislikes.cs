using HM5.Server.Enums;
using HM5.Server.Models.Base;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    /**
     * Invoke: ZContractManager::UpdateLikesDislikes @ 0060FC20
     * Callback: None
     */
    public partial class HitmanController
    {
        private static readonly EdmFunctionImport _updateContractLikeDislikes = new()
        {
            Name = "UpdateContractLikeDislikes",
            HttpMethod = HttpMethods.GET,
            ReturnType = null,
            Parameters = new List<SFunctionParameter>
            {
                new()
                {
                    Name = "fromUserId",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "contractId",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "likesIncrement",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "dislikesIncrement",
                    Type = EdmTypes.String
                }
            }
        };

        [HttpGet]
        [Route("UpdateContractLikeDislikes")]
        public IActionResult UpdateContractLikeDislikes()
        {
            return Ok();
        }
    }
}
