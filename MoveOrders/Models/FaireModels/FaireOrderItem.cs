using System;
using Newtonsoft.Json;

namespace MoveOrders.Models.FaireModels
{
    public class FaireOrderItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        [JsonProperty("product_id")]
        public string ProductId { get; set; }

        [JsonProperty("variant_id")]
        public string VariantId { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("price_cents")]
        public int PriceCents { get; set; }

        [JsonProperty("product_name")]
        public string ProductName { get; set; }

        [JsonProperty("variant_name")]
        public string VariantName { get; set; }

        [JsonProperty("includes_tester")]
        public bool IncludesTester { get; set; }

        public FaireOrderItem()
        {
        }
    }
}

