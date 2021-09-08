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
        
        public WorkedTogether()
        {

        }
        public void AddTouple(Employee emp1, Employee emp2)
        {
            Tuple<Employee, Employee> t = new Tuple<Employee, Employee>(emp1, emp2);
            tuples.Add(t);
        }
        public int GetWorkTime(Tuple<Employee, Employee> t)
        {
            int days = 0;
            return days;
        }
        public int GetMaxWorkTime()
        {
            int max = int.MinValue;
            return max;
        }
    }
}
