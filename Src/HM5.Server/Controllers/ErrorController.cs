using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers
{
    public class ErrorController : Controller
    {
        [Route("{*url}")]
        public IActionResult CatchAll()
        {
            return NotFound();
        }
    }
}
