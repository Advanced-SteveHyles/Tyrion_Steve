using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new ServiceReference1.HelloWorldServiceClient();

            var reply = x.About();
            Console.WriteLine(reply);

            var name = "Steve";
            reply = x.SayHello(name);
            Console.WriteLine(reply);
        }
    }
}
