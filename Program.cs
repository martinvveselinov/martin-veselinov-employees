using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Sirma_Task
{
    class Program
    {
        static DateTime NullHandler(string text)
        {
            DateTime date;
            if (DateTime.TryParse(text, out date)) return date;
            else return DateTime.Today;
            
        }
        static List<Employee> ReadFile(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            List<Employee> allWorks = new List<Employee>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                int empID, projID;
                DateTime dateFrom, dateTo;
                empID = Int32.Parse(values[0]);
                projID = Int32.Parse(values[1]);
                dateFrom = DateTime.Parse(values[2]);
                dateTo = NullHandler(values[3]);
                Employee current = new Employee(empID, projID, dateFrom, dateTo);
                allWorks.Add(current);
            }
            return allWorks.OrderBy(o => o.getProjID()).ToList(); ;
        }
        static void SplitIntoProjects(out List<List<Employee>> projects, List<Employee> allWorks)
        {
            projects = new List<List<Employee>>();

            List<Employee> currentProjectWorkers = new List<Employee>();

            for (int i = 0; i < allWorks.Count; ++i)
            {
                if (i == allWorks.Count - 1)
                {
                    currentProjectWorkers.Add(allWorks[i]);
                    projects.Add(currentProjectWorkers);
                    break;
                }
                if (allWorks[i].getProjID() == allWorks[i + 1].getProjID())
                {
                    currentProjectWorkers.Add(allWorks[i]);
                }
                else
                {
                    currentProjectWorkers.Add(allWorks[i]);
                    projects.Add(currentProjectWorkers);
                    currentProjectWorkers = new List<Employee>();
                }
            }
        }
        static void GetTouples(out WorkedTogether relations, List<List<Employee>> projects)
        {
            relations = new WorkedTogether();
            foreach (var proj in projects)
            {
                for (int i = 0; i < proj.Count; ++i)
                {
                    for (int j = i+1; j < proj.Count; ++j)
                    {
                        relations.AddTouple(proj[i], proj[j]);
                    }
                }
            }
        }
        static void Main(string[] args)
        {   
            try
            {
                List<Employee> allWorks = ReadFile("data.txt");
                if(allWorks.Count == 0)
                {
                    throw new Exception("File is empty!");
                }
                SplitIntoProjects(out List<List<Employee>> projects, allWorks);
                GetTouples(out WorkedTogether relations, projects);
                relations.GetMaxWorkTime();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}
