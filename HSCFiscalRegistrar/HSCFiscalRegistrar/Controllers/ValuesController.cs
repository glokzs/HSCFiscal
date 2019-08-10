using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using HSCFiscalRegistrar.RequestModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HSCFiscalRegistrar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var queryString = Request.QueryString;
            return new string[] {"value1", "value2"};
        }
        
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
