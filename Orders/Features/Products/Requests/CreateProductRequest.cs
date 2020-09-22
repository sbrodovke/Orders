using System.Text.Json.Serialization;
using Orders.Application.Features.Products.Handlers;

namespace Orders.Features.Products.Requests
{
    public class CreateProductRequest : ICreateProductRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}