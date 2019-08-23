namespace HSCFiscalRegistrar.DTO.ResponseFromHSC.InitializationResponse.ServiceInitialization
{
    public class RegInfoInitializationRequest 
    {
        public PosInitializationRequest Pos { get; set; }
        public OrgInitialization Org { get; set; }
        public KkmInitialization Kkm { get; set; }
    }
}