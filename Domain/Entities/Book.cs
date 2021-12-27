using System.Xml.Serialization;
namespace Domain.Entities;
[Serializable]
public class Book
{
    public string? Name { get; set; }
    public int PageCount { get; set; }
}
