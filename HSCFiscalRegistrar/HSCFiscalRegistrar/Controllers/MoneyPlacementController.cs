using System.Threading.Tasks;
using Flurl.Http;
using HSCFiscalRegistrar.DTO.RequestForHSC.MoneyPlacement;
using HSCFiscalRegistrar.Services;
using Microsoft.AspNetCore.Mvc;

namespace HSCFiscalRegistrar.Controllers
{
    [Route("api/[controller]")]
    public class MoneyPlacementController : Controller
    {
        [HttpPost]
        public async Task<dynamic> Post([FromBody] MoneyPlacementOperationRequest moneyPlacementRequest)
        {
            return await HttpService.Post(moneyPlacementRequest);
        }
    }
}