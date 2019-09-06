using System.Collections.Generic;
using System.Threading.Tasks;
using HSCFiscalRegistrar.DTO.Cashboxes;
using HSCFiscalRegistrar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HSCFiscalRegistrar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashboxesController : Controller
    {
        private static UserManager<User> _userManager;
        public CashboxesController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        
        [HttpPost]
        public  ActionResult Get([FromBody] DtoToken dtoToken)
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