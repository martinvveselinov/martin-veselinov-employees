using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirma_Task
{
    class WorkedTogether
    {
        private List<Tuple<Employee, Employee>> tuples;
        private int emp1;
        private int emp2;
        private int proj;
        private double worktime;
        public WorkedTogether()
        {
            tuples = new List<Tuple<Employee, Employee>>();
            emp1 = -1;
            emp2 = -1;
            proj = -1;
            worktime = -1;
        }
        public void AddTouple(Employee emp1, Employee emp2)
        {
           Tuple<Employee, Employee> t = new Tuple<Employee, Employee>(emp1, emp2);
           tuples.Add(t);
        }
        public double GetWorkTime(Tuple<Employee, Employee> t)
        {
            DateTime emp1Start = t.Item1.getStartDate();
            DateTime emp1End = t.Item1.getFinalDate();
            DateTime emp2Start = t.Item2.getStartDate();
            DateTime emp2End= t.Item2.getFinalDate();
            DateTime maxStart = emp1Start > emp2Start ? emp1Start : emp2Start;
            DateTime minEnd = emp1End < emp2End? emp1End : emp2End;
            TimeSpan interval = minEnd - maxStart;
            double totalDays = interval > TimeSpan.FromSeconds(0) ? interval.TotalDays : 0;
            return totalDays;
        }
        public void GetMaxWorkTime()
        {
            double max = double.MinValue;
            foreach(var tuple in tuples)
            {
                double time = GetWorkTime(tuple);
                if (time >= max)
                {
                    max = time;
                    emp1 = tuple.Item1.getEmpID();
                    emp2 = tuple.Item2.getEmpID();
                    proj = tuple.Item1.getProjID();
                    worktime = max;
                }
            }
            Console.WriteLine($"Employee {emp1} and employee {emp2} have worked together in project {proj} for {worktime} days, which is the longest of all employees.");
        }
        public void PrintRelations()
        {
            foreach (var rel in tuples)
            {
                Console.WriteLine($"{rel.Item1.getEmpID()} has worked with {rel.Item2.getEmpID()}");
            }
        }
    }
}
