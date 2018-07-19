using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PeelseDartBond.Model.DataTransferObjects
{
    public class MatrixRow
    {
        public MatrixRow()
        {
            Columns = new List<string>();
        }

        [JsonProperty("row_number")]
        public int RowNumber { get; set; }
        [JsonProperty("columns")]
        public List<string> Columns { get; set; }
    }
}
