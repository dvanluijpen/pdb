using System;
using Newtonsoft.Json;

namespace PeelseDartBond.Model.DataTransferObjects
{
    public class ResultCaptain
    {
        public ResultCaptain()
        {
        }

        [JsonProperty("position")]
        public int Position { get; set; }
        [JsonProperty("home_player")]
        public string Home { get; set; }
        [JsonProperty("out_player")]
        public string Away { get; set; }
        [JsonProperty("result")]
        public string Score { get; set; }
    }
}
