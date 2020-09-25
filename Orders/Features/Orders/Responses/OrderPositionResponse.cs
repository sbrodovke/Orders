using System.Text.Json.Serialization;
using Orders.Domain.Orders;
using Orders.Features.Products.Responses;

namespace Orders.Features.Orders.Responses
{
    public class OrderPositionResponse
    {
        public OrderPositionResponse(IOrderPositionDto orderPositionDto)
        {
            Product = new ProductResponse(orderPositionDto.Product);
            Count = orderPositionDto.Count;
        }

        [JsonPropertyName("product")]
        public ProductResponse Product { get; }

        [JsonPropertyName("count")]
        public int Count { get; }
    }
}