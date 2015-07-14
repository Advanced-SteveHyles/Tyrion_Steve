using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;

namespace IOC
{
    //http://docs.autofac.org/en/latest/getting-started/

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
            var iocModule = new IocBuilder(builder);
            Container = builder.Build();
                        
            using (var scope = Container.BeginLifetimeScope())
            {
                //scope.Resolve(ILoadParameters),  scope.Resolve (IStarter),  scope.Resolve(IReporter), scope.Resolve(ITerminator),  scope.Resolve(ICleaner)  


                var driver = new Driver(scope.Resolve<ILoadParameters>(), scope.Resolve<IStarter>(), scope.Resolve<IReporter>(), scope.Resolve<ITerminator>(), scope.Resolve<ICleaner>());
                driver.Invoke();
            }
        }
    }
}
