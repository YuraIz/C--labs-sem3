using System;
using _053505_Izmer_lab6.Collections;
using _053505_Izmer_lab6.Entities;

//Creating product base and adding products
ProductBase pb = new(new MyCustomCollection<Product>(new Product("Regular thing", 0.99)));
pb.Products.Add(new Product("Another thing", 0.49));

//Making orders
pb.MakeNewOrder(new Customer("Regular human"), pb.FindProduct("Regular thing")!);
pb.MakeNewOrder(new Customer("Alien"), new[] { pb.FindProduct("Another thing")!, pb.Products.Current() });

//Getting information
Console.WriteLine("Human's order:");
pb.FindCustomer("Regular human")!.PrintOrder();
Console.WriteLine("Alien's order:");
pb.FindCustomer("Alien")!.PrintOrder();
pb.FindCustomer("Alien")!.PrintSum();

return 0;