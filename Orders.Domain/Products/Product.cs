namespace Orders.Domain.Products
{
    public class Product : IProductDto
    {
        public Product(string uid, string name)
        {
            Uid = uid;
            Name = name;
        }

        public string Uid { get; }

        public string Name { get; }
    }
}