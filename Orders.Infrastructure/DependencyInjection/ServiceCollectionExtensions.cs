using Microsoft.Extensions.DependencyInjection;
using Orders.Application.Features.Customers.Repositories;
using Orders.Application.Features.Orders.Repositories;
using Orders.Application.Features.Products.Repositories;
using Orders.Application.Utils;
using Orders.Infrastructure.Features.Customers;
using Orders.Infrastructure.Features.Orders;
using Orders.Infrastructure.Features.Products;
using Orders.Infrastructure.Utils;

namespace Orders.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddOrdersInfrastructure(this IServiceCollection serviceCollection)
            => serviceCollection
                .AddSingleton<IOrderRepository, OrderRepository>()
                .AddSingleton<IProductRepository, ProductRepository>()
                .AddSingleton<ICustomerRepository, CustomerRepository>()
                .AddSingleton<IUidGenerator, UidGenerator>();
    }
}