using HM5.Server.Attributes;
using HM5.Server.Enums;
using HM5.Server.Interfaces;
using HM5.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Sniper
{
    /**
     * Invoke:
     * - ZMessageManager::GetOnlineMessages @ 00800AA00
     * - ZMessageManager::GetNewOnlineMessages @ 00800E60
     * Callback:
     * - ZMessageManager::OnGetMessagesComplete @ 00800780
     * - ZMessageManager::OnGetNewMessagesComplete @ 008009F0
     * ReturnType: ZOFeed
     */
    public partial class SniperController
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
            var templateData = "Diana, she..." +
                              "|||" +
                              "Always talks about him.<BR><BR>Way back when they first worked together.";

            var messages = Enum
                .GetValues<EMessageCategory>()
                .Skip(request.Skip)
                .Take(request.Limit)
                .Select((x, i) => new SniperMessage
                {
                    Id = 5000 + i,
                    Category = x,
                    FromId = "LennardF1989",
                    TextTemplateId = 0,
                    TemplateData = templateData,
                    TimestampUTC = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
                })
                .ToList();

            return JsonFeedResponse(messages);
        }
    }
}
