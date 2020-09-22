using Orders.Application.Features.Customers.Repositories;
using Orders.Application.Handlers;
using Orders.Application.Utils;
using Orders.Domain.Customers;

namespace Orders.Application.Features.Customers.Handlers
{
    public class CreateCustomerRequestHandler : IRequestHandler<ICreateCustomerRequest, ICustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUidGenerator _uidGenerator;

        public CreateCustomerRequestHandler(ICustomerRepository customerRepository, IUidGenerator uidGenerator)
        {
            _customerRepository = customerRepository;
            _uidGenerator = uidGenerator;
        }

        public ICustomerDto Handle(ICreateCustomerRequest request)
        {
            var uid = _uidGenerator.GetUid();
            var customer = new Customer(uid, request.Name);
            return _customerRepository.AddCustomer(customer);
        }
    }
}