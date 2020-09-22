namespace Orders.Application.Handlers
{
    public interface IRequestHandler<in TRequest, out TResponse>
    {
        public TResponse Handle(TRequest request);
    }
}