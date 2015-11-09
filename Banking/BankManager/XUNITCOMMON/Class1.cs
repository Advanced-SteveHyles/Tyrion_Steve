using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUNITCOMMON
{
    protected class XUnitTest
    {
        protected      IRepository _resp;
        void XUnitTest()
        {
            _resp = new Repository.ViewModelRepository();
        }
    }
}
