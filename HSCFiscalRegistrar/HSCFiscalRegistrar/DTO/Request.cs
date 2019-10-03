namespace HSCFiscalRegistrar.Models.APKInfo
{
    public class Request
    {
        public int Command { get; set; }
        public int ReqNum { get; set; }
        public int Token { get; set; }
        public Service Service { get; set; }
    }
}