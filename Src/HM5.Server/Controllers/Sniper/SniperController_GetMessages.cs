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
            return JsonFeedResponse(new List<SniperMessage>
            {
                new()
                {
                    Id = 5000,
                    FromId = "76561198161220058",
                    Category = 1,
                    TextTemplateId = 0,
                    TemplateData = "Heya!",
                    TimestampUTC = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
                },
                new()
                {
                    Id = 5001,
                    FromId = "76561198161220058",
                    Category = 1,
                    TextTemplateId = 0,
                    TemplateData = "Heya {userid}!",
                    TimestampUTC = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
                }
            });
        }
    }
}
