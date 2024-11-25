using System.Text.Json.Serialization;

namespace ECommerceAPI.Models
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        [JsonIgnore]
        public int CustomerId { get; set; }
        [JsonIgnore]
        public string Email { get; set; }
        [JsonIgnore]
        public string HouseNo { get; set; }
        [JsonIgnore]
        public string Street { get; set; }
        [JsonIgnore]
        public string Town { get; set; }
        [JsonIgnore]
        public string PostCode { get; set; }
    }
}
