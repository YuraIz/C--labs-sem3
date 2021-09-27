using System;
using System.Collections.Generic;
using System.Linq;

namespace _053505_Izmer_lab7.Entities
{
    public class Customer
    {
        public event Action<Product>? OrderEvent;

        private List<Product> _products = new();

        public Customer(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public void Order(Product item)
        {
            _products.Add(item);
            OrderEvent?.Invoke(item);
        }

        public void Order(IEnumerable<Product> items)
        {
            foreach (var item in items) Order(item);
        }

        public void PrintOrder()
        {
            if (_products == null) return;
            foreach (var product in _products) Console.WriteLine(product);
        }


        public Dictionary<string, double> SumPaidForEachProduct()
        {
            var productGroups = from product in _products group product by product.Name;
            Dictionary<string, double> sumPaidForEachProduct = new();
            foreach (IGrouping<string, Product> g in productGroups)
            {
                sumPaidForEachProduct.Add(g.Key, g.Sum((p) => p.Price));
            }
            return sumPaidForEachProduct;
        }

        public double Sum() => _products.Sum((p) => p.Price);

        public void PrintSum()
        {
            Console.WriteLine($"Sum: {Sum()}");
        }

        public override string ToString()
        {
            return Name;
        }
    }
}