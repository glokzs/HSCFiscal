using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.ResponseFromHSC
{
    public class Result
    {
        public ResultTypeEnum ResultCode { get; set; }
        public string ResultText { get; set; }
    }
}