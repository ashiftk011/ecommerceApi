using ECommerceAPI.Models;
using ECommerceAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly string _connectionString;

        public OrderController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        [HttpPost]
        public ActionResult GetLastOrder(CustomerRequest customerRequest)
        {
            OrderDBService orderDBService = new OrderDBService();

            //Validate customer details before proceeding
            if (!orderDBService.ValidateCustomer(customerRequest.User, customerRequest.CustomerId, _connectionString))
            {
                return BadRequest(new { message = "Invalid email or ID." });
            }

            return Ok(orderDBService.GetOrderDetails(customerRequest.CustomerId, _connectionString));
        }
        
    }
}
