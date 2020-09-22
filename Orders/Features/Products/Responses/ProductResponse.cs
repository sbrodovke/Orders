using System.Text.Json.Serialization;
using Orders.Domain.Products;

namespace Orders.Features.Products.Responses
{
    public class ProductResponse
    {
        public ProductResponse(IProductDto productDto)
        {
            Uid = productDto.Uid;
            Name = productDto.Name;
        }

        [JsonPropertyName("uid")]
        public string Uid { get; }

        [JsonPropertyName("name")]
        public string Name { get; }
    }
}