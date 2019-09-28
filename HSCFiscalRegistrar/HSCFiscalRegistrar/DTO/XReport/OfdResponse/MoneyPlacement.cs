using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.XReport.OfdResponse
{
    public class MoneyPlacement
    {
        public MoneyPlacementEnum Operation { get; set; }
        public int OperationsTotalCount { get; set; }
        public int OperationsCount { get; set; }
        public Money OperationsSum { get; set; }
        
    }
}