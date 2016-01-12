using System;

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
