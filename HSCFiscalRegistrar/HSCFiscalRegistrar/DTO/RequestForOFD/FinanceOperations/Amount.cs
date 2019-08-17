namespace HSCFiscalRegistrar.DTO.RequestForOFD.FinanceOperations
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