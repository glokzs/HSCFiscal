using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.RequestForOFD.ZXReport
{
    public class OperationZX : Finance.Finance
    {
        public OperationTypeEnum Type { get; set; }
        public int Count { get; set; }
    }
}