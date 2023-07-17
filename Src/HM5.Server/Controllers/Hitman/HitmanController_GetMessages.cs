using HM5.Server.Attributes;
using HM5.Server.Enums;
using HM5.Server.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    /**
     * Invoke:
     * - ZMessageManager::GetOnlineMessages @ 008D5730
     * - ZMessageManager::GetNewOnlineMessages @ 005EE400
     * Callback:
     * - ZMessageManager::OnGetMessagesComplete @ 9D8CF0
     * - ZMessageManager::OnGetNewMessagesComplete @ 00961A30
     * ReturnType: ZOFeed
     */
    public partial class HitmanController
    {
        [EdmFunctionImport(
            "GetMessages",
            HttpMethods.GET,
            $"Collection({SchemaNamespace}.Message)"
        )]
        public class GetMessagesRequest : IEdmFunctionImport
        {
            [NormalizedString]
            [SFunctionParameter("userId", EdmTypes.String)]
            public string UserId { get; set; }

            [SFunctionParameter("tabgroup", EdmTypes.Int32)]
            public int TabGroup { get; set; }

            [NormalizedString]
            [SFunctionParameter("languageId", EdmTypes.String)]
            public string LanguageId { get; set; }

            [SFunctionParameter("skip", EdmTypes.Int32)]
            public int Skip { get; set; }

            [SFunctionParameter("limit", EdmTypes.Int32)]
            public int Limit { get; set; }
        }

        [HttpGet]
        [Route("GetMessages")]
        public IActionResult GetMessages([FromQuery] GetMessagesRequest request)
        {
            return JsonFeedResponse(_hitmanServer.GetMessages(request));
        }
    }
}
