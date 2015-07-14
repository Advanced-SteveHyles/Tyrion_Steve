using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace IOC
{
    class Driver
    {
        private ITerminator _terminator;
        private ICleaner _cleaner;
        private ILoadParameters _parameters;
        private IStarter _starter;
        private IReporter _reporter;

        public Driver(ILoadParameters parameters, IStarter starter,  IReporter reporter, ITerminator terminator, ICleaner cleaner)
        {
            var engine = new Engine();

            this._parameters = parameters;
            this._starter = starter;
            this._terminator = terminator;
            this._reporter = reporter;
            this._cleaner = cleaner;            
        }

        public void Invoke()
        {
            Engine.Run();
        }        
    }
}
