using System;
using System.Collections.Generic;
using HSCFiscalRegistrar.DTO.Cashboxes;
using HSCFiscalRegistrar.Helpers;
using HSCFiscalRegistrar.Models;
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
        private readonly ApplicationContext _context;
        private readonly TokenValidationHelper _helper;
        public CashboxesController(UserManager<User> userManager, TokenValidationHelper helper)
        {
            _userManager = userManager;
            _helper = _helper;
        }
        
        [HttpPost]
        public  ActionResult Get([FromBody] DtoToken dtoToken)
        {
            try
            {
                try
                {
                    var error = _helper.TokenValidator(_context, dtoToken.Token);
                    return error == null ? GetCashBoxesData(JsonConvert.SerializeObject() : throw error;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return "ERROR";
                }
                
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        private string GetCashBoxesData()
        {
            Wrapper wrapper = new Wrapper
            {
                Data = new Data
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