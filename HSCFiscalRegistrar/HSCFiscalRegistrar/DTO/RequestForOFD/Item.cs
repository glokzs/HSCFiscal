using HSCFiscalRegistrar.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HSCFiscalRegistrar.DTO.RequestForOFD
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