using HSCFiscalRegistrar.Models.APKInfo;
using Newtonsoft.Json;

namespace HSCFiscalRegistrar.DTO.XReport
{
    public class OfdRequest
    {
        public int Command { get; set; }
        public string DeviceId { get; set; }
        public int ReqNum { get; set; }
        public int Token { get; set; }
        public virtual Service Service { get; set; }
        public Report Report { get; set; }
    }
}