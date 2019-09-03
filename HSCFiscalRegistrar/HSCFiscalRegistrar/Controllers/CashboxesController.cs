using System.Collections.Generic;
using HSCFiscalRegistrar.DTO.Cashboxes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Data = HSCFiscalRegistrar.DTO.Data.Data;

namespace HSCFiscalRegistrar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CashboxesController : Controller
    {
        [HttpPost]
        public OkObjectResult Get([FromBody] Data data)
        {
            Wrapper wrapper = new Wrapper
            {
                Data = new DTO.Cashboxes.Data
                {
                    List = new List<List>
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
                }

            };


            return Ok(JsonConvert.SerializeObject(wrapper));
        }
    }
}