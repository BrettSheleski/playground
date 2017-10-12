using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calculator.UWP
{
    public class Command : ICommand
    {
        public Command(Action action) : this(action, x => true) { }

        public Command(Action action, Predicate<object> canExecuteAction) : this(x => action(), canExecuteAction) { }

        public Command(Action<object> action) : this(action, x => true) { }

        public Command(Action<object> action, Predicate<object> canExecuteAction)
        {
            this.ExecuteFunc = action;
            this.CanExecuteFunc = canExecuteAction;
        }

        public Predicate<object> CanExecuteFunc
        {
            get;
        }

        public Action<object> ExecuteFunc
        {
            get;
        }

        public bool CanExecute(object parameter)
        {
            return CanExecuteFunc(parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            ExecuteFunc(parameter);
        }
    }

    public class Command<T> : ICommand
    {
        public Command(Action<T> action) : this(action, x => true) { }

        public Command(Action<T> action, Predicate<T> canExecuteAction)
        {
            this.ExecuteFunc = action;
            this.CanExecuteFunc = canExecuteAction;
        }

        public Predicate<T> CanExecuteFunc
        {
            get;
        }

        public Action<T> ExecuteFunc
        {
            get;
        }

        public bool CanExecute(object parameter)
        {
            return CanExecuteFunc((T)parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            ExecuteFunc((T)parameter);
        }
    }
}
