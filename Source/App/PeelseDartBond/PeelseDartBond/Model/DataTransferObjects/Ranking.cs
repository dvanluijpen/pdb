using System;
using Newtonsoft.Json;

namespace PeelseDartBond.Model.DataTransferObjects
{
    public class Ranking
    {
        public Ranking()
        {
        }

        [JsonProperty("ranking")]
        public int Position { get; set; }
        [JsonProperty("team")]
        public string Team { get; set; }
        [JsonProperty("team_url")]
        public string TeamUrl { get; set; }
        [JsonProperty("played")]
        public int Played { get; set; }
        [JsonProperty("won")]
        public int Won { get; set; }
        [JsonProperty("draw")]
        public int Draw { get; set; }
        [JsonProperty("lost")]
        public int Lost { get; set; }
        [JsonProperty("points")]
        public int Points { get; set; }
        [JsonProperty("penalties")]
        public string Penalties { get; set; }
        [JsonProperty("match_points")]
        public int MatchPoints { get; set; }
        [JsonProperty("average_points")]
        public decimal AveragePoints { get; set; }
        [JsonProperty("last_match_state")]
        public string Status { get; set; }
    }
}
