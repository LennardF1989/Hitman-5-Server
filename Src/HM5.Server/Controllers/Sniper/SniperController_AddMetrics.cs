using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HM5.Server.Controllers.Sniper
{
    public partial class SniperController
    {
        [HttpPost]
        [Route("AddMetrics")]
        public IActionResult AddMetrics([FromBody] JsonDocument json)
        {
            return Ok();
        }
    }
}
