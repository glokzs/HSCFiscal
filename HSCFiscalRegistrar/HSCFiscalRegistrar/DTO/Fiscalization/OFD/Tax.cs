using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.Fiscalization.OFD
{
    public class Tax
    {
        public TaxTypeEnum Type { get; set; }
        public TaxationTypeEnum TaxationType { get; set; }
        public int Percent { get; set; }
        public Sum Sum { get; set; }
        public bool IsInTotalSum { get; set; }
    }
}