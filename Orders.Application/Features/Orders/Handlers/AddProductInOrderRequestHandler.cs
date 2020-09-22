using Orders.Application.Features.Orders.Repositories;
using Orders.Application.Features.Products.Repositories;
using Orders.Application.Handlers;
using Orders.Domain.Orders;

namespace Orders.Application.Features.Orders.Handlers
{
    public class AddProductInOrderRequestHandler : IRequestHandler<IAddProductInOrderRequest, IOrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public AddProductInOrderRequestHandler(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public IOrderDto Handle(IAddProductInOrderRequest request)
        {
            var order = _orderRepository.GetOrder(request.OrderUid);
            var product = _productRepository.GetProduct(request.ProductUid);
            order.AddProduct(product, request.Count);
            return _orderRepository.UpdateOrder(order);
        }
    }
}