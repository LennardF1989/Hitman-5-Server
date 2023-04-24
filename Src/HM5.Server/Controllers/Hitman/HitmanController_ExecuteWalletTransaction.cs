using HM5.Server.Enums;
using HM5.Server.Models.Base;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    /**
     * Invoke: ZContractManager::ExecuteWalletTransactionAsync @ 00684EF0
     * Callback: ZContractManager::ExecuteWalletTransactionAsyncCallback @ 005E88A0
     * ReturnType: ZOServiceOperationResult
     */
    public partial class HitmanController
    {
        private static readonly EdmFunctionImport _executeWalletTransaction = new()
        {
            Name = "ExecuteWalletTransaction",
            HttpMethod = HttpMethods.GET,
            ReturnType = null,
            Parameters = new List<SFunctionParameter>
            {
                new ()
                {
                    Name = "amount",
                    Type = EdmTypes.String
                },
                new ()
                {
                    Name = "userId",
                    Type = EdmTypes.String
                },
                new ()
                {
                    Name = "tokenId",
                    Type = EdmTypes.String
                },
                new ()
                {
                    Name = "subId",
                    Type = EdmTypes.String
                },
                new ()
                {
                    Name = "level",
                    Type = EdmTypes.String
                }
            }
        };

        [HttpGet]
        [Route("ExecuteWalletTransaction")]
        public IActionResult ExecuteWalletTransaction()
        {
            //NOTE: Appears to be the new WalletAmount left
            return JsonOperationValueResponse(101);
        }
    }
}
