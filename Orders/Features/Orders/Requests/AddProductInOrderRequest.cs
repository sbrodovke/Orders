using System.Text.Json.Serialization;
using Orders.Application.Features.Orders.Handlers;

namespace Orders.Features.Orders.Requests
{
    public class AddProductInOrderRequest : IAddProductInOrderRequest
    {
        [JsonPropertyName("order_uid")]
        public string OrderUid { get; set; }

        [JsonPropertyName("product_uid")]
        public string ProductUid { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }
    }
}