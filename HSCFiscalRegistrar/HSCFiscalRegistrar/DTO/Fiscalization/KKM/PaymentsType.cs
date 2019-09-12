using Newtonsoft.Json;

namespace HSCFiscalRegistrar.DTO.Fiscalization.KKM
{
    public class PaymentsType
    {
        [JsonProperty("Sum")]
        public int Sum { get; set; }
        [JsonProperty("PaymentType")]
        public int PaymentType { get; set; }
    }
}