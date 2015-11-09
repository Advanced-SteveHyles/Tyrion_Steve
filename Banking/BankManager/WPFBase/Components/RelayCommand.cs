using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFBase.Components
{
  public  class RelayCommand : ICommand
    {

        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;
        private string _name ;

        public RelayCommand(Action<object> execute)
        {
            this._canExecute = null;
            this._execute = execute;
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute, string name)
        {
           this. _canExecute = canExecute;
           this._execute = execute;
           this._name = name;
        }
        // ... etc ...
        public void Execute(object parameter)
        {
            if (_execute != null) 
            {
                _execute(parameter);
                return;
            }
            Console.WriteLine("Command Not Found " + _name );
        }

      /// <summary>
      /// This doesn't work!!!
      /// </summary>
      /// <param name="parameter"></param>
      /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            if (this._canExecute != null)
            {
                //return (bool)this._canExecute(parameter);
                return true;
                //return (bool)this._canExecute.Invoke(parameter);
            }
            else
            { return true; }

            //if (parameter == null)
            //{ return false; }
            //return (bool) parameter;
            //   throw new NotImplementedException();
        }

       public event EventHandler CanExecuteChanged;

        public void OnCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

    }
}
