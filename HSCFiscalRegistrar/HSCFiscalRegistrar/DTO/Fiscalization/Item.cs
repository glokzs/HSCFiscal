using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.Fiscalization
{
    public class Item
    {
        public ItemTypeEnum Type { get; set; }
        public Commodity Commodity { get; set; }
        public StornoCommodity StornoCommodity { get; set; }
        public Markup Markup { get; set; }
        public StornoMarkup StornoMarkup { get; set; }
        public Discount Discount { get; set; }
        public StornoDiscount StornoDiscount { get; set; }
        
    }
}