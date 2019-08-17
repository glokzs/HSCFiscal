using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.RequestForHSC
{
    public class DataHSCRequest
    {
        public CommandTypeEnum Command { get; set; }
        public int DeviceId { get; set; }
        public int ReqNum { get; set; }
        public int Token { get; set; }
        public Service Service { get; set; }
    }
}