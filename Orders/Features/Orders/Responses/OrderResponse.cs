using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Orders.Domain.Orders;
using Orders.Features.Customers.Responses;

namespace Orders.Features.Orders.Responses
{
    public class OrderResponse
    {
        public OrderResponse(IOrderDto orderDto)
        {
            OrderUid = orderDto.OrderUid;
            Customer = new CustomerResponse(orderDto.Customer);
            Positions = orderDto.Positions.Select(_ => new OrderPositionResponse(_)).ToList();
        }

        [JsonPropertyName("uid")]
        public string OrderUid { get; }

        [JsonPropertyName("customer")]
        public CustomerResponse Customer { get; }

        [JsonPropertyName("positions")]
        public IReadOnlyList<OrderPositionResponse> Positions { get; }
    }
}