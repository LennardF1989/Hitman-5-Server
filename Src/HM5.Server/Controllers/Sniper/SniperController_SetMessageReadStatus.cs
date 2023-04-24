using HM5.Server.Enums;
using HM5.Server.Models.Base;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Sniper
{
    /**
     * Invoke: ZMessageManager::MarkMessageAsRead @ 00800010
     * Callback: None
     */
    public partial class SniperController
    {
        private static readonly EdmFunctionImport _setMessageReadStatus = new()
        {
            Name = "SetMessageReadStatus",
            HttpMethod = HttpMethods.GET,
            ReturnType = null,
            Parameters = new List<SFunctionParameter>
            {
                new()
                {
                    Name = "messageId",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "isRead",
                    Type = EdmTypes.String
                }
            }
        };

        [HttpGet]
        [Route("SetMessageReadStatus")]
        public IActionResult SetMessageReadStatus()
        {
            //NOTE: isRead will always be set to "true"
            return Ok();
        }
    }
}
