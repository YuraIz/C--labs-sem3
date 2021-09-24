using System;
using System.Collections.Generic;
using System.Linq;
using _053506_Izmer_lab5.Collections;

namespace _053506_Izmer_lab5.Entities
{
    public class Customer
    {
        private MyCustomCollection<Product>? _products;

        public Customer(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public void Order(Product item)
        {
            if (_products == null)
                _products = new MyCustomCollection<Product>(item);
            else
                _products.Add(item);
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

        public void PrintSum()
        {
            double sum = 0;
            if (_products != null) sum += _products.Sum(product => product.Price);
            Console.WriteLine($"Sum: {sum}");
        }
    }
}