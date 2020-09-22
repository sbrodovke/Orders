using System;
using System.Collections.Concurrent;
using Orders.Application.Features.Products.Repositories;
using Orders.Domain.Products;

namespace Orders.Infrastructure.Features.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly ConcurrentDictionary<string, Product> _products;

        public ProductRepository()
            => _products = new ConcurrentDictionary<string, Product>();

        public Product GetProduct(string productUid)
        {
            if (_products.TryGetValue(productUid, out var order))
                return order;
            throw new Exception();
        }

        public Product AddProduct(Product product)
        {
            if (_products.TryAdd(product.Uid, product))
                return product;

            throw new Exception();
        }
    }
}