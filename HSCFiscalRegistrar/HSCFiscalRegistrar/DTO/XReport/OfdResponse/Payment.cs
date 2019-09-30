using HSCFiscalRegistrar.Enums;
using Newtonsoft.Json;

namespace HSCFiscalRegistrar.DTO.XReport.OfdResponse
{
    public class Payment
    {
        [JsonProperty("payment")]
        public PaymentTypeEnum PaymentType { get; set; }
        [JsonProperty("sum")]
        public Money Sum { get; set; }
    }
}