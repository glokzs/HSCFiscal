using Newtonsoft.Json;

namespace Models.DTO.InitializeCashDesk.ResponseOfd
{
    public class RegInfoOfdDesk
    {
        [JsonProperty("pos")]
        public PosOfdDesk Pos { get; set; }
        [JsonProperty("org")]
        public OrgOfdDesk Org { get; set; }
        [JsonProperty("kkm")] 
        public KkmOfdDesk Kkm { get; set; }
    }
}