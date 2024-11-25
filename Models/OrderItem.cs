using System.Text.Json.Serialization;

namespace ECommerceAPI.Models
{
    public class OrderItem
    {
        [JsonIgnore]
        public int OrderItemId { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public double PriceEach { get; set; }
    }
}
