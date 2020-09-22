using System.Collections.Generic;
using System.Linq;
using Orders.Domain.Customers;
using Orders.Domain.Products;

namespace Orders.Domain.Orders
{
    public class Order : IOrderDto
    {
        private readonly IList<OrderPosition> _orderPositions;

        public Order(string orderUid, Customer customer)
        {
            Customer = customer;
            OrderUid = orderUid;
            _orderPositions = new List<OrderPosition>();
        }

        public Customer Customer { get; }

        public string OrderUid { get; }

        public IReadOnlyList<IOrderPositionDto> Positions => _orderPositions.ToList();

        ICustomerDto IOrderDto.Customer => Customer;

        public void AddPosition(OrderPosition orderPosition)
            => _orderPositions.Add(orderPosition);

        public void AddProduct(Product product, int count)
        {
            var orderPosition = _orderPositions.FirstOrDefault(_ => _.Product.Uid == product.Uid);
            if (orderPosition != null)
            {
                orderPosition.Count += count;
                return;
            }

            _orderPositions.Add(new OrderPosition(product, count));
        }

        public void DeleteProduct(Product product)
        {
            var orderPosition = _orderPositions.FirstOrDefault(_ => _.Product.Uid == product.Uid);
            if (orderPosition != null)
                _orderPositions.Remove(orderPosition);
        }
    }
}