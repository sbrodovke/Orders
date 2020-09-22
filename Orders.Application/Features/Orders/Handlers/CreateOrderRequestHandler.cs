using Orders.Application.Features.Customers.Repositories;
using Orders.Application.Features.Orders.Repositories;
using Orders.Application.Features.Products.Repositories;
using Orders.Application.Handlers;
using Orders.Application.Utils;
using Orders.Domain.Orders;

namespace Orders.Application.Features.Orders.Handlers
{
    public class CreateOrderRequestHandler : IRequestHandler<ICreateOrderRequest, IOrderDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUidGenerator _uidGenerator;

        public CreateOrderRequestHandler(IUidGenerator uidGenerator, IProductRepository productRepository,
            IOrderRepository orderRepository, ICustomerRepository customerRepository)
        {
            _uidGenerator = uidGenerator;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
        }

        public IOrderDto Handle(ICreateOrderRequest request)
        {
            var uid = _uidGenerator.GetUid();
            var customer = _customerRepository.GetCustomer(request.CustomerUid);
            var order = new Order(uid, customer);

            foreach (var (productUid, count) in request.Products)
            {
                var product = _productRepository.GetProduct(productUid);
                order.AddProduct(product, count);
            }

            return _orderRepository.AddOrder(order);
        }
    }
}