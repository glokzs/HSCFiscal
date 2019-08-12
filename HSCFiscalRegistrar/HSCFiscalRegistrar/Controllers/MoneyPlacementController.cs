using System.Threading.Tasks;
using Flurl.Http;
using HSCFiscalRegistrar.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace HSCFiscalRegistrar.Controllers
{
    [Route("api/[controller]")]
    public class MoneyPlacementController : Controller
    {
        [HttpPost]
        public async Task<dynamic> Post([FromBody] MoneyPlacementRequest moneyPlacementRequest)
        {
            string url = "http://52.38.152.232:8082";
            return await url.PostJsonAsync(moneyPlacementRequest).ReceiveJson();
        }
    }
}