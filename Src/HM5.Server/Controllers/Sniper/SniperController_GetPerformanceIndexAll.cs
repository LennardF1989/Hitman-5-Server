using HM5.Server.Enums;
using HM5.Server.Models.Base;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Sniper
{
    /**
     * Invoke: ZUnknown::GetPerformanceIndexAll @ 0080E890
     * Callback: ZUnknown::GetPerformanceIndexAllCallback @ 0080E4B0
     * ReturnType: ZOServiceOperationResult
     */
    public partial class SniperController
    {
        private static readonly EdmFunctionImport _getPerformanceIndexAll = new()
        {
            Name = "GetPerformanceIndexAll",
            HttpMethod = HttpMethods.GET,
            ReturnType = null,
            Parameters = new List<SFunctionParameter>
            {
                new()
                {
                    Name = "leaderboardid",
                    Type = EdmTypes.String
                },
                new()
                {
                    Name = "userid",
                    Type = EdmTypes.String
                }
            }
        };

        [HttpGet]
        [Route("GetPerformanceIndexAll")]
        public IActionResult GetPerformanceIndexAll()
        {
            //NOTE: Different performance percentages are at: 0, 0.55, 0.65, 0.75 and 1
            return JsonOperationListResponse(new List<float>
            {
                1, //Global
                0.65f, //Global percentage
                1, //National
                0.55f, //National percentage
                1, //Friends
                0.75f //Friends percentage
            });
        }
    }
}
