using HM5.Server.Enums;
using HM5.Server.Models.Base;
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
        private static readonly EdmFunctionImport _getUserWallet = new()
        {
            Name = "GetUserWallet",
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
        [Route("GetUserWallet")]
        public IActionResult GetUserWallet()
        {
            return JsonOperationValueResponse(1_000_000);
        }
    }
}
