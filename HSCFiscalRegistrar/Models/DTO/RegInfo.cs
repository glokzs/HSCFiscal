using Models.APKInfo;

namespace Models.DTO
{
    public class RegInfo
    {
        public User Org { get; set; }
        public Kkm Kkm { get; set; }

        public RegInfo(User org, Kkm kkm)
        {
            Org = org;
            Kkm = kkm;
        }

        public RegInfo()
        {
        }
    }
}