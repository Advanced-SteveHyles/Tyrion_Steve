using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IMediator
    {
        void RegisterInterest(int msgID, Action<object> callback, object caller);

        void InformChange(int msgID, object payload, object caller);
    }
}