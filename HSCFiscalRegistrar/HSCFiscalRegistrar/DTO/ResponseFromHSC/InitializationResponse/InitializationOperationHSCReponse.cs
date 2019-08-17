using HSCFiscalRegistrar.DTO.ResponseFromHSC.InitializationResponse.ServiceInitialization;
using HSCFiscalRegistrar.DTO.ResponseFromHSC.Reports;
using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.ResponseFromHSC.InitializationResponse
{
    public class InitializationOperationHSCReponse
    {
        public Result Result { get; set; }
        public ServiceInitializationRequest Service { get; set; }
        public Report Report { get; set; }
        public CommandTypeEnum Command { get; set; }
        public int Token { get; set; }
    }
}