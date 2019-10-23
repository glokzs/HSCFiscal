using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace HSCFiscalRegistrar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
        [HttpGet]
        public string Index()
        {
            Log.Information("Serialog на старте!");
            return $"работает (╮°-°)┳┳  => не работает ( ╯°□°)╯┻┻";
        }
    }
}