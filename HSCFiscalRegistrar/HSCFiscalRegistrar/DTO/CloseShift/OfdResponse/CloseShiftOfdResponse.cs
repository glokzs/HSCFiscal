using HSCFiscalRegistrar.DTO.Fiscalization.OFDResponse;
using HSCFiscalRegistrar.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HSCFiscalRegistrar.DTO.CloseShift.OfdResponse
{
    public class CloseShiftOfdResponse
    {
        [JsonProperty("result")]
        public Result Result { get; set; }
        [JsonProperty("service")]
        public Fiscalization.OFDResponse.Service Service { get; set; }
        [JsonProperty("report")]
        public Report Report { get; set; }
        [JsonProperty("command")]
        public CommandTypeEnum Command { get; set; }
        [JsonProperty("token")]
        public int Token { get; set; }
        
    }
}