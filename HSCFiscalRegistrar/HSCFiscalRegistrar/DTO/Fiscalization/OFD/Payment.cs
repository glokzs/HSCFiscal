using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.Fiscalization.OFD
{
    public class Payment
    {
        public PaymentTypeEnum Type { get; set; }
        public Sum Sum { get; set; }
    }
}