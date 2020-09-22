using System;
using System.Collections.Concurrent;
using Orders.Application.Features.Customers.Repositories;
using Orders.Domain.Customers;

namespace Orders.Infrastructure.Features.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ConcurrentDictionary<string, Customer> _customers;

        public CustomerRepository()
            => _customers = new ConcurrentDictionary<string, Customer>();

        public Customer GetCustomer(string customerUid)
        {
            if (_customers.TryGetValue(customerUid, out var order))
                return order;

            throw new Exception();
        }

        public Customer AddCustomer(Customer customer)
        {
            if (_customers.TryAdd(customer.Uid, customer))
                return customer;

            throw new Exception();
        }
    }
}