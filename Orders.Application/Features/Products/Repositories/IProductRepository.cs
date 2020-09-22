using Orders.Domain.Products;

namespace Orders.Application.Features.Products.Repositories
{
    public interface IProductRepository
    {
        public Product GetProduct(string productUid);

        public Product AddProduct(Product product);
    }
}