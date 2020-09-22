namespace Orders.Application.Services
{
    public interface IServiceAgent
    {
        public bool IsSuitable<TService>();
    }
}