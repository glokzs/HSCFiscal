using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HSCFiscalRegistrar.DTO.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HSCFiscalRegistrar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class XReportController : Controller
    {
        [HttpPost]
        public string XReportResult([FromBody]Data data)
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