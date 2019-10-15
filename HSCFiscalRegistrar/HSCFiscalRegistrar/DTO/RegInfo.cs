using Models.APKInfo;

namespace HSCFiscalRegistrar.DTO
{
    public class RegInfo
    {
        public Org Org { get; set; }
        public Kkm Kkm { get; set; }

        public RegInfo(Org org, Kkm kkm)
        {
            Org = org;
            Kkm = kkm;
        }

        public RegInfo()
        {
        }
    }
}