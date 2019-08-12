using HSCFiscalRegistrar.Models;

namespace HSCFiscalRegistrar.RequestModels
{
    public class Request 
    {
        public int Command { get; set; }
        public int DeviceId { get; set; }
        public int ReqNum { get; set; }
        public int Token { get; set; }
        public MoneyPlacement MoneyPlacement { get; set; }
        public Service Service { get; set; }
        
    }
}