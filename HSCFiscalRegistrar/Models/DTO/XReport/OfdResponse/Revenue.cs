﻿using Newtonsoft.Json;

namespace Models.DTO.XReport.OfdResponse
{
    public class Revenue
    {
        [JsonProperty("sum")]
        public Money Sum { get; set; }
        [JsonProperty("is_negative")]
        public bool IsNegative { get; set; }
    }
}