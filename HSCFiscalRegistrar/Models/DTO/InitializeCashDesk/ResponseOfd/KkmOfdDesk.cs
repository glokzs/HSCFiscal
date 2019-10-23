using Newtonsoft.Json;

namespace Models.DTO.InitializeCashDesk.ResponseOfd
{
    public class KkmOfdDesk
    {
        [JsonProperty("kkm_id")]
        public string KkmIdOfd { get; set; }
        [JsonProperty("serial_number")] 
        public string SerialNumber { get; set; }
        [JsonProperty("fns_kkm_id")]
        public string FnsKkmId { get; set; }

    }
}