using System.Data.SqlClient;

namespace ECommerceAPI.Models
{
    public class OrderDetails
    {
        public Customer Customer { get; set; }
        public Order Order { get; set; }
    }
}
