using System.Windows;
using System.Windows.Input;
using ADONET_WPF.Infrastructure.Commands.Base;

namespace ADONET_WPF.Infrastructure.Commands
{
    class MoveAppCommand : Command
    {
        public override void Execute(object e) => Application.Current.MainWindow?.DragMove();
        public override bool CanExecute(object e) => ((FrameworkElement)((MouseEventArgs)e).Source) == Application.Current.MainWindow;
    }
}
