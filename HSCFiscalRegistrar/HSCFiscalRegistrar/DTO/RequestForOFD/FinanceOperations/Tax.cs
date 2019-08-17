using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.RequestForOFD.FinanceOperations
{
    public class Tax
    {
        public TaxTypeEnum Type { get; set; }
        public TaxationTypeEnum TaxationType { get; set; }
        public int Percent { get; set; }
        public FinanceOperations.Money Sum { get; set; }
        public bool IsInTotalSum { get; set; }
    }
}