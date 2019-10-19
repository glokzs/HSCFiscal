using System.Collections.Generic;
using Newtonsoft.Json;

namespace Models.DTO.XReport.OfdResponse
{
    public class Section
    {
        [JsonProperty("section_code")]
        public string SectionCode { get; set; }
        [JsonProperty("operations")]
        public List<Operation> Operations { get; set; }
        
    }
}