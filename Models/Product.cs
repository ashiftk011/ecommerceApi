using System.Drawing;
using System.Security.Principal;

namespace ECommerceAPI.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
    }
}
