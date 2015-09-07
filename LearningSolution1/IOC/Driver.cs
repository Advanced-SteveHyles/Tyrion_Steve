using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using Autofac;

namespace IOC
{
    public class Driver
    {
        private ITerminator _terminator;
        private ICleaner _cleaner;
        private IParameters _parameters;
        private IStarter _starter;
        private IReporter _reporter;

        public Driver(IParameters parameters, IStarter starter,  IReporter reporter, ITerminator terminator, ICleaner cleaner)
        {
            var engine = new Engine();

            this._parameters = parameters;
            this._starter = starter;
            this._terminator = terminator;
            this._reporter = reporter;
            this._cleaner = cleaner;            
        }

        public Driver(IContainer container)
        {
            var engine = new Engine();

            this._parameters = container.Resolve<IParameters>();
            this._starter = container.Resolve<IStarter>();
            this._terminator = container.Resolve <ITerminator>();
            this._reporter = container.Resolve < IReporter>();
            this._cleaner = container.Resolve<ICleaner>();
        }


        public void Invoke()
        {
            Engine.Run();
        }        
    }
}
