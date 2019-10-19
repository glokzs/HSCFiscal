using Models.Enums;
using Newtonsoft.Json;

namespace Models.DTO.XReport.OfdResponse
{
    public class Payment
    {
        [JsonProperty("payment")]
        public PaymentTypeEnum PaymentType { get; set; }
        [JsonProperty("sum")]
        public Money Sum { get; set; }
    }
}