using System.Threading.Tasks;
using Flurl.Http;
using HSCFiscalRegistrar.DTO.RequestModels;
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
            return await HttpService.Post(moneyPlacementRequest);
        }
    }
}