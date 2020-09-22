namespace Orders.Domain.Customers
{
    public class Customer : ICustomerDto
    {
        public Customer(string uid, string name)
        {
            Uid = uid;
            Name = name;
        }

        public string Uid { get; }

        public string Name { get; }
    }
}