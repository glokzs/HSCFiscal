using HSCFiscalRegistrar.DTO.Fiscalization.OFD;
using HSCFiscalRegistrar.Enums;
using Newtonsoft.Json;

namespace HSCFiscalRegistrar.DTO.Fiscalization.KKM
{
    public class TicketModifierType
    {
        [JsonProperty("Sum")]
        public int Sum { get; set; }
        [JsonProperty("Text")]
        public string Text { get; set; }
        [JsonProperty("Type")]
        public int Type { get; set; }
        [JsonProperty("TaxType")]
        public int TaxType{ get; set; }
        [JsonProperty("Tax")]
        public int Tax { get; set; }
    }
}