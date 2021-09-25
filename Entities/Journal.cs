using System;
using System.Collections.Generic;
namespace _053505_Izmer_lab6.Entities
{
    class Journal
    {
        List<(string, string)> EventsInfo = new();

        public void SaveInfo(string description, string entityName)
        {
            EventsInfo.Add((description, entityName));
        }

        public void PrintEvents()
        {
            EventsInfo.ForEach((e) => Console.WriteLine(e.Item1 + e.Item2));
        }
    }
}