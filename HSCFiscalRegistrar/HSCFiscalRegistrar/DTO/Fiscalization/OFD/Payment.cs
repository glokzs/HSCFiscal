using Models.Enums;
using Newtonsoft.Json;

namespace HSCFiscalRegistrar.DTO.Fiscalization.OFD
{
    public class Payment
    {
        [JsonProperty("Type")]
        public PaymentTypeEnum Type { get; set; }
        [JsonProperty("Sum")]
        public Sum Sum { get; set; }
    }
}