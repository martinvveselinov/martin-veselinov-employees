using System;
using System.IO;
using System.Collections.Generic;

namespace Sirma_Task
{
    public class Employee
    {
        private int _empID;
        private int _projID;
        private DateTime _from;
        private DateTime _to;

        public Employee(int empID, int projID, DateTime from, DateTime to){
            _empID = empID;
            _projID = projID;
            _from = from;
            _to = to;
        }

        public int getEmpID()
        {
            return _empID;
        }
        public int getProjID()
        {
            return _projID;
        }
        public DateTime getStartDate()
        {
            return _from;
        }
        public DateTime getFinalDate()
        {
            return _to;
        }
    }
}
