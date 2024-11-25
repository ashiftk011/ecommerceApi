namespace ECommerceAPI.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
