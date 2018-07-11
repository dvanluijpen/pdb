using System;
using Newtonsoft.Json;

namespace PeelseDartBond.Model.DataTransferObjects
{
    public class Competition
    {
        public Competition()
        {
        }

        [JsonProperty("division")]
        public string Division { get; set; }
        [JsonProperty("ranking")]
        public string Ranking { get; set; }
        [JsonProperty("schedule")]
        public string Schedule { get; set; }
        [JsonProperty("results")]
        public string Results { get; set; }
        [JsonProperty("matrix")]
        public string Matrix { get; set; }
        [JsonProperty("singles")]
        public string Singles { get; set; }
        [JsonProperty("one_hundred_and_eighties")]
        public string OneHundredAndEighties { get; set; }
        [JsonProperty("finishes")]
        public string Finishes { get; set; }
    }
}
