using Data;
using Data.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCreator
{
    class Program
    {
        static void Main(string[] args)
        {          
            using (var ctx = new PortfolioManagerContext())
            {
                var x = from x1 in ctx.DBGenerator select x1;

                ctx.SaveChanges();
                                
            }
            
        }
    }
}
