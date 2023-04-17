using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MoveOrders.Models.BaseLinkerModels
{
    public class BaseLinkerOrder
    {
        [JsonProperty("order_status_id")]
        public int OrderStatusId { get; set; }

        [JsonProperty("custom_source_id")]
        public int CustomSourceId { get; set; }

        [JsonProperty("date_add")]
        public int DateAdd { get; set; }
              
        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("delivery_address")]
        public string DeliveryAddress { get; set; }  

        [JsonProperty("extra_field_1")]
        public string ExtraField1 { get; set; }
               
        [JsonProperty("products")]
        public List<Product> Products { get; set; }
    }
}