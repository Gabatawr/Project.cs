using System.Windows;
using System.Windows.Input;
using WPF_EFCore_1.Infrastructure.Commands.Base;

namespace WPF_EFCore_1.Infrastructure.Commands
{
    class MoveAppCommand : Command
    {
        public override void Execute(object p) => Application.Current.MainWindow?.DragMove();
        public override bool CanExecute(object p)
            => ((p as MouseEventArgs).Source as FrameworkElement) == Application.Current.MainWindow;
    }
}
