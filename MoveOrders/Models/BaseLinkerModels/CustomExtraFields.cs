using System;
using Newtonsoft.Json;

namespace MoveOrders.Models.BaseLinkerModels
{
    public class CustomExtraFields
    {
        [JsonProperty("135")]
        public string _135 { get; set; }

        [JsonProperty("172")]
        public string _172 { get; set; }

        public CustomExtraFields()
        {
        }
    }
}

