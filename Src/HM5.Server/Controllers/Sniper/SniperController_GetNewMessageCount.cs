using HM5.Server.Enums;
using HM5.Server.Models.Base;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Sniper
{
    /**
     * Invoke: ZMessageManager::Update @ 00801320
     * Callback: ZMessageManager::OnGetNewMessageCountComplete @ 008011F0
     * ReturnType: ZOServiceOperationResult
     */
    public partial class SniperController
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
            //NOTE: GetNewMessageCount doesn't care for the name of the Key
            return JsonOperationValueResponse(10);
        }
    }
}
