using _053505_Izmer_lab9.Domain.Entities;
namespace _053505_Izmer_lab9.Domain.Interfaces;
interface ISerializer
{
    IEnumerable<Library> DeSerializeByLINQ(string fileName);
    IEnumerable<Library> DeSerializeXML(string fileName);
    IEnumerable<Library> DeSerializeJSON(string fileName);
    void SerializeByLINQ(IEnumerable<Library> libs, string fileName);
    void SerializeXML(IEnumerable<Library> libs, string fileName);
    void SerializeJSON(IEnumerable<Library> libs, string fileName);
}
