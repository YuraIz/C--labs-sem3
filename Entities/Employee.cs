namespace _053505_Izmer_lab8.Entities
{
    class Employee
    {
        public Employee()
        {
            Age = 0;
            Name = "";
            IsProgrammer = false;
        }
        public Employee(int age, string name, bool isProgrammer)
        {
            Age = age;
            Name = name;
            IsProgrammer = isProgrammer;
        }
        public int Age;
        public string Name;
        public bool IsProgrammer;
    }
}