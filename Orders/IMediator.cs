namespace Orders
{
    public interface IMediator
    {
        public TResponse SendRequest<TRequest, TResponse>(TRequest request);
    }
}