using HSCFiscalRegistrar.Enums;
using Microsoft.AspNetCore.Authentication;

namespace HSCFiscalRegistrar.DTO.ResponseFromHSC.CheckAndMoneyOperationResponse
{
    public abstract class DataHSCResponse
    {
        public Result Result { get; set; }
        public Service Service { get; set; }
        public CommandTypeEnum Command { get; set; }
        public int Token { get; set; }
    }
}