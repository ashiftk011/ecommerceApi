using ECommerceAPI.DBHelper;
using ECommerceAPI.Models;
using System.Data.SqlClient;

namespace ECommerceAPI.Services
{
    public class OrderDBService
    {
        OrderHelper orderHelper = new OrderHelper();

        public OrderDetails GetOrderDetails(string customerId, string connectionString)
        {
            return orderHelper.GetLastOrderDetails(customerId, connectionString);
        }

        public bool ValidateCustomer(string name, string  customerId, string connectionString)
        {
            try
                {
                    using (var connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = "SELECT COUNT(*) FROM Customers WHERE Email = @Email AND CustomerId = @CustomerId";

                        using (var command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Email", name);
                            command.Parameters.AddWithValue("@CustomerId", customerId);

                            int count = (int)command.ExecuteScalar();

                            // If count is 1, the email and customer Id match, otherwise invalid request
                            return count == 1;
                        }
                    }
                }
                catch (Exception)
                {
                    return false;
                }
        }
    }
}
