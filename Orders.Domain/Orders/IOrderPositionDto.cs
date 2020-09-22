using Orders.Domain.Products;

namespace Orders.Domain.Orders
{
    public interface IOrderPositionDto
    {
        public IProductDto Product { get; }

        public int Count { get; }
    }
}