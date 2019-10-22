using System.Security.AccessControl;
using Newtonsoft.Json;

namespace Models.DTO.InitializeCashDesk.ResponseOfd
{
    public class PosOfdDesk
    {
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}