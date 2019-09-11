using HSCFiscalRegistrar.Enums;
using HSCFiscalRegistrar.Models.APKInfo;

namespace HSCFiscalRegistrar.DTO.Fiscalization.OFD
{
    public class FiscResponse
    {
        public CommandTypeEnum Command { get; set; }
        public int DeviceId { get; set; }
        public int ReqNum { get; set; }
        public int Token { get; set; }
        public Service Service { get; set; }
        public Ticket Ticket { get; set; }
    }
}