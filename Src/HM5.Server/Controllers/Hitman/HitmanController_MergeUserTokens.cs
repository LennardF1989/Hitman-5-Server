using HM5.Server.Attributes;
using HM5.Server.Enums;
using HM5.Server.Interfaces;
using HM5.Server.Models;
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
        [EdmFunctionImport(
            "MergeUserTokens", 
            HttpMethods.GET, 
            $"Collection({SchemaNamespace}.UserTokenData)"
        )]
        public class MergeUserTokensRequest : IEdmFunctionImport
        {
            [NormalizedString]
            [SFunctionParameter("userId", EdmTypes.String)]
            public string UserId { get; set; }

            [NormalizedJsonString]
            [SFunctionParameter("tokenData", EdmTypes.String)]
            public List<UserTokenData> TokenData { get; set; }
        }

        [HttpGet]
        [Route("MergeUserTokens")]
        public IActionResult MergeUserTokens([FromQuery] MergeUserTokensRequest request)
        {
            return JsonFeedResponse(new List<UserTokenData>());
        }
    }
}
