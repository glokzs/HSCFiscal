using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.RequestForOFD.MoneyPlacementRequest
{
    public class MoneyPlacement : Finance.Finance
    {
        public MoneyPlacementEnum Operation { get; set; }
        public int OperationsTotalCount { get; set; }
        public int OperationsCount { get; set; }
    }
}