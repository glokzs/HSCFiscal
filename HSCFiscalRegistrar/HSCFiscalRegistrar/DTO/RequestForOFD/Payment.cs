using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.RequestForOFD
{
    public class Payment
    {
        public PaymentTypeEnum Type { get; set; }
        public FinanceOperations.Money Sum { get; set; }
    }
}