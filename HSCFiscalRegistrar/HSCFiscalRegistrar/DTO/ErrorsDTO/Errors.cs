using System.Collections.Generic;
using Newtonsoft.Json;

namespace HSCFiscalRegistrar.DTO.ErrorsDTO
{
    public class ErrorsWrapper
    {
        [JsonProperty("Errors")]
        public Error[] Errors { get; set; }
    }

    public class Error
    {
        [JsonProperty("Code")]
        public int Code { get; set; }
        
        [JsonProperty("Text")]
        public string Text { get; set; }
    }
}