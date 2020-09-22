using Orders.Application.Features.Products.Repositories;
using Orders.Application.Handlers;
using Orders.Domain.Products;

namespace Orders.Application.Features.Products.Handlers
{
    public class GetProductRequestHandler : IRequestHandler<IGetProductRequest, IProductDto>
    {
        private readonly IProductRepository _productRepository;

        public GetProductRequestHandler(IProductRepository productRepository)
            => _productRepository = productRepository;

        public IProductDto Handle(IGetProductRequest request)
            => _productRepository.GetProduct(request.Uid);
    }
}