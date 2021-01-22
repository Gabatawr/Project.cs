using System.Windows;
using ADONET_WPF.Infrastructure.Commands.Base;

namespace ADONET_WPF.Infrastructure.Commands
{
    class CloseAppCommand : Command
    {
        public override void Execute(object parameter) => Application.Current.Shutdown();
        public override bool CanExecute(object parameter) => true;
    }
}
