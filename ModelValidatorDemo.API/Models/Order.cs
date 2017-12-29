using ModelValidatorDemo.API.Attributes;
using Newtonsoft.Json;

namespace ModelValidatorDemo.API.Models
{
    public sealed class Order
    {
        public Order()
        {

        }
        //Ignore the unique Id for demo purposes
        [JsonIgnore]
        public int Id { get; set; }
        /// <summary>
        /// A unique numeric identifier for the order.
        /// </summary>
        [API(Required = "Order Number Required")]
        [JsonProperty("order_number")]
        public string OrderNumber { get; set; }
        /// <summary>
        //Date and time when the order was created, Must be ISO 8601 format.
        //"2017-12-31T23:59:59-00:00"
        /// </summary>
        [API(Required = "Created At Required")]
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }
        /// <summary>
        /// The three letter code (ISO 4217) for the currency used for the payment.
        /// </summary>
        [API(Required = "Currency Required")]
        [JsonProperty("currency")]
        public string Currency { get; set; }
        /// <summary>
        /// The sum/total price of all line items
        /// </summary>
        [API(Required = "Total Price Required")]
        [JsonProperty("total_price")]
        public decimal? TotalPrice { get; set; }
    }
}