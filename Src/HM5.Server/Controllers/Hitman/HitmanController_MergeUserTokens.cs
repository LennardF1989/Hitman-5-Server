using HM5.Server.Enums;
using HM5.Server.Models;
using HM5.Server.Models.Base;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    /**
     * Invoke: ZContractManager::MergeUserTokensAsync @ 00683F60
     * Callback: ZContractManager::MergeUserTokensAsyncCallback @ 0089A170
     * ReturnType: ZOFeed
     */
    public partial class HitmanController
    {
        private static readonly EdmFunctionImport _mergeUserTokens = new()
        {
            Name = "MergeUserTokens",
            HttpMethod = HttpMethods.GET,
            ReturnType = $"Collection({SchemaNamespace}.UserTokenData)",
            Parameters = new List<SFunctionParameter>
            {
                new()
                {
                    Name = "userId",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "tokenData",
                    Type = EdmTypes.String
                }
            }
        };

        [HttpGet]
        [Route("MergeUserTokens")]
        public IActionResult MergeUserTokens()
        {
            //NOTE: tokenData needs further parsing
            return JsonFeedResponse(new List<UserTokenData>());
        }
    }
}
