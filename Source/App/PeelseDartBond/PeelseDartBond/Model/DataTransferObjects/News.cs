using System;
using Newtonsoft.Json;

namespace PeelseDartBond.Model.DataTransferObjects
{
    public class News
    {
        public News()
        {
        }

        [JsonProperty("details")]
        public string Title { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("start_date")]
        public DateTime Date { get; set; }
    }
}
