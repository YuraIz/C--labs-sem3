using System.Text.Json;
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