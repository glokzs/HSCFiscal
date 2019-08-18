using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.RequestForOFD.CheckProcessing.Item
{
    public class Item
    {
        public ItemTypeEnum Type { get; set; }
        public Commodity.Commodity Commodity { get; set; }
        public StornoCommodity StornoCommodity { get; set; }
        public Modifier.Modifier Markup { get; set; }
        public Modifier.Modifier StornoMarkup { get; set; }
        public Modifier.Modifier Discount { get; set; }
        public Modifier.Modifier StornoDiscount { get; set; }
        
    }
}