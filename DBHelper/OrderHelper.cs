using ECommerceAPI.Models;
using System.Data;
using System.Data.SqlClient;

namespace ECommerceAPI.DBHelper
{
    public class OrderHelper
    {
        public OrderDetails GetLastOrderDetails(string customerId, string connectionString)
        {
            var orderDetails = new OrderDetails();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Proc_GetLatestOrder", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerId", customerId);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    orderDetails.Customer = new Customer();
                    orderDetails.Customer.FirstName = reader["FirstName"].ToString();
                    orderDetails.Customer.LastName = reader["LastName"].ToString();
                    orderDetails.Order = new Order();
                    orderDetails.Order.OrderId = Convert.ToInt32(reader["OrderId"]);
                    orderDetails.Order.OrderDate = Convert.ToDateTime(reader["OrderDate"]);
                    orderDetails.Order.DeliveryAddress = reader["DeliveryAddress"].ToString();
                    orderDetails.Order.ContainsGift = Convert.ToBoolean(reader["ContainsGift"]);
                }
                if(reader.NextResult())
                {
                    orderDetails.Order.OrderItems = new List<OrderItem>();
                    while(reader.Read())
                    {
                        OrderItem orderItem = new OrderItem();
                        orderItem.Product = new Product();
                        orderItem.Product.ProductName = reader["ProductName"].ToString();
                        orderItem.Quantity = Convert.ToInt32(reader["Quantity"]);
                        orderItem.Price = Convert.ToDouble(reader["Price"]);
                        orderDetails.Order.OrderItems.Add(orderItem);
                    }
                }

            }
            return orderDetails;
        }
    }
}
