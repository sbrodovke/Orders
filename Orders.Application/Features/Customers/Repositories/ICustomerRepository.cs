using Orders.Domain.Customers;

namespace Orders.Application.Features.Customers.Repositories
{
    public interface ICustomerRepository
    {
        public Customer GetCustomer(string customerUid);

        public Customer AddCustomer(Customer customer);
    }
}