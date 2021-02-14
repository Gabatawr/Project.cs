using System.Windows;
using WPF_EFCore_1.Infrastructure.Commands.Base;

namespace WPF_EFCore_1.Infrastructure.Commands
{
    class MinimizeAppCommand : Command
    {
        public override void Execute(object p)
            => Application.Current.MainWindow.WindowState = WindowState.Minimized;
        public override bool CanExecute(object p) => true;
    }
}
