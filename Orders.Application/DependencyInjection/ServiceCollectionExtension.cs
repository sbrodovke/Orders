using Microsoft.Extensions.DependencyInjection;
using Orders.Application.Features.Customers.Handlers;
using Orders.Application.Features.Orders.Handlers;
using Orders.Application.Features.Products.Handlers;
using Orders.Application.Handlers;
using Orders.Application.Services;
using Orders.Domain.Customers;
using Orders.Domain.Orders;
using Orders.Domain.Products;

namespace Orders.Application.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddOrdersApplication(this IServiceCollection serviceCollection)
            => serviceCollection
                .AddRequestHandler<ICreateCustomerRequest, ICustomerDto, CreateCustomerRequestHandler>()
                .AddRequestHandler<IGetCustomerRequest, ICustomerDto, GetCustomerRequestHandler>()
                .AddRequestHandler<ICreateProductRequest, IProductDto, CreateProductRequestHandler>()
                .AddRequestHandler<IGetProductRequest, IProductDto, GetProductRequestHandler>()
                .AddRequestHandler<IAddProductInOrderRequest, IOrderDto, AddProductInOrderRequestHandler>()
                .AddRequestHandler<ICreateOrderRequest, IOrderDto, CreateOrderRequestHandler>()
                .AddRequestHandler<IGetOrderRequest, IOrderDto, GetOrderRequestHandler>();


        private static IServiceCollection AddRequestHandler<TRequest, TResponse, TRequestHandler>(
            this IServiceCollection serviceCollection)
            where TRequestHandler : class, IRequestHandler<TRequest, TResponse>
            => serviceCollection
                .AddSingleton<IRequestHandler<TRequest, TResponse>, TRequestHandler>()
                .AddSingleton<IServiceAgent, ConcreteServiceAgent<IRequestHandler<TRequest, TResponse>>>();
    }
}