using System;
using System.Collections.Generic;
using HSCFiscalRegistrar.DTO.DateAndTime;
using HSCFiscalRegistrar.DTO.Fiscalization.KKM;
using HSCFiscalRegistrar.DTO.Fiscalization.OFD;
using HSCFiscalRegistrar.Enums;
using HSCFiscalRegistrar.Models;
using HSCFiscalRegistrar.Models.APKInfo;
using HSCFiscalRegistrar.Models.Operation;
using Service = HSCFiscalRegistrar.Models.APKInfo.Service;
using Ticket = HSCFiscalRegistrar.DTO.Fiscalization.OFD.Ticket;

namespace HSCFiscalRegistrar.Services
{
    public class OfdCheckOperation
    {
        public async void OfdRequest(Operation operation, CheckOperationRequest checkOperationRequest)
        {
            var fiscalOfdRequest = new FiscalOfdRequest
            {
                Command = 1,
                Token = operation.Kkm.OfdToken,
                Service = new Service
                {
                    RegInfo = new RegInfo()
                    {
                        Kkm = operation.Kkm,
                        Org = operation.Operator.Org,
                    }
                },
                DeviceId = operation.Kkm.DeviceId,
                ReqNum = operation.Kkm.ReqNum,
                Ticket = new Ticket
                {
                    Operation = operation.Type,
                    Operator = new Operator()
                    {
                        Code = operation.Operator.Code,
                        Name = operation.Operator.Name
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
                    OfflineTicketNumber = operation.CheckNumber
                }
            }; 
           // await HttpService.Post(fiscalOfdRequest);

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

        private HSCFiscalRegistrar.DTO.DateAndTime.DateTime GetDateTime(Operation operation)
        {
            var date = operation.CreationDate;
            return new HSCFiscalRegistrar.DTO.DateAndTime.DateTime()
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