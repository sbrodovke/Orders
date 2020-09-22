using System.Text.Json.Serialization;
using Orders.Domain.Customers;

namespace Orders.Features.Customers.Responses
{
    public class CustomerResponse : ICustomerDto
    {
        public CustomerResponse(ICustomerDto customerDto)
        {
            Uid = customerDto.Uid;
            Name = customerDto.Name;
        }

        [JsonPropertyName("uid")]
        public string Uid { get; }

        [JsonPropertyName("name")]
        public string Name { get; }
    }
}