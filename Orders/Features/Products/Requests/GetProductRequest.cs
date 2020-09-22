using Orders.Application.Features.Products.Handlers;

namespace Orders.Features.Products.Requests
{
    public class GetProductRequest : IGetProductRequest
    {
        public GetProductRequest(string uid)
            => Uid = uid;

        public string Uid { get; }
    }
}