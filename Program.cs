using System;
using System.Collections.Generic;
using System.IO;
using _053505_Izmer_lab8.Entities;

var employees = new List<Employee>()
{
    new Employee(21, "Igor", true),
    new Employee(30, "Alex", true),
    new Employee(21, "Oleg", true),
    new Employee(18, "Anna", true),
    new Employee(42, "Artyom", false),
};

FileService fileService = new();

File.Create("./bin/employees-data").Close();

fileService.SaveData(employees, "./bin/employees-data");

File.Delete("./bin/employees-data-other");
File.Move("./bin/employees-data", "./bin/employees-data-other");

List<Employee> newEmployees = new();

foreach (var employee in fileService.ReadFile("./bin/employees-data-other"))
{
    newEmployees.Add(employee);
}

newEmployees.Sort(new EmployeeComparer());

Console.WriteLine("Old employees:");
foreach (var employee in employees)
{
    Console.WriteLine($"{employee.Age} {employee.Name} {employee.IsProgrammer}");
}

Console.WriteLine("Sorted employees:");
foreach (var employee in employees)
{
    Console.WriteLine($"{employee.Age} {employee.Name} {employee.IsProgrammer}");
}