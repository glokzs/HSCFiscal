namespace HSCFiscalRegistrar.DTO.RequestModels
{
    public class MoneyPlacementRequest
    {
        public int Command { get; set; }
        public int DeviceId { get; set; }
        public int ReqNum { get; set; }
        public int Token { get; set; }
        public MoneyPlacement MoneyPlacement { get; set; }
        public Service Service { get; set; }
    }
}