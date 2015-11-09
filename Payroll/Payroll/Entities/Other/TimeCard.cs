using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
   public class TimeCard
    {
       private readonly DateTime date;
       private readonly decimal hours;

       public TimeCard(DateTime date, decimal hours)
       {
           this.date = date;
           this.hours = hours;
       }

       public decimal Hours { get { return hours; } }
       public DateTime Date { get { return date; } }

    }
}
