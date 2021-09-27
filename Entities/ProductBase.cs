using System;
using System.Collections.Generic;
using System.Linq;

namespace _053505_Izmer_lab7.Entities
{
    public class ProductBase
    {
        public event Action<string, string>? ListChanged;
        public event Action<Customer, Product>? NewOrder;

        List<Customer> Customers = new();
        Dictionary<String, Product> Products = new();

        public ProductBase(List<Product> products)
        {
            products.ForEach((product) => Products.Add(product.Name, product));
        }

        public string[] ProductNamesByPrice()
        {
            List<Product> pl = Products.Values.ToList();
            pl.Sort((x, y) => x.Price.CompareTo(y.Price));
            var names = new string[pl.Count];
            for (int i = 0; i < pl.Count; i++)
            {
                names[i] = pl[i].Name;
            }
            return names;
        }

        public string NameOfTheBestCustomer()
        {
            Customers.Sort((x, y) => x.Sum().CompareTo(y.Sum()));
            return Customers[0].Name;
        }

        public double CountOfCustomersWhoPaidMoreThan(double price)
        {
            int count = 0;
            Customers.Aggregate((x, y) =>
            {
                if (x.Sum() > price) count++;
                return y;
            });
            return count;
        }

        public Product FindProduct(string name) => Products[name];

        private Customer? FindCustomer(string name)
        {
            return Customers?.FirstOrDefault(customer => customer.Name == name);
        }

        public void AddProduct(Product product)
        {
            Products.Add(product.Name, product);
            ListChanged?.Invoke("New product: ", product.Name);
        }

        private void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
            ListChanged?.Invoke("New customer: ", customer.Name);
            customer.OrderEvent += (product) => NewOrder?.Invoke(customer, product);
        }

        public void PrintOrderOfCustomer(string name) => FindCustomer(name)!.PrintOrder();

        public void PrintSumOfCustomer(string name) => FindCustomer(name)!.PrintSum();

        public void MakeNewOrder(Customer customer, Product product)
        {
            AddCustomer(customer);
            customer.Order(product);
        }

        public void MakeNewOrder(Customer customer, IEnumerable<Product> products)
        {
            AddCustomer(customer);
            customer.Order(products);
        }
    }
}