using System.Security.Principal;
using System.Text.Json.Serialization;

namespace ECommerceAPI.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [JsonIgnore]
        public int CustomerId { get; set; }
        public string OrderDate { get; set; }
        public string DeliveryExpected { get; set; }
        public string DeliveryAddress { get; set; }

        [JsonIgnore]
        public bool ContainsGift { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
