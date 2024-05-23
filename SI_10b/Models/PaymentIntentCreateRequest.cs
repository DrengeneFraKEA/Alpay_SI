using Newtonsoft.Json;

namespace StripeExample.Models
{
    public class PaymentIntentCreateRequest
    {
        [JsonProperty("items")]
        public Item[] Items { get; set; }

        public static int CalculateOrderAmount(Item[] items)
        {
            //int totalAmount = 0;

            //foreach (var element in items) 
            //{
            //    if (element == null || element.Amount == null) continue;
            //    totalAmount += int.Parse(element.Amount);
            //}

            //return totalAmount;

            return 1400;
        }
    }
}
