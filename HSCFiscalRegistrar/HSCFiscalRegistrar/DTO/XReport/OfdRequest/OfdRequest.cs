using HSCFiscalRegistrar.Models.APKInfo;

namespace HSCFiscalRegistrar.DTO.XReport
{
    public class OfdRequest
    {
        public int Command { get; set; }
        public int DeviceId { get; set; }
        public int ReqNum { get; set; }
        public int Token { get; set; }
        public virtual Service Service { get; set; }
        public Report Report { get; set; }
    }
}