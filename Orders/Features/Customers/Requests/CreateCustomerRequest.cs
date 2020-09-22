using System.Text.Json.Serialization;
using Orders.Application.Features.Customers.Handlers;

namespace Orders.Features.Customers.Requests
{
    public class CreateCustomerRequest : ICreateCustomerRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}