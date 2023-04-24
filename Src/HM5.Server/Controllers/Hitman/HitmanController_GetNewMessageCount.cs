using HM5.Server.Enums;
using HM5.Server.Models.Base;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    /**
     * Invoke: ZMessageManager::Update @ 0099DFA0
     * Callback: ZMessageManager::OnGetNewMessageCountComplete @ 008847F0
     * ReturnType: ZOServiceOperationResult
     */
    public partial class HitmanController
    {
        private static readonly EdmFunctionImport _getNewMessageCount = new()
        {
            Name = "GetNewMessageCount",
            HttpMethod = HttpMethods.GET,
            ReturnType = null,
            Parameters = new List<SFunctionParameter>
            {
                new()
                {
                    Name = "userId",
                    Type = EdmTypes.String
                }
            }
        };

        [HttpGet]
        [Route("GetNewMessageCount")]
        public IActionResult GetNewMessageCount()
        {
            return JsonOperationValueResponse(10);
        }
    }
}
