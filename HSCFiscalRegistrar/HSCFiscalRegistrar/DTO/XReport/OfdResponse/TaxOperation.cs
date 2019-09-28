using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.XReport.OfdResponse
{
    public class TaxOperation
    {
        public OperationTypeEnum Operation{ get; set; }
        public Money Turnover { get; set; }
        public Money Sum { get; set; }    
        
    }
}