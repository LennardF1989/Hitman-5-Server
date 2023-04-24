using HM5.Server.Enums;
using HM5.Server.Models.Base;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Sniper
{
    /**
     * Invoke:
     * - ZMessageManager::SendMessageToUsersFriends @ 007FF900
     * - ZMessageManager::SendMessageToSelf @ 007FFCC0
     * Callback: None
     */
    public partial class SniperController
    {
        private static readonly EdmFunctionImport _sendTemplatedMessage = new()
        {
            Name = "SendTemplatedMessage",
            HttpMethod = HttpMethods.GET,
            ReturnType = null,
            Parameters = new List<SFunctionParameter>
            {
                new()
                {
                    Name = "fromId",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "toUserId",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "tabgroup",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "category",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "templateId",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "data",
                    Type = EdmTypes.String
                }
            }
        };

        [HttpGet]
        [Route("SendTemplatedMessage")]
        public IActionResult SendTemplatedMessage()
        {
            //NOTE: toUserId will be "----Friends----" if it's called from SendMessageToUsersFriends
            //NOTE: tabgroup will be "1" if it's called from SendMessageToSelf
            //NOTE: data might contain data that needs additional parsing
            return Ok();
        }
    }
}
