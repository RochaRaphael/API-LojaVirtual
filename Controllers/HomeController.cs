using Microsoft.AspNetCore.Mvc;

namespace API_LojaVirtual.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok("A API está ok!");
        }
    }
}
