using Models.Enums;
using Newtonsoft.Json;

namespace HSCFiscalRegistrar.DTO.Fiscalization.KKM
{
    public class PaymentsType
    {
        [JsonProperty("Sum")]
        public decimal Sum { get; set; }
        [JsonProperty("PaymentType")]
        public PaymentTypeEnum PaymentType { get; set; }
    }
}