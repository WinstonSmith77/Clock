using System;
using System.Diagnostics;
using System.Windows.Input;

namespace CommonStuff.WPF
{
    public class RelayCommand(Action execute, Func<bool> canExecute) : ICommand
    {
        private readonly Action _execute = execute ?? throw new ArgumentNullException(nameof(execute));

        public RelayCommand(Action execute)
            : this(execute, () => true)
        {
        }

        [DebuggerStepThrough]
        public bool CanExecute(object dummy)
        {
            return canExecute();
        }

        public event EventHandler CanExecuteChangedInner;

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CanExecuteChangedInner += value;
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CanExecuteChangedInner -= value;
                CommandManager.RequerySuggested -= value;
            }
        }

        public void Execute(object parameter)
        {
            _execute();
        }
    }
}