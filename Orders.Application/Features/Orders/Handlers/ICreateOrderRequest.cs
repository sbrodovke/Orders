using System.Collections.Generic;

namespace Orders.Application.Features.Orders.Handlers
{
    public interface ICreateOrderRequest
    {
        public string CustomerUid { get; }

        public IDictionary<string, int> Products { get; }
    }
}