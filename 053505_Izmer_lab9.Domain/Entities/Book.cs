namespace _053505_Izmer_lab9.Domain.Entities;
public class Book
{
    string Name;
    int PageCount;
    public Book(string name, int pageCount)
    {
        PageCount = pageCount;
        Name = name;
    }
}
