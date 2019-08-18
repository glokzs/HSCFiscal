using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.RequestForOFD.MoneyPlacementRequest
{
    public class Payment : Finance.Finance
    {
        public PaymentTypeEnum Type { get; set; }
    }
}