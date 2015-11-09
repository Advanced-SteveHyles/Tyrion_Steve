using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IIOCContainer
    {
        object GetInstance(Type type);
        object GetInstance(string type);

        object GetSingleInstance(string type);    
    }
}
