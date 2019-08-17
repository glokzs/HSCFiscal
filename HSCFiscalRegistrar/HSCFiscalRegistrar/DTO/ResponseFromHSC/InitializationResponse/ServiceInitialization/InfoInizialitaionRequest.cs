using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.ResponseFromHSC.InitializationResponse.ServiceInitialization
{
    public class InfoInizialitaionRequest
    {
        public int Version { get; set; }
        public TicketAdTypeEnum Type { get; set; }
    }
}