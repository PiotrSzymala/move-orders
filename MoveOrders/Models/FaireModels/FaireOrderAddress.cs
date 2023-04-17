using System;
using Newtonsoft.Json;

namespace MoveOrders.Models.FaireModels
{
    public class FaireOrderAddress
    {
        [JsonProperty("address1")]
        public string Address1 { get; set; }

        [JsonProperty("address2")]
        public string Address2 { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }  
    }
}