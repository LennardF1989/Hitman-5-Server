using HM5.Server.Enums;
using HM5.Server.Models;
using HM5.Server.Models.Base;
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
            return JsonFeedResponse(new List<Message>
            {
                new()
                {
                    Id = 5000,
                    FromId = "76561198161220058",
                    IsRead = false,
                    TextTemplateId = 0,
                    TemplateData = "Heya!",
                    TimestampUTC = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
                },
                new()
                {
                    Id = 5001,
                    FromId = "76561198161220058",
                    IsRead = true,
                    TextTemplateId = 0,
                    TemplateData = "Heya {userid}!",
                    TimestampUTC = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
                }
            });
        }
    }
}
