using System;
using Newtonsoft.Json;

namespace PeelseDartBond.Model.DataTransferObjects
{
    public class Result180
    {
        public Result180()
        {
        }

        [JsonProperty("player")]
        public string Player { get; set; }
        [JsonProperty("amount")]
        public int Amount { get; set; }
    }
}
