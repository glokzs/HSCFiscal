using System.Threading.Tasks;
using Flurl.Http;
using HSCFiscalRegistrar.RequestModels;
using HSCFiscalRegistrar.Services;
using Microsoft.AspNetCore.Mvc;

namespace HSCFiscalRegistrar.Controllers
{
    [Route("api/[controller]")]
    public class MoneyPlacementController : Controller
    {     
        [HttpPost]
        public async Task<dynamic> Post([FromBody] MoneyPlacementRequest moneyPlacementRequest)
        {
            var res = await HttpService.Post(moneyPlacementRequest);
            LogWriteService.LogWrite(res);
            return res;
        }
    }
}