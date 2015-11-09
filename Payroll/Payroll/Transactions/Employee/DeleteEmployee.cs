using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
public    class DeleteEmployee : ITransaction   
    {
        private readonly int empid ;
        public DeleteEmployee (int empid)
        {
            this.empid = empid;
        }

        public void Execute()
        {
            PayrollDatabase.DeleteEmployee(empid);
        }
    }
}
