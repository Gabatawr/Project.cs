using System.Windows;
using WPF_EFCore_1.Infrastructure.Commands.Base;

namespace WPF_EFCore_1.Infrastructure.Commands
{
    class MaximizeAppCommand : Command
    {
        public override void Execute(object p)
        {
            var win = Application.Current.MainWindow;
            win.WindowState = win.WindowState switch
            {
                WindowState.Normal => WindowState.Maximized,
                _ => WindowState.Normal
            };
        }
        public override bool CanExecute(object p) => true;
    }
}
