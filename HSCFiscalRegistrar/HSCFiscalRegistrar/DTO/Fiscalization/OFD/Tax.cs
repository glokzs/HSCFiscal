using Models.Enums;
using Newtonsoft.Json;

namespace HSCFiscalRegistrar.DTO.Fiscalization.OFD
{
    public class Tax
    {
        [JsonProperty("Type")]
        public TaxTypeEnum Type { get; set; }
        [JsonProperty("TaxationType")]
        public TaxationTypeEnum TaxationType { get; set; }
        [JsonProperty("Percent")]
        public int Percent { get; set; }
        [JsonProperty("Sum")]
        public Sum Sum { get; set; }
        [JsonProperty("IsInTotalSum")]
        public bool IsInTotalSum { get; set; }
    }
}