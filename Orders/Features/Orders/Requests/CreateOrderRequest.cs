using System.Collections.Generic;
using System.Text.Json.Serialization;
using Orders.Application.Features.Orders.Handlers;

namespace Orders.Features.Orders.Requests
{
    public class CreateOrderRequest : ICreateOrderRequest
    {
        [JsonPropertyName("uid")]
        public string CustomerUid { get; set; }

        [JsonPropertyName("products")]
        public IDictionary<string, int> Products { get; set; }
    }
}