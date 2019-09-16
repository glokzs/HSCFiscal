using System.Collections.Generic;
using Newtonsoft.Json;

namespace HSCFiscalRegistrar.DTO.Fiscalization.OFD
{
    public class StornoCommodity
    {
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("SectionCode")]
        public string SectionCode { get; set; }
        [JsonProperty("Quantity")]
        public int Quantity { get; set; }
        [JsonProperty("Price")]
        public Sum Price { get; set; }
        [JsonProperty("Sum")]
        public Sum Sum { get; set; }
        [JsonProperty("Taxes")]
        public List<Tax> Taxes { get; set; }
    }
}