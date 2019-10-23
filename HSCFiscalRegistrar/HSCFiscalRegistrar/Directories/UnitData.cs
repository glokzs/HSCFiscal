using Newtonsoft.Json;

namespace HSCFiscalRegistrar.Directories
{
    public class UnitData
    {
        [JsonProperty("Code")]
        public int Code { get; set; }
        [JsonProperty("NameRu")]
        public string NameRu { get; set; }
        [JsonProperty("NameEn")]
        public string NameEn { get; set; }
        [JsonProperty("NameKz")]
        public string NameKz { get; set; }
    }
}