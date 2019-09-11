using HSCFiscalRegistrar.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HSCFiscalRegistrar.DTO.Fiscalization.KKM
{
    public class Position
    {
        public int Count { get; set; }
        public int Price { get; set; }
        public int Tax { get; set; }
        public TaxTypeEnum TaxType { get; set; }
        public string PositionName { get; set; }
        public string PositionCode { get; set; }
        public int Discount { get; set; }
        public int Markup { get; set; }
        public string SectionCode { get; set; }
        public bool IsStorno { get; set; }
        public bool MarkupDeleted { get; set; }
        public bool DiscountDeleted { get; set; }
        public int UnitCode { get; set; }
    }
}