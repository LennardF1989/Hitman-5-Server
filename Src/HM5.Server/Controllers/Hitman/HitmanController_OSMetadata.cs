using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    public partial class HitmanController
    {
        [HttpGet]
        [Route("$os_metadata")]
        public IActionResult Metadata()
        {
            return JsonGenericResponse(_metadataService.GetMetadata());
        }
    }
}
