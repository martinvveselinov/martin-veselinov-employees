using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Sirma_Task
{
    class Program
    {
        public static DateTime NullHandler(string text)
        {
            DateTime date;
            if (DateTime.TryParse(text, out date))
            {
                return date;
            }
            else
            {
                return DateTime.Today;
            }
        }
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("MOCK_DATA.csv"))
            {
                List<Employee> allWorks = new List<Employee>();
                while (!reader.EndOfStream)
                {   
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    int empID = Int32.Parse(values[0]);
                    int projID = Int32.Parse(values[1]);
                    DateTime dateFrom = DateTime.Parse(values[2]);
                    DateTime dateTo = NullHandler(values[3]);
                    Employee current = new Employee(empID, projID, dateFrom, dateTo);
                    allWorks.Add(current);
                }
                List<Employee> sorted = allWorks.OrderBy(o => o.getProjID()).ToList();
                List<List<Employee>> projects = new List<List<Employee>>();
                List<Employee> currentProjectWorkers = new List<Employee>();
                for (int i = 0; i < sorted.Count; ++i)
                {
                    if(i == sorted.Count - 1)
                    {
                        currentProjectWorkers.Add(sorted[i]);
                        projects.Add(currentProjectWorkers);
                        break;
                    }
                    if (sorted[i].getProjID() == sorted[i + 1].getProjID())
                    {
                        currentProjectWorkers.Add(sorted[i]);
                    }
                    else
                    {
                        currentProjectWorkers.Add(sorted[i]);
                        projects.Add(currentProjectWorkers);
                        currentProjectWorkers = new List<Employee>();
                    }
                }
                foreach (var item in sorted)
                {
                    if(projects.Count == 0)
                    {
                       // projects.Add()
                    }
                    Console.WriteLine($"{item.getEmpID()}, {item.getProjID()}, {item.getStartDate()}, {item.getFinalDate()} ");
                }
                Console.WriteLine();
                WorkedTogether relations = new WorkedTogether();
                
                foreach(var proj in projects)
                {
                    Console.WriteLine($"Project {proj[0].getProjID()} employees:");
                    foreach(var item in proj)
                    {
                        Console.WriteLine($"{item.getEmpID()}, {item.getProjID()}, {item.getStartDate()}, {item.getFinalDate()} ");

                    }
                    Console.WriteLine();
                }
                foreach (var proj in projects)
                {
                    foreach (var item in proj)
                    {
                        
                    }
                }

            }
        }
    }
}
