using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HSCFiscalRegistrar.DTO.DateAndTime;
using HSCFiscalRegistrar.DTO.Fiscalization.KKM;
using HSCFiscalRegistrar.DTO.Fiscalization.OFD;
using HSCFiscalRegistrar.Enums;
using HSCFiscalRegistrar.Models;
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
            var request = _applicationContext.Requests.FirstOrDefault(r => r.Id == "7");
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
                    Amounts = new Amount()
                    {
                        Total = new Sum()
                        {
                            Bills = 100,
                            Coins = 0
                        }
                    },
                    Payments = GetPayments(checkOperationRequest),
                    Items = GetItems(checkOperationRequest),
                    Domain = new Domain
                    {
                        Type = 0
                    }
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
                items.Add(GetItem(positionType));
            }

            return items;
        }

        private static Item GetItem(PositionType positionType)
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

        private static StornoDiscount GetStornoDiscount()
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

        private static Discount GetDiscount()
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

        private static StornoMarkup GetStornoMarkup()
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

        private static Markup GetMarkup()
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

        private static StornoCommodity GetStornoCommodity(PositionType positionType)
        {
            return new StornoCommodity
            {
                Quantity = (int) positionType.Count,
                Name = positionType.PositionName,
                Sum = new Sum
                {
                    Bills = positionType.Price,
                    Coins = 0
                },
                Price = new Sum
                {
                    Bills = positionType.Price * (int) positionType.Count,
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

        private static Commodity GetCommodity(PositionType positionType)
        {
            return new Commodity
            {
                Quantity = (int) positionType.Count,
                Name = positionType.PositionName,
                Code = positionType.UnitCode,
                Sum = new Sum
                {
                    Bills = positionType.Price,
                    Coins = 0
                },
                Price = new Sum
                {
                    Bills = positionType.Price * (int) positionType.Count,
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
    }
}