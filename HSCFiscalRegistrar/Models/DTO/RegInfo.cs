using Models.DTO.RequestOfd;
using Models.DTO.RequestOperatorOfd;
using Newtonsoft.Json;

namespace Models.DTO
{
    public class RegInfo
    {
        public Org Org { get; set; }
        [JsonProperty("Kkm")]
        public OfdKkm Kkm { get; set; }

        public RegInfo(Org org, OfdKkm kkm)
        {
            Org = org;
            Kkm = kkm;
        }

        public RegInfo()
        {
        }
    }
}