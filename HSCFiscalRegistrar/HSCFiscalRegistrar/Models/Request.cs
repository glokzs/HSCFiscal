namespace HSCFiscalRegistrar.Models
{
    public abstract class Request
    {
        public int Command { get; set; }
        public int DeviceId { get; set; }
        public int ReqNum { get; set; }
        public string Token { get; set; }
        public RegInfo RegInfo { get; set; }
        public Kkm Kkm { get; set; }
    }
}