using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirma_Task
{
    class WorkedTogether
    {
        private List<Tuple<Employee, Employee>> _tuples;
        private int _emp1;
        private int _emp2;

        public WorkedTogether()
        {
            _tuples = new List<Tuple<Employee, Employee>>();
            _emp1 = -1;
            _emp2 = -1;
        }

        public void AddTouple(Employee emp1, Employee emp2)
        {
           Tuple<Employee, Employee> t = new Tuple<Employee, Employee>(emp1, emp2);
           _tuples.Add(t);
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
            int t11 = t1.Item1.getEmpID();
            int t12 = t1.Item2.getEmpID();
            int t21 = t2.Item1.getEmpID();
            int t22 = t2.Item2.getEmpID();
            if (((t11 == t22) && (t12 == t22)) || ((t11 == t22) && (t12 == t21)))
                return true;
            
            else return false;            
        }
        public void GetMaxWorkTime()
        {
            List<Tuple<Employee, Employee>> workedТogether = new();
            List<double> workТime = new();
            workТime.Add(GetWorkTime(_tuples[0]));
            workedТogether.Add(_tuples[0]);
            double max = workТime[0];
            int maxInd = 0;
            for(int i = 1; i < _tuples.Count; ++i)
            {
                for(int j = 0; j < workedТogether.Count; ++j)
                {
                    if (EqualTuples(_tuples[i], workedТogether[j]))
                    {
                        workТime[j] += GetWorkTime(_tuples[i]);
                        if (workТime[j] > max)
                        {
                            max = workТime[j];
                            maxInd = j;
                        }
                    }
                }
                workedТogether.Add(_tuples[i]);
                workТime.Add(GetWorkTime(_tuples[i]));
                }
            _emp1 = workedТogether[maxInd].Item1.getEmpID();
            _emp2 = workedТogether[maxInd].Item2.getEmpID();
            Console.WriteLine($"Employee {_emp1} and employee {_emp2} have worked the longest together: {workТime[maxInd]} days total.");
        }
    }
}
