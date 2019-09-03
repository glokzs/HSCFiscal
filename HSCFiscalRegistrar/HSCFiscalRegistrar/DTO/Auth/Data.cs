using System;
using Newtonsoft.Json;

namespace HSCFiscalRegistrar.DTO.Data
{
    public class Data
    {
        [JsonProperty("Token")]

        public string Token { get; set; }
    }
}