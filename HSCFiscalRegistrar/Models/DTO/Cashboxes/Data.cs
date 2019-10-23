using System.Collections.Generic;
using Newtonsoft.Json;

namespace Models.DTO.Cashboxes
{
    public class Data
    {
        [JsonProperty("List")]
        public List<List> List = new List<List>();
    }
}