namespace HSCFiscalRegistrar.DTO.RequestForOFD
{
    public class Commodity
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string SectionCode { get; set; }
        public int Quantity { get; set; }
        public Money Price { get; set; }
        public Money Sum { get; set; }
        
    }
}