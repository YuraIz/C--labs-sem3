using System.Collections.Generic;

namespace _053505_Izmer_lab8.Entities
{
    class EmployeeComparer : IComparer<Employee>
    {
        public int Compare(Employee? x, Employee? y) => y!.Name.CompareTo(x!.Name);
    }
}