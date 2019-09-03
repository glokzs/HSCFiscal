using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HSCFiscalRegistrar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ForAuthController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Im Super User");
        }
    }
}