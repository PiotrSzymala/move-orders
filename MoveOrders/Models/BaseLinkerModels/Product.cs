using System;
using Newtonsoft.Json;

namespace MoveOrders.Models.BaseLinkerModels
{
    public class Product
    {        
        [JsonProperty("product_id")]
        public string ProductId { get; set; }
                
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}