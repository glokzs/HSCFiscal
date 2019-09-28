using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.XReport.OfdResponse
{
    public class NonNullableSum
    {
        public OperationTypeEnum Operation { get; set; }
        public Money Sum { get; set; }
    }
}