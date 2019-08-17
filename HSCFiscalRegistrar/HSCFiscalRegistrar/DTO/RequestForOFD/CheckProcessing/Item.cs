using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.RequestForOFD.CheckProcessing
{
    public class Item
    {
        public ItemTypeEnum Type { get; set; }
        public Commodity Commodity { get; set; }
        public StornoCommodity StornoCommodity { get; set; }
        public Modifier Markup { get; set; }
        public Modifier StornoMarkup { get; set; }
        public Modifier Discount { get; set; }
        public Modifier StornoDiscount { get; set; }
        
    }
}