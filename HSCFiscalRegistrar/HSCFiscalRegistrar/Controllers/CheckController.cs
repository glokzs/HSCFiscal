using System;
using System.Threading.Tasks;
using HSCFiscalRegistrar.DTO.Fiscalization.KKM;
using HSCFiscalRegistrar.Models;
using HSCFiscalRegistrar.Models.APKInfo;
using HSCFiscalRegistrar.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HSCFiscalRegistrar.Controllers
{
    [Route("api/[controller]")]
    public class CheckController : Controller
    {

        private ApplicationContext _applicationContext;
        
        public CheckController(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
    
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CheckOperationRequest checkOperationRequest)
        {
            await HttpService.Post(checkOperationRequest);
            return Ok();
        }
    }
}