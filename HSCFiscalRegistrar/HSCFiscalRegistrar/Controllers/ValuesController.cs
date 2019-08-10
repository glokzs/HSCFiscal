using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flurl.Http;
using HSCFiscalRegistrar.Enums;
using HSCFiscalRegistrar.Models;
using Microsoft.AspNetCore.Mvc;

namespace HSCFiscalRegistrar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public async Task <IActionResult> Get()
        {
            MoneyPlacementRequest moneyPlacementRequest = new MoneyPlacementRequest
            {
                DateTime = DateTime.Now,
                FrShiftNumber = 1,
                Operation = MoneyPlacementEnum.MoneyPlacementDeposit,
                Sum = new Money
                {
                    Bills = 0,
                    Coins = 80000
                }
            };
            await "http://52.38.152.232:8082".PostJsonAsync(moneyPlacementRequest);
            return new string[] { "value1", "value2" };
            
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
