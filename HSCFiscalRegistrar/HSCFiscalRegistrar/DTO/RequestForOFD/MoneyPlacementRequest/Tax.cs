using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.RequestForOFD.MoneyPlacementRequest
{
    public class Tax : Finance.Finance
    {
        public TaxTypeEnum Type { get; set; }
        public TaxationTypeEnum TaxationType { get; set; }
        public int Percent { get; set; }
        public bool IsInTotalSum { get; set; }
    }
}