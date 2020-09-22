using Orders.Domain.Products;

namespace Orders.Domain.Orders
{
    public class OrderPosition : IOrderPositionDto
    {
        public OrderPosition(Product product)
            => Product = product;

        public OrderPosition(Product product, int count) : this(product)
            => Count = count;

        public Product Product { get; }

        public int Count { get; set; }

        IProductDto IOrderPositionDto.Product => Product;
    }
}