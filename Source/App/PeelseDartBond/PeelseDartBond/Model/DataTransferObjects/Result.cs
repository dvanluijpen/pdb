using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PeelseDartBond.Model.DataTransferObjects
{
    public class Result
    {
        public Result()
        {
        }

        [JsonProperty("home_team")]
        public string TeamHome { get; set; }
        [JsonProperty("out_team")]
        public string TeamAway { get; set; }
        [JsonProperty("result")]
        public string Score { get; set; }
        [JsonProperty("singles")]
        public List<ResultSingle> Singles { get; set; }
        [JsonProperty("doubles")]
        public List<ResultDouble> Doubles { get; set; }
        [JsonProperty("captain_games")]
        public List<ResultCaptain> Captains { get; set; }
        [JsonProperty("team_games")]
        public List<ResultTeam> Teams { get; set; }
        [JsonProperty("one_hundred_and_eighties")]
        public List<Result180> Player180s { get; set; }
        [JsonProperty("high_finishes")]
        public List<ResultFinish> PlayerFinishes { get; set; }
    }
}
