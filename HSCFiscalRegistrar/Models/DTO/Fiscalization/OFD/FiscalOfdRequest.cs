using System.Collections.Generic;
using Models.DTO.DateAndTime;
using Models.DTO.Fiscalization.KKM;
using Models.DTO.RequestOfd;
using Models.DTO.RequestOperatorOfd;
using Models.Enums;
using Newtonsoft.Json;

namespace Models.DTO.Fiscalization.OFD
{
    public class FiscalOfdRequest
    {
        [JsonProperty("Command")]
        public CommandTypeEnum Command { get; set; }
        [JsonProperty("DeviceId")]
        public int DeviceId { get; set; }
        [JsonProperty("ReqNum")]
        public int ReqNum { get; set; }
        [JsonProperty("Token")]
        public int Token { get; set; }
        [JsonProperty("Service")]
        public Service Service { get; set; }
        [JsonProperty("Ticket")]
        public Ticket Ticket { get; set; }

        public FiscalOfdRequest()
        {
        }

        public FiscalOfdRequest(Operation operation, CheckOperationRequest checkOperationRequest, Kkm kkm, Org org)
        {
            Command = CommandTypeEnum.COMMAND_TICKET;
            Token = kkm.OfdToken;
            Service = new Service(new RegInfo(org, GetKkm(kkm)));
            DeviceId = kkm.DeviceId;
            ReqNum = kkm.ReqNum + 15;
            Ticket = new Ticket
            {
                Operation = operation.Type,
                Operator = new Operator
                {
                    Code = operation.User.OperatorCode,
                    Name = operation.User.UserName
                },
                DateTime = GetDateTime(operation),
                Payments = GetPayments(checkOperationRequest),
                Items = GetItems(checkOperationRequest),
                Amounts = new Amount()
                {
                    Total = new Sum()
                    {
                        Bills = operation.Amount,
                        Coins = 0
                    }
                },
                Domain = new Domain
                {
                    Type = 0
                },
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
         
         private OfdKkm GetKkm(Kkm kkm)
         {
             return new OfdKkm
             {
                 FnsKkmId = kkm.FnsKkmId,
                 PointOfPaymentNumber = kkm.PointOfPayment,
                 SerialNumber = kkm.SerialNumber,
                 TerminalNumber = kkm.TerminalNumber
             };
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

        private DateTime GetDateTime(Operation operation)
        {
            var date = operation.CreationDate;
            return new DateTime()
            {
                Date = new Date
                {
                    Day = date.Day,
                    Month = date.Month,
                    Year = date.Year
                },
                Time = new Time
                {
                    Hour = date.Hour,
                    Minute = date.Minute,
                    Second = date.Second
                }
            };
        }
    }
}