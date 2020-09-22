using Orders.Application.Features.Customers.Handlers;

namespace Orders.Features.Customers.Requests
{
    public class GetCustomerRequest : IGetCustomerRequest
    {
        public GetCustomerRequest(string uid)
            => Uid = uid;

        public string Uid { get; }
    }
}