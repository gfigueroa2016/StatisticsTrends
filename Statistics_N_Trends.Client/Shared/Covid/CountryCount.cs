using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Statistics_N_Trends.Client.Shared.Covid
{
    public class CountryCount
    {
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("count")]
        public long Count { get; set; }
    }
}
