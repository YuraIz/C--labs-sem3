using System;
using System.Collections.Generic;
using _053505_Izmer_lab6.Entities;

namespace _053505_Izmer_lab6
{
    class Program
    {
        static int Main()
        {
            Journal journal = new();

            //Creating product base and adding products
            ProductBase pb = new(new List<Product>() { new Product("Regular thing", 0.99) });
            journal.SaveInfo("New product: ", "Regular thing");
            pb.ListChanged += journal.SaveInfo;
            pb.NewOrder += (customer, product) => Console.WriteLine($"Customer {customer} ordered {product}");

            pb.AddProduct(new Product("Another thing", 0.49));

            //Making orders
            pb.MakeNewOrder(new Customer("Regular human"), pb.FindProduct("Regular thing")!);
            pb.MakeNewOrder(new Customer("Alien"), new[] { pb.FindProduct("Another thing")!, pb.FindProduct("Regular thing")! });

            //Getting information
            Console.WriteLine("Human's order:");
            pb.PrintOrderOfCustomer("Regular human");
            Console.WriteLine("Alien's order:");
            pb.PrintOrderOfCustomer("Alien");
            pb.PrintSumOfCustomer("Alien");

            //Printing journal
            Console.WriteLine("Registered events:");
            journal.PrintEvents();
            return 0;
        }
    }
}