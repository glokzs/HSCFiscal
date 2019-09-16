namespace HSCFiscalRegistrar.Models.APKInfo
{
    public class Request
    {
        public string Id { get; set; }
        public int Command { get; set; }
        public int DeviceId { get; set; }
        public int ReqNum { get; set; }
        public int Token { get; set; }
        public string ServiceId { get; set; }
        public virtual Service Service { get; set; }
    }
}