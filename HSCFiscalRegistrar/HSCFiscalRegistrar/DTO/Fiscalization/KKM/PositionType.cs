using Newtonsoft.Json;

namespace HSCFiscalRegistrar.DTO.Fiscalization.KKM
{
    public class PositionType
    {
        [JsonProperty("Count")]
        public decimal Count { get; set; }
        [JsonProperty("Price")]
        public decimal Price { get; set; }
        [JsonProperty("Tax")]
        public decimal Tax { get; set; }
        [JsonProperty("TaxType")]
        public int TaxType { get; set; }
        [JsonProperty("PositionName")]
        public string PositionName { get; set; }
        [JsonProperty("PositionCode")]
        public string PositionCode { get; set; }
        [JsonProperty("Discount")]
        public decimal Discount { get; set; }
        [JsonProperty("Markup")]
        public decimal Markup { get; set; }
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