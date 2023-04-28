using HM5.Server.Attributes;
using HM5.Server.Enums;
using HM5.Server.Interfaces;
using Microsoft.AspNetCore.Mvc;

//TODO: ...
namespace HM5.Server.Controllers.Hitman
{
    /**
     * Invoke:
     * - ZMessageManager::SendMessageToSelf @ 005B5A20
     * - ZMessageManager::SendMessageToUsersFriends @ 0073AB00
     * Callback: None
     */
    public partial class HitmanController
    {
        [EdmFunctionImport("SendTemplatedMessage", HttpMethods.GET, null)]
        public class SendTemplatedMessageRequest : IEdmFunctionImport
        {
            [NormalizedString]
            [SFunctionParameter("fromId", EdmTypes.String)]
            public string FromId { get; set; }

            [NormalizedString]
            [SFunctionParameter("toUserId", EdmTypes.String)]
            public string ToUserId { get; set; }

            [SFunctionParameter("tabgroup", EdmTypes.Int32)]
            public int TabGroup { get; set; }

            [SFunctionParameter("category", EdmTypes.Int32)]
            public int Category { get; set; }

            [SFunctionParameter("templateId", EdmTypes.Int32)]
            public int TemplateId { get; set; }

            [NormalizedString]
            [SFunctionParameter("data", EdmTypes.String)]
            public string Data { get; set; }
        }

        [HttpGet]
        [Route("SendTemplatedMessage")]
        public IActionResult SendTemplatedMessage([FromQuery] SendTemplatedMessageRequest request)
        {
            //NOTE: toUserId will be "----Friends----" if it's called from SendMessageToUsersFriends
            //NOTE: tabgroup will be "1" if it's called from SendMessageToSelf
            //NOTE: data might contain data that needs additional parsing
            return Ok();
        }
    }
}
