using HM5.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    public partial class HitmanController
    {
        [HttpGet]
        [Route("os_getStatus")]
        public IActionResult GetStatus()
        {
            return JsonGenericResponse(new OSGetStatus
            {
                ClientIP = "127.0.0.1"
            });
        }
    }
}
