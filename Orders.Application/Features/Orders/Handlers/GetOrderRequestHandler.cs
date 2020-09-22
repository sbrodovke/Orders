using Orders.Application.Features.Orders.Repositories;
using Orders.Application.Handlers;
using Orders.Domain.Orders;

namespace Orders.Application.Features.Orders.Handlers
{
    public class GetOrderRequestHandler : IRequestHandler<IGetOrderRequest, IOrderDto>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderRequestHandler(IOrderRepository orderRepository)
            => _orderRepository = orderRepository;

        public IOrderDto Handle(IGetOrderRequest request)
            => _orderRepository.GetOrder(request.Uid);
    }
}