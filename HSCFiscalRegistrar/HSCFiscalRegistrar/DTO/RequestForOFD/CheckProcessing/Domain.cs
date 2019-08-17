using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.RequestForOFD.CheckProcessing
{
    public class Domain
    {
        public DomainTypeEnum Type { get; set; }
        public DomainTypeEnum Services { get; set; }
        public DomainTypeEnum Gasoil { get; set; }
        public DomainTypeEnum Taxi { get; set; }
        public DomainTypeEnum Parking { get; set; }
    }
}