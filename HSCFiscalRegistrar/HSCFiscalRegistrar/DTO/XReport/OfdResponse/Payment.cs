using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.XReport.OfdResponse
{
    public class Payment
    {
        public PaymentTypeEnum PaymentType { get; set; }
        public Money Sum { get; set; }
    }
}