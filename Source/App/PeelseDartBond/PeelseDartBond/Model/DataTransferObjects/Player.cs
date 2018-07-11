using System;
using Newtonsoft.Json;

namespace PeelseDartBond.Model.DataTransferObjects
{
    public class Player
    {
        public Player()
        {
        }

        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("team")]
        public string Team { get; set; }
        [JsonProperty("team_url")]
        public string TeamUrl { get; set; }
        [JsonProperty("amount")]
        public int Amount { get; set; }
        [JsonProperty("finish")]
        public int Finish { get; set; }
        [JsonProperty("played")]
        public int Played { get; set; }
        [JsonProperty("won")]
        public int Won { get; set; }
        [JsonProperty("percentage")]
        public decimal Percentage { get; set; }
        [JsonProperty("last_match_state")]
        public string Status { get; set; }
    }
}
