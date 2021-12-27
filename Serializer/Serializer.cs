using System.IO;
using System.Text.Json;
using System.Xml.Linq;
using System.Xml.Serialization;
using Domain.Entities;
public class Serializer : Domain.Interfaces.ISerializer
{
    public void Thing()
    {
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
        SerializeJSON(libs, "./libraries.json");
        libs = new();
        foreach (Library item in DeSerializeJSON("./libraries.json"))
            libs.Add(item);
        Console.WriteLine(JsonSerializer.Serialize<List<Library>>(libs));
        return;
    }

    private string Read(string filename)
    {
        return File.ReadAllText(filename);
    }

    private void Write(string filename, string json)
    {
        File.WriteAllText(filename, json);
        return;
    }

    public IEnumerable<Library> DeSerializeByLINQ(string fileName)
    {
        XDocument xdoc = XDocument.Load(fileName);
        var root = xdoc.Element("Root");
        List<Library> libs = new();
        foreach (var xlib in root.Elements("Library"))
        {
            Library lib = new();
            foreach (var xbd in xlib.Elements("BookDepository"))
            {
                BookDepository bd = new();
                foreach (var xbook in xbd.Elements("Book"))
                {
                    Book book = new()
                    {
                        Name = xbook.Attribute("Name").Value,
                        PageCount = int.Parse(xbook.Attribute("PageCount").Value)
                    };
                    bd.Add(book);
                }
                lib.Add(bd);
            }
            libs.Add(lib);
        }
        return libs;
    }
    public IEnumerable<Library> DeSerializeXML(string fileName)
    {
        var list = new List<Library>();
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Library>));
        using (FileStream fs = new FileStream(fileName, FileMode.Open))
            list = (List<Library>)xmlSerializer.Deserialize(fs);
        return list;
    }
    public IEnumerable<Library> DeSerializeJSON(string fileName)
    {
        var json = Read(fileName);
        var libs = JsonSerializer.Deserialize<IEnumerable<Library>>(json);
        return libs;
    }
    public void SerializeByLINQ(IEnumerable<Library> libs, string fileName)
    {
        XElement root = new("Root");
        foreach (Library lib in libs)
        {
            XElement xlib = new("Library");
            foreach (BookDepository bd in lib)
            {
                XElement xbd = new("BookDepository");
                foreach (Book book in bd)
                {
                    XElement xbook = new("Book");
                    xbook.Add(
                        new XAttribute("Name", book.Name),
                        new XAttribute("PageCount", book.PageCount)
                        );
                    xbd.Add(xbook);
                }
                xlib.Add(xbd);
            }
            root.Add(xlib);
        }
        XDocument xdoc = new(root);
        Write(fileName, xdoc.ToString());
        return;
    }
    public void SerializeXML(IEnumerable<Library> libs, string fileName)
    {
        var arr = libs.ToList();
        XmlSerializer xmlSrializer = new XmlSerializer(typeof(List<Library>));
        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            xmlSrializer.Serialize(fs, arr);
        return;
    }
    public void SerializeJSON(IEnumerable<Library> libs, string fileName)
    {
        var json = JsonSerializer.Serialize<IEnumerable<Library>>(libs);
        Write(fileName, json);
        return;
    }
}
