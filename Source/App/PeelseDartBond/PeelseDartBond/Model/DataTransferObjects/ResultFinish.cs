using System;
using Newtonsoft.Json;

namespace PeelseDartBond.Model.DataTransferObjects
{
    public class ResultFinish
    {
        public ResultFinish()
        {
        }

        [JsonProperty("player")]
        public string Player { get; set; }
        [JsonProperty("finish")]
        public string Finish { get; set; }
    }
}
