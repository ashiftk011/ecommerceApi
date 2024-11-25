using System.Security.Principal;
using System.Text.Json.Serialization;

namespace ECommerceAPI.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [JsonIgnore]
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryExpected { get; set; }
        public string DeliveryAddress { get; set; }

        [JsonIgnore]
        public bool ContainsGift { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
