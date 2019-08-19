using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.ResponseFromHSC.Reports.TicketOperations
{
    public class Payment
    {
        public PaymentTypeEnum PaymentEnum { get; set; }
        public Money Money { get; set; }
    }
}