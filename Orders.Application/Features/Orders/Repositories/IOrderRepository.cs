using Orders.Domain.Orders;

namespace Orders.Application.Features.Orders.Repositories
{
    public interface IOrderRepository
    {
        public Order AddOrder(Order order);

        public Order GetOrder(string uid);

        public Order UpdateOrder(Order order);
    }
}