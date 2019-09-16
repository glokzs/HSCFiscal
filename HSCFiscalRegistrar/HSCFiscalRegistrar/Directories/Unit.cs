using Newtonsoft.Json;

namespace HSCFiscalRegistrar.Directories
{
    public class Unit
    {
        [JsonProperty("Data")]
        public UnitData[] Data { get; set; }
    }
}