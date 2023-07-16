using HM5.Server.Attributes;
using HM5.Server.Enums;
using HM5.Server.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    /**
     * Invoke: ZContractManager::GetUserWallet @ 00525090
     * Callback: ZContractManager::GetUserWalletCallback @ 008BBBC0
     * ReturnType: ZOServiceOperationResult
     */
    public partial class HitmanController
    {
        [EdmFunctionImport(
            "GetUserWallet",
            HttpMethods.GET,
            null
        )]
        public class GetUserWalletRequest : IEdmFunctionImport
        {
            [NormalizedString]
            [SFunctionParameter("userId", EdmTypes.String)]
            public string UserId { get; set; }
        }

        [HttpGet]
        [Route("GetUserWallet")]
        public IActionResult GetUserWallet([FromQuery] GetUserWalletRequest request)
        {
            return JsonOperationValueResponse(1_999_999);
        }
    }
}
