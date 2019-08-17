namespace HSCFiscalRegistrar.DTO.RequestForOFD.CheckProcessing
{
    public class Commodity
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string SectionCode { get; set; }
        public int Quantity { get; set; }
        public FinanceOperations.Money Price { get; set; }
        public FinanceOperations.Money Sum { get; set; }
        
    }
}