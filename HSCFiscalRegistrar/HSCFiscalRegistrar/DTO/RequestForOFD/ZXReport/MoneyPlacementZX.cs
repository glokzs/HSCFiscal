namespace HSCFiscalRegistrar.DTO.RequestForOFD.ZXReport
{
    public class MoneyPlacementZX : MoneyPlacement
    {
        public int OperationsTotalCount { get; set; }
        public int OperationsCount { get; set; }
        public Money OperationsSum { get; set; }
        
    }
}