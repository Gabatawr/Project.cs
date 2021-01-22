using System.Windows;
using ADONET_WPF.Infrastructure.Commands.Base;

namespace ADONET_WPF.Infrastructure.Commands
{
    class MinimizeAppCommand : Command
    {
        public override void Execute(object parameter) => Application.Current.MainWindow.WindowState = WindowState.Minimized;
        public override bool CanExecute(object parameter) => true;
    }
}
