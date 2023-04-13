using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MoveOrders.Models.FaireModels
{
    public class FaireRoot
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("orders")]
        public List<FaireOrder> Orders { get; set; }

        public FaireRoot()
        {
        }
    }
}

