using HSCFiscalRegistrar.DTO.Cashboxes;
using Microsoft.AspNetCore.Mvc;
using Data = HSCFiscalRegistrar.DTO.Data.Data;

namespace HSCFiscalRegistrar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashboxesController : Controller
    {
        [HttpGet]

        public JsonResult Get([FromBody]Data data)
        {
            DTO.Cashboxes.Data cashboxModel = new DTO.Cashboxes.Data
            {
                List =
                {
                    new List
                    {
                        UniqueNumber = "SWK00030767",
                        RegistrationNumber = "240820180008",
                        IdentificationNumber = "2405",
                        Name = "Касса - 212408",
                        IsOffline = false,
                        CurrentStatus = 1,
                        Shift = 59
                    }
                }
            };

            return Json(cashboxModel);
        }
    }
}