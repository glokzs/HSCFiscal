using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HSCFiscalRegistrar.DTO.DateAndTime;
using HSCFiscalRegistrar.DTO.Fiscalization;
using HSCFiscalRegistrar.DTO.Fiscalization.KKM;
using HSCFiscalRegistrar.DTO.Fiscalization.OFD;
using HSCFiscalRegistrar.DTO.Fiscalization.OFDResponce;
using HSCFiscalRegistrar.Enums;
using HSCFiscalRegistrar.Models;
using HSCFiscalRegistrar.Models.APKInfo;
using HSCFiscalRegistrar.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using DateTime = HSCFiscalRegistrar.DTO.DateAndTime.DateTime;
using Ticket = HSCFiscalRegistrar.DTO.Fiscalization.OFD.Ticket;

namespace HSCFiscalRegistrar.Controllers
{
    [Route("api/[controller]")]
    public class CheckController : Controller
    {
        private readonly ApplicationContext _applicationContext;
        private UserManager<User> _userManager;

        public CheckController(ApplicationContext applicationContext, UserManager<User> userManager)
        {
            _applicationContext = applicationContext;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CheckOperationRequest checkOperationRequest)
        {
            decimal sum = 0;
            foreach (var paymentsType in checkOperationRequest.Payments)
            {
                sum += paymentsType.Sum;
            }
            var request = _applicationContext.Requests.FirstOrDefault(r => r.Id == "7");
            if (request != null)
            {
                var fiscalOfdRequest = new FiscalOfdRequest
                {
                    Command = 1,
                    Token = request.Token,
                    DeviceId = request.DeviceId,
                    ReqNum = request.ReqNum,
                    Service = request.Service,
                    Ticket = new Ticket
                    {
                        Operation = checkOperationRequest.OperationType,
                        Operator = new Operator()
                        {
                            Code = 1,
                            Name = "OperName"
                        },
                        DateTime = GetDateTime(),
                        Payments = GetPayments(checkOperationRequest),
                        Items = GetItems(checkOperationRequest),
                        Amounts = new Amount()
                        {
                            Total = new Sum()
                            {
                                Bills = sum,
                                Coins = 0
                            }
                        },
                        Domain = new Domain
                        {
                            Type = 0
                        }
                    }
                };
                var resp = await HttpService.Post(fiscalOfdRequest);
                var ofdResp = GetOfdResponse(ref resp);
                var kkmResponse = new KkmResponse
                {
                    Data = new Data
                        {
                            DateTime = System.DateTime.Now.Date,
                            CheckNumber = ofdResp.Ticket.TicketNumber,
                            OfflineMode = false,
                            Cashbox = GetCashbox(checkOperationRequest),
                            CashboxOfflineMode = false,
                            CheckOrderNumber = request.ReqNum,
                            ShiftNumber = 54,
                            EmployeeName = fiscalOfdRequest.Ticket.Operator.Name,
                            TicketUrl = ofdResp.Ticket.QrCode,
                    
                        },
                };
                await UpdateDatabaseFields(request, ofdResp);
                return Ok(JsonConvert.SerializeObject(kkmResponse));
            }

            return NotFound();
        }
        
        private Cashbox GetCashbox(CheckOperationRequest checkOperationRequest)
        {
            return new Cashbox
            {
                UniqueNumber = checkOperationRequest.CashboxUniqueNumber,
                RegistrationNumber = "240820180008",
                IdentityNumber = "2405",
                Address = "asana"
            };
        }

        private List<Item> GetItems(CheckOperationRequest checkOperationRequest)
        {
            var items = new List<Item>();
            foreach (var positionType in checkOperationRequest.Positions)
            {
                items.Add(GetItem(positionType));
            }

            return items;
        }

        private Item GetItem(PositionType positionType)
        {
            return new Item
            {
                Type = ItemTypeEnum.ITEM_TYPE_COMMODITY,
                Commodity = GetCommodity(positionType),
                StornoCommodity = GetStornoCommodity(positionType),
                Markup = GetMarkup(),
                StornoMarkup = GetStornoMarkup(),
                Discount = GetDiscount(),
                StornoDiscount = GetStornoDiscount()
            };
        }

        private StornoDiscount GetStornoDiscount()
        {
            return new StornoDiscount
            {
                Name = "отмена скидки",
                Sum = new Sum
                {
                    Bills = 5,
                    Coins = 10
                },
                Taxes = new List<Tax>
                {
                    new Tax
                    {
                        Type = 0,
                        TaxationType = 0,
                        Percent = 12,
                        Sum = new Sum
                        {
                            Bills = 5,
                            Coins = 10
                        },
                        IsInTotalSum = true
                    }
                }
            };
        }

        private Discount GetDiscount()
        {
            return new Discount
            {
                Name = "скидка",
                Sum = new Sum
                {
                    Bills = 5,
                    Coins = 10
                },
                Taxes = new List<Tax>
                {
                    new Tax
                    {
                        Type = 0,
                        TaxationType = 0,
                        Percent = 12,
                        Sum = new Sum
                        {
                            Bills = 5,
                            Coins = 10
                        },
                        IsInTotalSum = true
                    }
                }
            };
        }

        private StornoMarkup GetStornoMarkup()
        {
            return new StornoMarkup
            {
                Name = "отмена наценки",
                Sum = new Sum()
                {
                    Bills = 5,
                    Coins = 10
                },
                Taxes = new List<Tax>
                {
                    new Tax
                    {
                        Type = 0,
                        TaxationType = 0,
                        Percent = 12,
                        Sum = new Sum
                        {
                            Bills = 5,
                            Coins = 10
                        },
                        IsInTotalSum = true
                    }
                }
            };
        }

        private Markup GetMarkup()
        {
            return new Markup
            {
                Name = "наценка",
                Sum = new Sum
                {
                    Bills = 5,
                    Coins = 10
                },
                Taxes = new List<Tax>
                {
                    new Tax
                    {
                        Type = 0,
                        TaxationType = 0,
                        Percent = 12,
                        Sum = new Sum
                        {
                            Bills = 5,
                            Coins = 10
                        },
                        IsInTotalSum = true
                    }
                }
            };
        }

        private StornoCommodity GetStornoCommodity(PositionType positionType)
        {
            return new StornoCommodity
            {
                Quantity = (int) positionType.Count,
                Name = positionType.PositionName,
                Sum = new Sum
                {
                    Bills = positionType.Price * (int)positionType.Count,
                    Coins = 0
                },
                Price = new Sum
                {
                    Bills = positionType.Price,
                    Coins = 0
                },
                SectionCode = positionType.PositionCode,
                Taxes = new List<Tax>
                {
                    new Tax
                    {
                        Type = 0,
                        TaxationType = 0,
                        Percent = 12,
                        Sum = new Sum
                        {
                            Bills = 5,
                            Coins = 10
                        },
                        IsInTotalSum = true
                    },
                    new Tax
                    {
                        Type = 0,
                        TaxationType = 0,
                        Percent = 12,
                        Sum = new Sum
                        {
                            Bills = 1,
                            Coins = 10
                        },
                        IsInTotalSum = true
                    }
                }
            };
        }

        private Commodity GetCommodity(PositionType positionType)
        {
            return new Commodity
            {
                Quantity = (int) positionType.Count,
                Name = positionType.PositionName,
                Code = positionType.UnitCode,
                Sum = new Sum
                {
                    Bills = positionType.Price * (int)positionType.Count,
                    Coins = 0
                },
                Price = new Sum
                {
                    Bills = positionType.Price,
                    Coins = 0
                },
                SectionCode = positionType.PositionCode,
                Taxes = new List<Tax>
                {
                    new Tax
                    {
                        Type = 0,
                        TaxationType = 0,
                        Percent = 12,
                        Sum = new Sum
                        {
                            Bills = 5,
                            Coins = 10
                        },
                        IsInTotalSum = true
                    },
                    new Tax
                    {
                        Type = 0,
                        TaxationType = 0,
                        Percent = 12,
                        Sum = new Sum
                        {
                            Bills = 1,
                            Coins = 10
                        },
                        IsInTotalSum = true
                    }
                }
            };
        }

        private List<Payment> GetPayments(CheckOperationRequest checkOperationRequest)
        {
            List<Payment> payments = new List<Payment>();
            foreach (var paymentsType in checkOperationRequest.Payments)
            {
                payments.Add(new Payment
                {
                    Sum = new Sum
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
            return new DateTime
            {
                Date = new Date
                {
                    Day = now.Day,
                    Month = now.Month,
                    Year = now.Year
                },
                Time = new Time
                {
                    Hour = now.Hour,
                    Minute = now.Minute,
                    Second = now.Second
                }
            };
        }

        private async Task UpdateDatabaseFields(Request request, Response ofdResp)
        {
            request.ReqNum += 1;
            request.Token = ofdResp.Token;
            _applicationContext.Update(request);
            await _applicationContext.SaveChangesAsync();
        }

        private Response GetOfdResponse(ref dynamic resp)
        {
            resp = JsonConvert.SerializeObject(resp);
            Response ofdResp = JsonConvert.DeserializeObject<Response>(resp);
            return ofdResp;
        }
    }
}