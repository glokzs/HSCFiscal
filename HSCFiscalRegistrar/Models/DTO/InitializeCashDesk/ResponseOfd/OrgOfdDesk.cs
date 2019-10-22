using Newtonsoft.Json;

namespace Models.DTO.InitializeCashDesk.ResponseOfd
{
    public class OrgOfdDesk
    {
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("iin")]
        public string Iin { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }    
    }
}