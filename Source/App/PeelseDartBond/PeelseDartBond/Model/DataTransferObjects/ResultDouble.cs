using System;
using Newtonsoft.Json;

namespace PeelseDartBond.Model.DataTransferObjects
{
    public class ResultDouble
    {
        public ResultDouble()
        {
        }

        [JsonProperty("position")]
        public int Position { get; set; }
        [JsonProperty("home_player_1")]
        public string Home1 { get; set; }
        [JsonProperty("home_player_2")]
        public string Home2 { get; set; }
        [JsonProperty("out_player_1")]
        public string Away1 { get; set; }
        [JsonProperty("out_player_2")]
        public string Away2 { get; set; }
        [JsonProperty("result")]
        public string Score { get; set; }
    }
}
