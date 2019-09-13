using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HSCFiscalRegistrar.DTO.DateAndTime;
using HSCFiscalRegistrar.DTO.Fiscalization.KKM;
using HSCFiscalRegistrar.DTO.Fiscalization.OFD;
using HSCFiscalRegistrar.Enums;
using HSCFiscalRegistrar.Models;
using HSCFiscalRegistrar.Models.APKInfo;
using HSCFiscalRegistrar.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using DateTime = HSCFiscalRegistrar.DTO.DateAndTime.DateTime;

namespace HSCFiscalRegistrar.Controllers
{
    [Route("api/[controller]")]
    public class CheckController : Controller
    {
        private ApplicationContext _applicationContext;
        private UserManager<User> _userManager;

        public CheckController(ApplicationContext applicationContext, UserManager<User> userManager)
        {
            _applicationContext = applicationContext;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CheckOperationRequest checkOperationRequest)
        {
            var items = GetItems(checkOperationRequest);

            var payments = GetPayments(checkOperationRequest);
            var fiscalOfdRequest = new FiscalOfdRequest()
            {
                Request = _applicationContext.Requests.FirstOrDefault(r => r.Id == "7"),
                Ticket = new Ticket()
                {
                    Operation = checkOperationRequest.OperationType,
                    DateTime = GetDateTime(),
                    Amounts = new Amount(),
                    Payments = payments,
                    Items = items
                }
            };
            var resp = await HttpService.Post(fiscalOfdRequest);
            return Ok(JsonConvert.SerializeObject(resp));
        }

        private List<Item> GetItems(CheckOperationRequest checkOperationRequest)
        {
            var items = new List<Item>();
            foreach (var positionType in checkOperationRequest.Positions)
            {
                items.Add(new Item()
                    {
                        Commodity = new Commodity()
                        {
                            Quantity = (int) positionType.Count,
                            Name = positionType.PositionName,
                            Code = positionType.UnitCode,
                            Sum = new Sum()
                            {
                                Bills = positionType.Price,
                                Coins = 0
                            },
                            Price = new Sum()
                            {
                                Bills = positionType.Price * (int) positionType.Count,
                                Coins = 0
                            },
                            SectionCode = positionType.PositionCode,
                            Taxes = new List<Tax>()
                        }
                    });
            }

            return items;
        }

        private List<Payment> GetPayments(CheckOperationRequest checkOperationRequest)
        {
            List<Payment> payments = new List<Payment>();
            foreach (var paymentsType in checkOperationRequest.Payments)
            {
                payments.Add(new Payment()
                {
                    Sum = new Sum()
                    {
                        Bills = paymentsType.Sum,
                        Coins = 0
                    },
                    Type = paymentsType.PaymentType
                });
            }

            return payments;
        }

        private DateTime GetDateTime()
        {
            System.DateTime now = System.DateTime.Now;
            return new DateTime()
            {
                Date = new Date()
                {
                    Day = now.Day,
                    Month = now.Month,
                    Year = now.Year
                },
                Time = new Time()
                {
                    Hour = now.Hour,
                    Minute = now.Minute,
                    Second = now.Second
                }
            };
        }
    }
}