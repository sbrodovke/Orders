using System;
using System.Collections.Concurrent;
using Orders.Application.Features.Orders.Repositories;
using Orders.Domain.Orders;

namespace Orders.Infrastructure.Features.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ConcurrentDictionary<string, Order> _orders;

        public OrderRepository()
            => _orders = new ConcurrentDictionary<string, Order>();

        public Order AddOrder(Order order)
        {
            if (_orders.TryAdd(order.OrderUid, order))
                return order;

            throw new Exception();
        }

        public Order GetOrder(string uid)
        {
            if (_orders.TryGetValue(uid, out var order))
                return order;
            throw new Exception();
        }

        public Order UpdateOrder(Order order)
        {
            if (_orders.TryUpdate(order.OrderUid, order, order))
                return order;
            throw new Exception();
        }
    }
}