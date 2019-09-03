using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HSCFiscalRegistrar.DTO.Cashboxes
{
    public class Wrapper
    {
        [JsonProperty("Data")]
        public Data Data { get; set; }
    }
}
