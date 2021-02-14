using System;
using System.Windows.Input;

namespace WPF_EFCore_1.Infrastructure.Commands.Base
{
    internal abstract class Command : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public abstract bool CanExecute(object p);
        public abstract void Execute(object p);
    }
}
