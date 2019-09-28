using System.Linq;
 using System.Threading.Tasks;
 using HSCFiscalRegistrar.DTO.DateAndTime;
using HSCFiscalRegistrar.DTO.Fiscalization.OFDResponce;
using HSCFiscalRegistrar.DTO.XReport;
 using HSCFiscalRegistrar.Enums;
 using HSCFiscalRegistrar.Models;
 using HSCFiscalRegistrar.Models.APKInfo;
using HSCFiscalRegistrar.Services;
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
         public XReportController(UserManager<User> userManager, ApplicationContext context)
         {
             _userManager = userManager;
             _context = context;
         }
         
         
         [HttpPost]
         public async Task<IActionResult> XReportResult([FromBody] KkmRequest kkmRequest)
         {
             Request request = _context.Requests.FirstOrDefault(r => r.Id == "7");
             if (request != null)
             {
                 OfdRequest ofdRequest = new OfdRequest
                 {
                     Command = 3,
                     DeviceId = request.DeviceId.ToString(),
                     ReqNum = request.ReqNum,
                     Service = request.Service,
                     Token = request.Token,
                     Report = new Report
                     {
                         ReportType = ReportTypeEnum.REPORT_X,
                         DateTime = GetDateTime()
                     }
                 };
                 dynamic response = Post(ofdRequest);
                 return Ok(JsonConvert.SerializeObject(response));
             }
             return NotFound();
         }
 
         private dynamic GetOfdResponse(ref dynamic resp)
         {
             resp = JsonConvert.SerializeObject(resp);
             var ofdResp = JsonConvert.DeserializeObject<Response>(resp);
             return ofdResp;
         }
 
         private OfdRequest GetOfdRequest(Request req)
         {
             return new OfdRequest
             {
                 Command = 1,
                 Token = req.Token,
                 ReqNum = req.ReqNum,
                 Service = req.Service,
                 Report = {ReportType = ReportTypeEnum.REPORT_X, DateTime = GetDateTime()}
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