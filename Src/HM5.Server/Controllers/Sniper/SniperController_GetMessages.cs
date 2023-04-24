using HM5.Server.Enums;
using HM5.Server.Models;
using HM5.Server.Models.Base;
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
        private static readonly EdmFunctionImport _getMessages = new()
        {
            Name = "GetMessages",
            HttpMethod = HttpMethods.GET,
            ReturnType = $"Collection({SchemaNamespace}.Message)",
            Parameters = new List<SFunctionParameter>
            {
                new()
                {
                    Name = "userId",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "tabgroup",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "languageId",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "skip",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "limit",
                    Type = EdmTypes.String
                }
            }
        };

        [HttpGet]
        [Route("GetMessages")]
        public IActionResult GetMessages()
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
