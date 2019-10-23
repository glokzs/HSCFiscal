using System.Collections.Generic;
using Newtonsoft.Json;

namespace Models.DTO.Fiscalization.OFD
{
    public class Markup
    {
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Sum")]
        public Sum Sum { get; set; }
        [JsonProperty("Taxes")]
        public List<Tax> Taxes { get; set; }
    }
}