using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirma_Task
{
    class WorkedTogether
    {
        public List<Tuple<Employee, Employee>> tuples;
        private int emp1;
        private int emp2;

        public WorkedTogether()
        {
            tuples = new List<Tuple<Employee, Employee>>();
            emp1 = -1;
            emp2 = -1;
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
        public bool EqualTuples(Tuple<Employee, Employee> t1, Tuple<Employee, Employee> t2)
        {
            if ((t1.Item1.getEmpID() == t2.Item1.getEmpID() && t1.Item2.getEmpID() == t2.Item2.getEmpID()) ||
                (t1.Item1.getEmpID() == t2.Item2.getEmpID() && t1.Item2.getEmpID() == t2.Item1.getEmpID()))
             return true;
            
            else return false;            
        }
        public void GetMaxWorkTime()
        {
            List<Tuple<Employee, Employee>> workedtogether = new();
            List<double> worktime = new();
            worktime.Add(GetWorkTime(tuples[0]));
            workedtogether.Add(tuples[0]);
            double max = worktime[0];
            int maxInd = 0;
            for(int i = 1; i < tuples.Count; ++i)
            {
                for(int j = 0; j < workedtogether.Count; ++j)
                {
                    if (EqualTuples(tuples[i], workedtogether[j]))
                    {
                        worktime[j] += GetWorkTime(tuples[i]);
                        if (worktime[j] > max)
                        {
                            max = worktime[j];
                            maxInd = j;
                        }
                    }
                }
                workedtogether.Add(tuples[i]);
                worktime.Add(GetWorkTime(tuples[i]));
                }
            emp1 = workedtogether[maxInd].Item1.getEmpID();
            emp2 = workedtogether[maxInd].Item2.getEmpID();
            Console.WriteLine($"Employee {emp1} and employee {emp2} have worked the longest together: {worktime[maxInd]} days total.");
        }
    }
}
