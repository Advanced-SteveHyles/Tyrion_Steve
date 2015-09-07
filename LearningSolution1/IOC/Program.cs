using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;

namespace IOC
{
    //http://docs.autofac.org/en/latest/getting-started/
    //http://www.codeproject.com/Articles/25380/Dependency-Injection-with-Autofac

    static class Program
    {
        private static IContainer Container { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var builder = new ContainerBuilder();
            Container = builder.Build();
                        
            using (var scope = Container.BeginLifetimeScope())
            {
                var driver = new Driver(scope.Resolve<IParameters>(), scope.Resolve<IStarter>(), scope.Resolve<IReporter>(), scope.Resolve<ITerminator>(), scope.Resolve<ICleaner>());
                driver.Invoke();                
            }

            using (Container)
            {
                var driver = new Driver(Container);
                driver.Invoke();
            }
        }
    }
}
