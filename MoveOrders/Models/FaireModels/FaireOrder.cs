using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MoveOrders.Models.FaireModels
{
    public class FaireOrder
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("items")]
        public List<FaireOrderItem> Items { get; set; }

        [JsonProperty("address")]
        public FaireOrderAddress Address { get; set; }

        [JsonProperty("retailer_id")]
        public string RetailerId { get; set; }

        [JsonProperty("payout_costs")]
        public FaireOrderPayoutCosts PayoutCosts { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        public FaireOrder()
        {
        }
    }
}

