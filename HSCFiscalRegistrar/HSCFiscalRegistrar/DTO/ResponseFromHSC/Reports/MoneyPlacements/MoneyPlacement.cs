using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.ResponseFromHSC.Reports.MoneyPlacements
{
    public class MoneyPlacement 
    {
        public MoneyPlacementEnum MoneyPlacementEnum { get; set; }
        public int OperationCount { get; set; }
        public int OperationTotalCount { get; set; }
        public OperationSum OperationType { get; set; }
    }
}