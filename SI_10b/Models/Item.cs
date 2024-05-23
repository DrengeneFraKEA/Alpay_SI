using Newtonsoft.Json;

namespace StripeExample.Models
{
    public class Item
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("Amount")]
        public string Amount { get; set; }
    }
}
