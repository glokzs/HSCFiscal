using System.IO;
using HSCFiscalRegistrar.Directories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HSCFiscalRegistrar.Controllers
{
    [Route("api/references/[controller]")]
    public class RefUnits : Controller
    {
        [HttpPost]
        public IActionResult Post()
        {
            var obj = JsonConvert.DeserializeObject<Unit>(System.IO.File.ReadAllText(@"Directories\ReferenceUnits.json"));
            return Ok(JsonConvert.SerializeObject(obj));
        }
        
    }
}