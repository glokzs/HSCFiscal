using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HSCFiscalRegistrar.DTO.Cashboxes
{
    public class List
    {
        [JsonProperty("UniqueNumber")]
        public string UniqueNumber { get; set; }

        [JsonProperty("RegistrationNumber")]
        public string RegistrationNumber { get; set; }

        [JsonProperty("IdentificationNumber")]
        public string IdentificationNumber { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("IsOffline")]
        public bool IsOffline { get; set; }

        [JsonProperty("CurrentStatus")]
        public int CurrentStatus { get; set; }

        [JsonProperty("Shift")]
        public int Shift { get; set; }

    }
}