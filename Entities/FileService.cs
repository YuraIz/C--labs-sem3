using System.Collections.Generic;
using System.IO;
using _053505_Izmer_lab8.Interfaces;

namespace _053505_Izmer_lab8.Entities
{
    class FileService : Interfaces.IFileService
    {

        public IEnumerable<Employee> ReadFile(string fileName)
        {
            using (var reader = new BinaryReader(File.Open(fileName, FileMode.OpenOrCreate)))
            {
                while (reader.PeekChar() > -1)
                {
                    Employee employee = new();
                    employee.Age = reader.ReadInt32();
                    employee.Name = reader.ReadString();
                    employee.IsProgrammer = reader.ReadBoolean();
                    yield return employee;
                }
            }
        }

        public void SaveData(IEnumerable<Employee> data, string fileName)
        {
            using (var writer = new BinaryWriter(File.Open(fileName, FileMode.OpenOrCreate)))
            {
                foreach (var employee in data)
                {
                    writer.Write(employee.Age);
                    writer.Write(employee.Name);
                    writer.Write(employee.IsProgrammer);
                }
            }
        }
    }
}
