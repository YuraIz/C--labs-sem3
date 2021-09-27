using System.Collections.Generic;
using _053505_Izmer_lab8.Entities;

namespace _053505_Izmer_lab8.Interfaces
{
    interface IFileService
    {
        IEnumerable<Employee> ReadFile(string fileName);
        void SaveData(IEnumerable<Employee> data, string fileName);
    }
}