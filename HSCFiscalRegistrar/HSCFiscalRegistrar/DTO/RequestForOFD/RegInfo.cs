using HSCFiscalRegistrar.Models;

namespace HSCFiscalRegistrar.DTO.RequestForOFD
{
    public class RegInfo
    {
        public Kkm Kkm { get; set; }
        public PosRegInfo Pos { get; set; }
        public OrgRegInfo Org { get; set; }
    }
}