using System.Windows;
using WPF_EFCore_1.Infrastructure.Commands.Base;

namespace WPF_EFCore_1.Infrastructure.Commands
{
    class CloseAppCommand : Command
    {
        public override void Execute(object p) => Application.Current.Shutdown();
        public override bool CanExecute(object p) => true;
    }
}
