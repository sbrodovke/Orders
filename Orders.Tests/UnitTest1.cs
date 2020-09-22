using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Orders.Application.Features.Customers.Repositories;
using Orders.Application.Features.Orders.Handlers;
using Orders.Application.Features.Orders.Repositories;
using Orders.Application.Features.Products.Repositories;
using Orders.Application.Handlers;
using Orders.Infrastructure.Features.Customers;
using Orders.Infrastructure.Features.Orders;
using Orders.Infrastructure.Features.Products;

namespace Orders.Tests
{
    [TestFixture]
    public class Tests
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IOrderRepository, OrderRepository>();
            serviceCollection.AddSingleton<IProductRepository, ProductRepository>();
            serviceCollection.AddSingleton<ICustomerRepository, CustomerRepository>();
            serviceCollection.AddSingleton<IRequestHandler<ICreateOrderRequest, string>, CreateOrderRequestHandler>();
            _mediator = new Mediator(serviceCollection);
        }

        private IMediator _mediator;

        [Test]
        public void Test1()
        {
            var orderUid = _mediator.SendRequest<ICreateOrderRequest, string>(new ICreateOrderRequest("1",
                new Dictionary<string, int>
                {
                    {"1", 2},
                    {"2", 3}
                }));
            Assert.IsTrue(Guid.TryParse(orderUid, out _));
        }
    }
}