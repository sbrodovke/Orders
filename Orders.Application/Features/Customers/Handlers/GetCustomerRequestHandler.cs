using Orders.Application.Features.Customers.Repositories;
using Orders.Application.Handlers;
using Orders.Domain.Customers;

namespace Orders.Application.Features.Customers.Handlers
{
    public class GetCustomerRequestHandler : IRequestHandler<IGetCustomerRequest, ICustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerRequestHandler(ICustomerRepository customerRepository)
            => _customerRepository = customerRepository;

        public ICustomerDto Handle(IGetCustomerRequest request)
            => _customerRepository.GetCustomer(request.Uid);
    }
}