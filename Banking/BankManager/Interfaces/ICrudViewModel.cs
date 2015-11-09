using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
  public  interface ICrudViewModel
    {
      void Refresh();

      void SetNewCmd(Action<object> execute, Predicate<object> canExecute);
      void SetSaveCmd(Action<object> execute, Predicate<object> canExecute);
      void SetSelectCmd(Action<object> execute, Predicate<object> canExecute);
      
      int ShowSelectCmd();
    }
}
