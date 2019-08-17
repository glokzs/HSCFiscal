namespace HSCFiscalRegistrar.DTO.RequestFromKKM.CheckOperations
{
    public class PositionType
    {
        public decimal Count { get; set; }
        public decimal Price { get; set; }
        
        public virtual Position Positions { get; set; }
        public string PositionId { get; set; }

        public decimal Discount { get; set; }
        public string SectionCode { get; set; }
        public bool IsStorno { get; set; }
        public bool MarkupDeleted { get; set; }
        public bool DiscountDeleted { get; set; }
        public int UniCode { get; set; }  
    }
}