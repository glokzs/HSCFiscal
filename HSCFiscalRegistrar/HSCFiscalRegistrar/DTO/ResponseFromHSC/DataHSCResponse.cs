using HSCFiscalRegistrar.DTO.ResponseFromHSC.CheckAndMoneyOperationResponse;
using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.ResponseFromHSC
{
    public abstract class DataHSCResponse
    {
        public Result Result { get; set; }
        public Service Service { get; set; }
        public CommandTypeEnum Command { get; set; }
        public int Token { get; set; }
    }
}