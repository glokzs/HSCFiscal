using HSCFiscalRegistrar.DTO.RequestForOFD.CheckProcessing.Modifier;

namespace HSCFiscalRegistrar.DTO.RequestForOFD.MoneyPlacementRequest
{
    public class Amount
    {
        public Money Total { get; set; }
        public Money Taken { get; set; }
        public Money Change { get; set; }
        public Modifier Markup { get; set; }
        public Modifier Discount { get; set; }
    }
}