using System.Windows;
using System.Windows.Controls;
using ADONET_WPF.Infrastructure.Commands.Base;
using ADONET_WPF.Models;
using ADONET_WPF.ViewModels;

namespace ADONET_WPF.Infrastructure.Commands
{
    class ChangeAuthMethodCommand : Command
    {
        private readonly MainWindowViewModel vm;
        public ChangeAuthMethodCommand(MainWindowViewModel vm) { this.vm = vm; }

        public override void Execute(object e) 
        {
            if (((Button)((RoutedEventArgs)e).Source).Name == "BtnAuthSql" && vm.ConnectionMethod == ConnectionMethods.Windows)
                vm.ConnectionMethod = ConnectionMethods.SqlServer;

            else if (((Button)((RoutedEventArgs)e).Source).Name == "BtnAuthWindows" &&  vm.ConnectionMethod == ConnectionMethods.SqlServer)
                vm.ConnectionMethod = ConnectionMethods.Windows;

            vm.WinAuthParam.Color = Palitra.GetAuthMethodColor(vm.ConnectionMethod, ConnectionMethods.Windows);
            vm.SqlAuthParam.Color = Palitra.GetAuthMethodColor(vm.ConnectionMethod, ConnectionMethods.SqlServer);
        }
                
        public override bool CanExecute(object e) => true;
    }
}
