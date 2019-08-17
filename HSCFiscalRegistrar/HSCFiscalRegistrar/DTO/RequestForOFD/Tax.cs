using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.RequestForOFD
{
    public class Tax
    {
        public TaxTypeEnum Type { get; set; }
        public TaxationTypeEnum TaxationType { get; set; }
        public int Percent { get; set; }
        public Money Sum { get; set; }
        public bool IsInTotalSum { get; set; }
    }
}