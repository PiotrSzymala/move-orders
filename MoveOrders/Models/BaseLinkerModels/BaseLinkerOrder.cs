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

        [JsonProperty("user_comments")]
        public string UserComments { get; set; }

        [JsonProperty("admin_comments")]
        public string AdminComments { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("user_login")]
        public string UserLogin { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("payment_method")]
        public string PaymentMethod { get; set; }

        [JsonProperty("payment_method_cod")]
        public bool PaymentMethodCod { get; set; }

        [JsonProperty("paid")]
        public bool Paid { get; set; }

        [JsonProperty("delivery_method")]
        public string DeliveryMethod { get; set; }

        [JsonProperty("delivery_price")]
        public float DeliveryPrice { get; set; }

        [JsonProperty("delivery_fullname")]
        public string DeliveryFullname { get; set; }

        [JsonProperty("delivery_company")]
        public string DeliveryCompany { get; set; }

        [JsonProperty("delivery_address")]
        public string DeliveryAddress { get; set; }

        [JsonProperty("delivery_city")]
        public string DeliveryCity { get; set; }

        [JsonProperty("delivery_state")]
        public string DeliveryState { get; set; }

        [JsonProperty("delivery_postcode")]
        public string DeliveryPostcode { get; set; }

        [JsonProperty("delivery_country_code")]
        public string DeliveryCountryCode { get; set; }

        [JsonProperty("delivery_point_id")]
        public string DeliveryPointId { get; set; }

        [JsonProperty("delivery_point_name")]
        public string DeliveryPointName { get; set; }

        [JsonProperty("delivery_point_address")]
        public string DeliveryPointAddress { get; set; }

        [JsonProperty("delivery_point_postcode")]
        public string DeliveryPointPostcode { get; set; }

        [JsonProperty("delivery_point_city")]
        public string DeliveryPointCity { get; set; }

        [JsonProperty("invoice_fullname")]
        public string InvoiceFullname { get; set; }

        [JsonProperty("invoice_company")]
        public string InvoiceCompany { get; set; }

        [JsonProperty("invoice_nip")]
        public string InvoiceNip { get; set; }

        [JsonProperty("invoice_address")]
        public string InvoiceAddress { get; set; }

        [JsonProperty("invoice_city")]
        public string InvoiceCity { get; set; }

        [JsonProperty("invoice_state")]
        public string InvoiceState { get; set; }

        [JsonProperty("invoice_postcode")]
        public string InvoicePostcode { get; set; }

        [JsonProperty("invoice_country_code")]
        public string InvoiceCountryCode { get; set; }

        [JsonProperty("want_invoice")]
        public bool WantInvoice { get; set; }

        [JsonProperty("extra_field_1")]
        public string ExtraField1 { get; set; }

        [JsonProperty("extra_field_2")]
        public string ExtraField2 { get; set; }

        [JsonProperty("custom_extra_fields")]
        public CustomExtraFields CustomExtraFields { get; set; }

        [JsonProperty("products")]
        public List<Product> Products { get; set; }

        public BaseLinkerOrder()
        {
        }
    }
}

