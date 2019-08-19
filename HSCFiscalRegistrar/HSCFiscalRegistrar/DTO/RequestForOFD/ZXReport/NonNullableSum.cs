using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.RequestForOFD.ZXReport
{
    public class NonNullableSum
    {
        public OperationTypeEnum Operation { get; set; }
        public Money Sum { get; set; }
    }
}