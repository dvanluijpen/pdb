using System;
using Newtonsoft.Json;

namespace PeelseDartBond.Model.DataTransferObjects
{
    public class ResultTeam
    {
        public ResultTeam()
        {
        }

        [JsonProperty("position")]
        public int Position { get; set; }
        [JsonProperty("home_team")]
        public string Home { get; set; }
        [JsonProperty("out_team")]
        public string Away { get; set; }
        [JsonProperty("result")]
        public string Score { get; set; }
    }
}
