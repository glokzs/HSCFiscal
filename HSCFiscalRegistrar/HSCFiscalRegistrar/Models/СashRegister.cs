namespace HSCFiscalRegistrar.Models
{
    public class СashRegister
    {
        public int Comand { get; set; }
        public int  DeviceId { get; set; }
        public int ReqNum { get; set; }
        public double Token { get; set; }
        public Service Service { get; set; }
    }
}