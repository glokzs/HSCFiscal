using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HSCFiscalRegistrar.DTO.DateAndTime;
using HSCFiscalRegistrar.DTO.XReport;
using HSCFiscalRegistrar.DTO.XReport.KkmResponce;
using HSCFiscalRegistrar.DTO.XReport.OfdResponse;
using HSCFiscalRegistrar.Enums;
using HSCFiscalRegistrar.Models;
using HSCFiscalRegistrar.Models.APKInfo;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static HSCFiscalRegistrar.Services.HttpService;
using DateTime = System.DateTime;

namespace HSCFiscalRegistrar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XReportController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationContext _context;
        private readonly SignInManager<User> _signInManager;

        public XReportController(UserManager<User> userManager, ApplicationContext context,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
        }


        [HttpPost]
        public async Task<IActionResult> XReportResult([FromBody] KkmRequest kkmRequest)
        {
            Request request = _context.Requests.FirstOrDefault(r => r.Id == "7");
            if (request != null)
            {
                OfdRequest ofdRequest = GetOfdRequest(request);
                var response = await Post(ofdRequest);
                var ofdResponse = GetOfdResponse(ref response);
                XReportKkmResponse xReportKkmResponse = new XReportKkmResponse
                {
                    Data = new Data
                    {
                        ReportNumber = ofdResponse.ZXReport.TicketOperations.Sum(t => t.TicketsTotalCount),
                        TaxPayerName = "admin",
                        TaxPayerIN = "111140010124",
                        TaxPayerVAT = true,
                        TaxPayerVATSeria = "32132",
                        TaxPayerVATNumber = "12345",
                        CashboxSN = "SWK00030767",
                        CashboxRN = "240820180008",
                        CashboxIN = 2405,
                        StartOn = DateTime.Now,
                        ReportOn = DateTime.Now,
                        CloseOn = DateTime.Now,
                        CashierCode = 123,
                        ShiftNumber = ofdResponse.ZXReport.ShiftNumber,
                        DocumentCount = ofdResponse.ZXReport.TicketOperations.Sum(t => t.TicketsTotalCount),
                        PutMoneySum = GetPutMoneySum(ofdResponse),
                        TakeMoneySum = GetTakeMoneySum(ofdResponse),
                        ControlSum = ofdResponse.ZXReport.NonNullableSums.Sum(n => n.Sum.Bills),
                        OfflineMode = ofdRequest.Report.IsOffline,
                        CashboxOfflineMode = ofdRequest.Report.IsOffline,
                        SumInCashbox = ofdResponse.ZXReport.CashSum.Bills,
                        Sell = new OperationTypeSummaryApiModel
                        {
                            Change = 0,
                            Count = ofdResponse.ZXReport.TicketOperations
                                .Where(t => t.Operation == OperationTypeEnum.OPERATION_SELL).Sum(t => t.TicketsCount),
                            Taken = ofdResponse.ZXReport.TicketOperations
                                .Where(t => t.Operation == OperationTypeEnum.OPERATION_SELL).Sum(
                                    t => t.TicketsSum.Bills),
                            Markup = 0,
                            Discount = 0,
                            PaymentsByTypesApiModel = new List<PaymentsByTypesApiModel>(),
                            TotalCount = ofdResponse.ZXReport.TicketOperations
                                .Where(t => t.Operation == OperationTypeEnum.OPERATION_SELL).Sum(t => t.TicketsTotalCount),
                            VAT = 0
                        },
                        Buy = new OperationTypeSummaryApiModel
                        {
                            Change = 0,
                            Count = ofdResponse.ZXReport.TicketOperations
                                .Where(t => t.Operation == OperationTypeEnum.OPERATION_BUY).Sum(t => t.TicketsCount),
                            Taken = ofdResponse.ZXReport.TicketOperations
                                .Where(t => t.Operation == OperationTypeEnum.OPERATION_BUY).Sum(
                                    t => t.TicketsSum.Bills),
                            Markup = 0,
                            Discount = 0,
                            PaymentsByTypesApiModel = new List<PaymentsByTypesApiModel>(),
                            TotalCount = ofdResponse.ZXReport.TicketOperations
                                .Where(t => t.Operation == OperationTypeEnum.OPERATION_BUY).Sum(t => t.TicketsTotalCount),
                            VAT = 0
                        },
                        ReturnBuy = new OperationTypeSummaryApiModel
                        {
                            Change = 0,
                            Count = ofdResponse.ZXReport.TicketOperations
                                .Where(t => t.Operation == OperationTypeEnum.OPERATION_BUY_RETURN)
                                .Sum(t => t.TicketsCount),
                            Taken = ofdResponse.ZXReport.TicketOperations
                                .Where(t => t.Operation == OperationTypeEnum.OPERATION_BUY_RETURN).Sum(
                                    t => t.TicketsSum.Bills),
                            Markup = 0,
                            Discount = 0,
                            PaymentsByTypesApiModel = new List<PaymentsByTypesApiModel>(),
                            TotalCount = ofdResponse.ZXReport.TicketOperations
                            .Where(t => t.Operation == OperationTypeEnum.OPERATION_BUY_RETURN).Sum(t => t.TicketsTotalCount),
                            VAT = 0
                        },
                        ReturnSell = new OperationTypeSummaryApiModel
                        {
                            Change = 0,
                            Count = ofdResponse.ZXReport.TicketOperations
                                .Where(t => t.Operation == OperationTypeEnum.OPERATION_SELL_RETURN)
                                .Sum(t => t.TicketsCount),
                            Taken = ofdResponse.ZXReport.TicketOperations
                                .Where(t => t.Operation == OperationTypeEnum.OPERATION_SELL_RETURN).Sum(
                                    t => t.TicketsSum.Bills),
                            Markup = 0,
                            Discount = 0,
                            PaymentsByTypesApiModel = new List<PaymentsByTypesApiModel>(),
                            TotalCount = ofdResponse.ZXReport.TicketOperations
                                .Where(t => t.Operation == OperationTypeEnum.OPERATION_SELL_RETURN).Sum(t => t.TicketsTotalCount),
                            VAT = 0
                        },

                        StartNonNullable = new NonNullableApiModel
                        {
                            Buy = ofdResponse.ZXReport.StartShiftNonNullableSums
                                .Where(n => n.Operation == OperationTypeEnum.OPERATION_BUY).Sum(n => n.Sum.Bills),
                            Sell = ofdResponse.ZXReport.StartShiftNonNullableSums
                                .Where(n => n.Operation == OperationTypeEnum.OPERATION_SELL).Sum(n => n.Sum.Bills),
                            ReturnBuy = ofdResponse.ZXReport.StartShiftNonNullableSums
                                .Where(n => n.Operation == OperationTypeEnum.OPERATION_BUY_RETURN)
                                .Sum(n => n.Sum.Bills),
                            ReturnSell = ofdResponse.ZXReport.StartShiftNonNullableSums
                                .Where(n => n.Operation == OperationTypeEnum.OPERATION_SELL_RETURN)
                                .Sum(n => n.Sum.Bills)
                        },
                        EndNonNullable = new NonNullableApiModel
                        {
                            Buy = ofdResponse.ZXReport.NonNullableSums
                                .Where(n => n.Operation == OperationTypeEnum.OPERATION_BUY).Sum(n => n.Sum.Bills),
                            Sell = ofdResponse.ZXReport.NonNullableSums
                                .Where(n => n.Operation == OperationTypeEnum.OPERATION_SELL).Sum(n => n.Sum.Bills),
                            ReturnBuy = ofdResponse.ZXReport.NonNullableSums
                                .Where(n => n.Operation == OperationTypeEnum.OPERATION_BUY_RETURN)
                                .Sum(n => n.Sum.Bills),
                            ReturnSell = ofdResponse.ZXReport.NonNullableSums
                                .Where(n => n.Operation == OperationTypeEnum.OPERATION_SELL_RETURN)
                                .Sum(n => n.Sum.Bills)
                        }
                    }
                };
                return Ok(JsonConvert.SerializeObject(xReportKkmResponse));
            }

            return NotFound();
        }

        private static int GetTakeMoneySum(ZXOfdResponse ofdResponse)
        {
            return ofdResponse.ZXReport.MoneyPlacements
                .Where(r => r.Operation == MoneyPlacementEnum.MONEY_PLACEMENT_WITHDRAWAL)
                .Sum(t => t.OperationsSum.Bills);
        }

        private static int GetPutMoneySum(ZXOfdResponse ofdResponse)
        {
            return ofdResponse.ZXReport.MoneyPlacements
                .Where(r => r.Operation == MoneyPlacementEnum.MONEY_PLACEMENT_DEPOSIT)
                .Sum(t => t.OperationsSum.Bills);
        }

        private ZXOfdResponse GetOfdResponse(ref dynamic resp)
        {
            resp = JsonConvert.SerializeObject(resp);
            ZXOfdResponse ofdResp = JsonConvert.DeserializeObject<ZXOfdResponse>(resp);
            return ofdResp;
        }

        private OfdRequest GetOfdRequest(Request req)
        {
            return new OfdRequest
            {
                Command = 3,
                DeviceId = req.DeviceId,
                ReqNum = req.ReqNum,
                Service = req.Service,
                Token = req.Token,
                Report = new Report
                {
                    ReportType = ReportTypeEnum.REPORT_X,
                    DateTime = GetDateTime()
                }
            };
        }
        private DTO.DateAndTime.DateTime GetDateTime()
        {
            var now = DateTime.Now;
            return new DTO.DateAndTime.DateTime
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

        private string GetHardString()
        {
            return @"{
     ""Data"": {
         ""TaxPayerName"": ""ТОО Тест 21"",
         ""TaxPayerIN"": ""111140010124"",
         ""TaxPayerVAT"": true,
         ""TaxPayerVATSeria"": ""32132"",
         ""TaxPayerVATNumber"": ""1231212"",
         ""ReportNumber"": 1,
         ""CashboxSN"": ""SWK00030767"",
         ""CashboxIN"": 2405,
         ""CashboxRN"": ""240820180008"",
         ""StartOn"": ""07.08.2019 13:29:56"",
         ""ReportOn"": ""07.08.2019 15:16:16"",
         ""CloseOn"": ""07.08.2019 14:17:16"",
         ""CashierCode"": 1,
         ""ShiftNumber"": 55,
         ""DocumentCount"": 1,
         ""PutMoneySum"": 250000,
         ""TakeMoneySum"": 240000,
         ""ControlSum"": 47104,
         ""OfflineMode"": false,
         ""CashboxOfflineMode"": false,
         ""SumInCashbox"": 26843,
         ""Sell"": {
             ""PaymentsByTypesApiModel"": [],
             ""Discount"": 0,
             ""Markup"": 0,
             ""Taken"": 4330,
             ""Change"": 0,
             ""Count"": 260000,
             ""TotalCount"": 168,
             ""VAT"": 0
         },
         ""Buy"": {
             ""PaymentsByTypesApiModel"": [],
             ""Discount"": 0,
             ""Markup"": 0,
             ""Taken"": 0,
             ""Change"": 0,
             ""Count"": 0,
             ""TotalCount"": 1,
             ""VAT"": 0
         },
         ""ReturnSell"": {
             ""PaymentsByTypesApiModel"": [],
             ""Discount"": 0,
             ""Markup"": 0,
             ""Taken"": 0,
             ""Change"": 0,
             ""Count"": 0,
             ""TotalCount"": 19,
             ""VAT"": 0
         },
         ""ReturnBuy"": {
             ""PaymentsByTypesApiModel"": [],
             ""Discount"": 0,
             ""Markup"": 0,
             ""Taken"": 0,
             ""Change"": 0,
             ""Count"": 0,
             ""TotalCount"": 0,
             ""VAT"": 0
         },
         ""EndNonNullable"": {
             ""Sell"": 126949,
             ""Buy"": 0,
             ""ReturnSell"": 1449,
             ""ReturnBuy"": 0
         },
         ""StartNonNullable"": {
             ""Sell"": 126949,
             ""Buy"": 0,
             ""ReturnSell"": 1449,
             ""ReturnBuy"": 0
         }
     }
 }
 ";
        }
    }
}