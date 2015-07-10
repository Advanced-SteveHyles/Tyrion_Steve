using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ResharperOnly
{
    public class CountingEngine
    {
        readonly IPowercounter powerCounter;
        private int result;

        public CountingEngine()
        {
            IEnumerable<string> thingsToSearch = new List<string> {"2", "3"};

            this.powerCounter = new Powercounter()
                .SearchItems(thingsToSearch)
                .SearchCriteria("Test")
                .Search();        
        }

        private static void DisplayValues(int result)
        {
            for (var i = 0; i < result; i++)
            {
                Console.WriteLine("Another {0} was found", i);
            }
        }

        public void Invoke()
        {            
            this.result = powerCounter.GetResult();

        }

        private void Output()
        {
            DisplayValues(result);            
        }

    }
}
