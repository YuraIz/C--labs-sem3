using System;
using System.Collections.Generic;
using _053505_Izmer_lab7.Entities;

Journal journal = new();

//Creating product base and adding products
ProductBase pb = new(new List<Product>() { new Product("Regular thing", 0.99) });
journal.SaveInfo("New product: ", "Regular thing");
pb.ListChanged += journal.SaveInfo;
pb.NewOrder += (customer, product) => Console.WriteLine($"Customer {customer} ordered {product}");

pb.AddProduct(new Product("Another thing", 0.49));
pb.AddProduct(new Product("Awesome thing", 0.49));

//Making orders
pb.MakeNewOrder(new Customer("Regular human"), pb.FindProduct("Regular thing")!);
pb.MakeNewOrder(
    new Customer("Alien"),
    new[] {
            pb.FindProduct("Another thing")!,
            pb.FindProduct("Regular thing")!,
            pb.FindProduct("Regular thing")!,
            pb.FindProduct("Awesome thing")!
          }
        );

//Getting information
Console.WriteLine("Human's order:");
pb.PrintOrderOfCustomer("Regular human");
Console.WriteLine("Alien's order:");
pb.PrintOrderOfCustomer("Alien");
pb.PrintSumOfCustomer("Alien");

//New lab7 methods
Console.WriteLine("Product names sorted by price");
var productNamesByPrice = pb.ProductNamesByPrice();
foreach (string name in productNamesByPrice)
{
    Console.WriteLine(name);
}
Console.WriteLine($"Sum of sold products is {pb.SumOfSoldProducts()}");
Console.Write($"Sum of ordered products by {pb.NameOfTheBestCustomer()} is ");
pb.PrintSumOfCustomer(pb.NameOfTheBestCustomer());

Console.WriteLine($"Count of customers who paid more than one is {pb.CountOfCustomersWhoPaidMoreThan(1)}");

Console.WriteLine("Sum for each product of Regular human is:");
pb.PrintSumForEachProductOfCustomer("Regular human");

//Printing journal
Console.WriteLine("Registered events:");
journal.PrintEvents();

return 0;