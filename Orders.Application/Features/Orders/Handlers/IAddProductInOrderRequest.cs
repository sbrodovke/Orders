namespace Orders.Application.Features.Orders.Handlers
{
    public interface IAddProductInOrderRequest
    {
        public string OrderUid { get; }

        public string ProductUid { get; }

        public int Count { get; }
    }
}