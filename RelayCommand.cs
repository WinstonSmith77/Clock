﻿using System;
using System.Diagnostics;
using System.Windows.Input;

namespace CommonStuff.WPF
{
    public class RelayCommand : ICommand
    {
        readonly Action _execute;
        readonly Func<bool> _canExecute;

        public RelayCommand(Action execute)
            : this(execute, () => true)
        {
        }

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            _execute = execute;
            _canExecute = canExecute;
        }

        [DebuggerStepThrough]
        public bool CanExecute(object dummy)
        {
            return _canExecute();
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

        public void FireCanExecuteChanged()
        {
           
        }

        public void Execute(object parameter)
        {
            _execute();
        }
    }
}