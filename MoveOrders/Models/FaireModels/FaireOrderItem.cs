using System;
using Newtonsoft.Json;

namespace MoveOrders.Models.FaireModels
{
    public class FaireOrderItem
    {                   
        [JsonProperty("product_id")]
        public string ProductId { get; set; }
               
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
               
        [JsonProperty("product_name")]
        public string ProductName { get; set; }        
    }
}