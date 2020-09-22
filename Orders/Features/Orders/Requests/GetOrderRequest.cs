using Orders.Application.Features.Orders.Handlers;

namespace Orders.Features.Orders.Requests
{
    public class GetOrderRequest : IGetOrderRequest
    {
        public GetOrderRequest(string uid)
            => Uid = uid;

        public string Uid { get; }
    }
}