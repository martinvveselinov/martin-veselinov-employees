using System;
using System.IO;
using System.Collections.Generic;

namespace Sirma_Task
{
    public class Employee
    {
        private int empID;
        private int projID;
        private DateTime from;
        private DateTime to;
        public Employee(int empID, int projID, DateTime from, DateTime to){
            this.empID = empID;
            this.projID = projID;
            this.from = from;
            this.to = to;
        }
        public int getEmpID()
        {
            return empID;
        }
        public int getProjID()
        {
            return projID;
        }
        public DateTime getStartDate()
        {
            return from;
        }
        public DateTime getFinalDate()
        {
            return to;
        }
    }
}
