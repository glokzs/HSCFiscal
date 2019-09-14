using HSCFiscalRegistrar.Enums;
using Newtonsoft.Json;

namespace HSCFiscalRegistrar.DTO.Fiscalization.OFD
{
    public class Item
    {
        [JsonProperty("Type")]
        public ItemTypeEnum Type { get; set; }
        [JsonProperty("Commodity")]
        public Commodity Commodity { get; set; }
        [JsonProperty("StornoCommodity")]
        public StornoCommodity StornoCommodity { get; set; }
        [JsonProperty("Markup")]
        public Markup Markup { get; set; }
        [JsonProperty("StornoMarkup")]
        public StornoMarkup StornoMarkup { get; set; }
        [JsonProperty("Discount")]
        public Discount Discount { get; set; }
        [JsonProperty("StornoDiscount")]
        public StornoDiscount StornoDiscount { get; set; }
        
    }
}