using Newtonsoft.Json;

namespace HSCFiscalRegistrar.DTO.Fiscalization.OFDResponce
{
    public class Response
    {
        public Result Result { get; set; }
        [JsonProperty("ticket")]
        public Ticket Ticket { get; set; }
        public Service Service { get; set; }
        public string Command { get; set; }
        public int Token { get; set; }
    }
}