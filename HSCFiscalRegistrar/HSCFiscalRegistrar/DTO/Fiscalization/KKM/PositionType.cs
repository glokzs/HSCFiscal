using HSCFiscalRegistrar.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HSCFiscalRegistrar.DTO.Fiscalization.KKM
{
    public class PositionType
    {
        [JsonProperty("Count")]
        public int Count { get; set; }
        [JsonProperty("Price")]
        public int Price { get; set; }
        [JsonProperty("Tax")]
        public int Tax { get; set; }
        [JsonProperty("TaxType")]
        public int TaxType { get; set; }
        [JsonProperty("PositionName")]
        public string PositionName { get; set; }
        [JsonProperty("PositionCode")]
        public string PositionCode { get; set; }
        [JsonProperty("Discount")]
        public int Discount { get; set; }
        [JsonProperty("Markup")]
        public int Markup { get; set; }
        [JsonProperty("SectionCode")]
        public string SectionCode { get; set; }
        [JsonProperty("IsStorno")]
        public bool IsStorno { get; set; }
        [JsonProperty("MarkupDeleted")]
        public bool MarkupDeleted { get; set; }
        [JsonProperty("DiscountDeleted")]
        public bool DiscountDeleted { get; set; }
        [JsonProperty("UnitCode")]
        public int UnitCode { get; set; }
    }
}