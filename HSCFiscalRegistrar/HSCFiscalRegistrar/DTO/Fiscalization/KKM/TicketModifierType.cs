using HSCFiscalRegistrar.Enums;
using Newtonsoft.Json;

namespace HSCFiscalRegistrar.DTO.Fiscalization.KKM
{
    public class TicketModifierType
    {
        [JsonProperty("Sum")]
        public decimal Sum { get; set; }
        [JsonProperty("Text")]
        public string Text { get; set; }
        [JsonProperty("Type")]
        public long Type { get; set; }
        [JsonProperty("TaxType")]
        public TaxationTypeEnum TaxType{ get; set; }
        [JsonProperty("Tax")]
        public decimal Tax { get; set; }
    }
}