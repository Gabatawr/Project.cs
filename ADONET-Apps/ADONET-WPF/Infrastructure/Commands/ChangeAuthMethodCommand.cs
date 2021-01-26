using System.Windows;
using System.Windows.Controls;
using ADONET_WPF.Infrastructure.Commands.Base;
using ADONET_WPF.Infrastructure.Services;
using ADONET_WPF.ViewModels;

namespace ADONET_WPF.Infrastructure.Commands
{
    class ChangeAuthMethodCommand : Command
    {
        private readonly MainWindowViewModel vm;
        public ChangeAuthMethodCommand(MainWindowViewModel vm) { this.vm = vm; }

        public override void Execute(object e) 
        {
            if (((Button)((RoutedEventArgs)e).Source).Name == "BtnAuthSql" 
                && vm.AuthServer.AuthMethod == AuthenticationService.AuthMethods.Windows)
            {
                vm.AuthServer.AuthMethod = AuthenticationService.AuthMethods.SqlServer;
                vm.IsUserAuthParam = true;
            }
                
            else if (((Button)((RoutedEventArgs)e).Source).Name == "BtnAuthWindows" 
                && vm.AuthServer.AuthMethod == AuthenticationService.AuthMethods.SqlServer)
            {
                vm.AuthServer.AuthMethod = AuthenticationService.AuthMethods.Windows;
                vm.IsUserAuthParam = false;
            }

            vm.WinAuthParam.Color = vm.AuthServer.GetAuthMethodColor(AuthenticationService.AuthMethods.Windows);
            vm.SqlAuthParam.Color = vm.AuthServer.GetAuthMethodColor(AuthenticationService.AuthMethods.SqlServer);
        }
                
        public override bool CanExecute(object e) => true;
    }
}
