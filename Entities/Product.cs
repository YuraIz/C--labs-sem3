namespace _053506_Izmer_lab5.Entities
{
    public class Product
    {
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }


        public string Name { get; }
        public double Price { get; }

        public override string ToString()
        {
            return $"{Name}: {Price}";
        }
    }
}