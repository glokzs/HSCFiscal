namespace HSCFiscalRegistrar.DTO.RequestForOFD.ServiceRequest.Device
{
    public class RegInfo
    {
        public Kkm Kkm { get; set; }
        public PosRegInfo Pos { get; set; }
        public OrgRegInfo.OrgRegInfo Org { get; set; }
    }
}