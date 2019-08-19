using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.ResponseFromHSC.Reports.Taxes
{
    public class Tax
    {
        public TaxOperation TaxOperation { get; set; }
        public TaxTypeEnum TaxType { get; set; }
        public int Percent { get; set; }
    }
}