using System.Collections.Generic;
using System.Linq;
using _053505_Izmer_lab8.Collections;

namespace _053505_Izmer_lab8.Entities
{
    public class ProductBase
    {
        public MyCustomCollection<Customer>? Customers;
        public MyCustomCollection<Product> Products;

        public ProductBase(MyCustomCollection<Product> products)
        {
            Products = products;
        }

        public Product? FindProduct(string name)
        {
            return Products.FirstOrDefault(product => product.Name == name);
        }

        public Customer? FindCustomer(string name)
        {
            return Customers?.FirstOrDefault(customer => customer.Name == name);
        }

        public void MakeNewOrder(Customer customer, Product product)
        {
            if (Customers == null)
                Customers = new MyCustomCollection<Customer>(customer);
            else
                Customers.Add(customer);
            customer.Order(product);
        }

        public void MakeNewOrder(Customer customer, IEnumerable<Product> products)
        {
            if (Customers == null)
                Customers = new MyCustomCollection<Customer>(customer);
            else
                Customers.Add(customer);
            customer.Order(products);
        }
    }
}