namespace HSCFiscalRegistrar.DTO.RequestForOFD.CheckProcessing.Item.Commodity
{
    public class Commodity
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string SectionCode { get; set; }
        public int Quantity { get; set; }
        public MoneyPlacementRequest.Money Price { get; set; }
        public MoneyPlacementRequest.Money Sum { get; set; }
        
    }
}