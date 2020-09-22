using Orders.Application.Features.Products.Repositories;
using Orders.Application.Handlers;
using Orders.Application.Utils;
using Orders.Domain.Products;

namespace Orders.Application.Features.Products.Handlers
{
    public class CreateProductRequestHandler : IRequestHandler<ICreateProductRequest, IProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUidGenerator _uidGenerator;

        public CreateProductRequestHandler(IUidGenerator uidGenerator, IProductRepository productRepository)
        {
            _uidGenerator = uidGenerator;
            _productRepository = productRepository;
        }

        public IProductDto Handle(ICreateProductRequest request)
        {
            var uid = _uidGenerator.GetUid();
            var product = new Product(uid, request.Name);
            return _productRepository.AddProduct(product);
        }
    }
}