using System.Threading.Tasks;
using HSCFiscalRegistrar.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace HSCFiscalRegistrar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : Controller
    {
        
        [HttpPost]
        public async Task<JsonResult> Post([FromBody] Kkm kkm)
        {
            string json = JsonConvert.SerializeObject(kkm, Formatting.Indented);
            
            return Json(json);
        }
    }
}