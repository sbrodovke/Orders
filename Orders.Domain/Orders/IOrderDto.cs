using System.Collections.Generic;
using Orders.Domain.Customers;

namespace Orders.Domain.Orders
{
    public interface IOrderDto
    {
        public string OrderUid { get; }

        public ICustomerDto Customer { get; }

        public IReadOnlyList<IOrderPositionDto> Positions { get; }
    }
}