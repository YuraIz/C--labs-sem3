<<<<<<< HEAD
﻿using System;
using _053505_Izmer_lab6.Collections;
using _053505_Izmer_lab6.Entities;

namespace _053505_Izmer_lab6
{
    class Program
    {
        static int Main()
        {
            Journal journal = new();

            //Creating product base and adding products
            ProductBase pb = new(new MyCustomCollection<Product>(new Product("Regular thing", 0.99)));
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
=======
﻿using System.Text.Json;
using Domain.Entities;

Serializer serializer = new();


List<Library> libs = new();
for (int i = 0; i < 3; i++)
{
    Library lib = new();
    for (int j = 0; j < 2; j++)
    {
        BookDepository bd = new();
        for (int k = 0; k < j + 1; k++)
        {
            Book book = new Book { Name = "book", PageCount = 15 };
            bd.Add(book);
        }
        lib.Add(bd);
    }
    libs.Add(lib);
}

string orig = JsonSerializer.Serialize<IEnumerable<Library>>(libs);


serializer.SerializeJSON(libs, "./libraries.json");
var libsFromJsom = serializer.DeSerializeJSON("./libraries.json");

serializer.SerializeXML(libs, "./libraries.xml");
var libsFromXml = serializer.DeSerializeXML("./libraries.xml");

serializer.SerializeByLINQ(libs, "./libraries-linq.xml");
var libsFromLinq = serializer.DeSerializeByLINQ("./libraries-linq.xml");

Console.WriteLine("JSON:" + (orig.Equals(JsonSerializer.Serialize<IEnumerable<Library>>(libsFromJsom)) ? "Success" : "Fail"));
Console.WriteLine("XML:" + (orig.Equals(JsonSerializer.Serialize<IEnumerable<Library>>(libsFromXml)) ? "Success" : "Fail"));
Console.WriteLine("LINQ:" + (orig.Equals(JsonSerializer.Serialize<IEnumerable<Library>>(libsFromLinq)) ? "Success" : "Fail"));
>>>>>>> 5d271a3 (lab9 finished)
