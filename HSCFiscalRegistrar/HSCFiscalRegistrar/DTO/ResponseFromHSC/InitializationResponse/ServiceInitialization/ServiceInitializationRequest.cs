namespace HSCFiscalRegistrar.DTO.ResponseFromHSC.InitializationResponse.ServiceInitialization
{
    public class ServiceInitializationRequest
    {
        public Auxiliary Auxiliary { get; set; }
        public RegInfoInitializationRequest RegInfo { get; set; }
        public TicketAd TicketAd { get; set; }
    }
}