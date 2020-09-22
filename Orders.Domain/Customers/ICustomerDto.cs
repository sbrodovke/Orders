namespace Orders.Domain.Customers
{
    public interface ICustomerDto
    {
        public string Uid { get; }

        public string Name { get; }
    }
}