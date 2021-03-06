﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Statistics_N_Trends.Client.Shared.Covid
{
    public class DailyReport
    {
        [JsonProperty("confirmed")]
        public long Confirmed { get; set; }
        [JsonProperty("deaths")]
        public long Deaths { get; set; }
        [JsonProperty("recovered")]
        public long Recovered { get; set; }    }
}
