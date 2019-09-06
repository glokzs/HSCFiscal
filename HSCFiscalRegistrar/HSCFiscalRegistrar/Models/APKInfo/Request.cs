namespace HSCFiscalRegistrar.Models.APKInfo
{
    public class Request
    {
        public string Command { get; set; }
        public int DeviceId { get; set; }
        public int ReqNum { get; set; }
        public int Token { get; set; }
        public string ServiceId { get; set; }
        public Service Service { get; set; }
    }
}