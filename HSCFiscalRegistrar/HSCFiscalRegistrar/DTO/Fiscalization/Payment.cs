using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.Fiscalization
{
    public class Payment
    {
        public PaymentTypeEnum Type { get; set; }
        public Sum Sum { get; set; }
    }
}