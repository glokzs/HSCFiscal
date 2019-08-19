using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.ResponseFromHSC.Reports
{
    public class DataOperationResponse
    {
        
        public Money Sum { get; set; }
        public OperationTypeEnum OperationEnum { get; set; }
    }
}