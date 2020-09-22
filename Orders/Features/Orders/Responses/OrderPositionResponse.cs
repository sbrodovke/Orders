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

        public ProductResponse Product { get; }

        public int Count { get; }
    }
}