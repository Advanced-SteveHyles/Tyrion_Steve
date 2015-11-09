using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll 
{
    public class TimecardTransaction : ITransaction
    {
        private readonly DateTime date;
        private readonly  decimal hoursWorked ;
        private readonly int empid;

        public TimecardTransaction(DateTime timecarddate, decimal hoursWorked, int empid)
        {
            this.date = timecarddate;
            this.hoursWorked = hoursWorked;
            this.empid = empid;
        }

        public void Execute()
        {
            Employee e = PayrollDatabase.GetEmployee(empid);

            if (e != null)
            {
                HourlyClasssification hc = e.Classification as HourlyClasssification;

                if (hc !=null)
                {
                    hc.AddTimeCard(new TimeCard (date, hoursWorked));
                }
                else
                {
                    throw new InvalidOperationException("Tried to add timecard to non-hourly employee.");
                }
            }
            else
            {
                throw new InvalidOperationException("No such employee.");
            }
        }     
    }
}