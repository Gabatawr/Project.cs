using ADONET_WPF.Infrastructure.Commands.Base;
using ADONET_WPF.Infrastructure.Services;
using ADONET_WPF.ViewModels;

namespace ADONET_WPF.Infrastructure.Commands
{
    class ConnectCommand : Command
    {
        private readonly MainWindowViewModel vm;
        public ConnectCommand(MainWindowViewModel vm) { this.vm = vm; }

        public override void Execute(object e) 
        {
            if (vm.AuthServer.AuthMethod == AuthenticationService.AuthMethods.Windows
                && vm.AuthServer.AuthenticationWindows())
            {
                // Test
                vm.SqlServer.Connection.Open();
                {
                    string db = vm.SqlServer.Connection.Database;
                    vm.LoginParam = db.Substring((db.LastIndexOf('\\') + 1), db.Length - db.LastIndexOf('\\') - 1);
                }
                //vm.SqlServer.Connection.Close();
            }

            else if (vm.AuthServer.AuthMethod == AuthenticationService.AuthMethods.SqlServer
                && vm.AuthServer.AuthenticationSqlServer())
            {
                // Test
                vm.SqlServer.Connection.Open();
                {
                    string db = vm.SqlServer.Connection.Database;
                    vm.LoginParam = db.Substring((db.LastIndexOf('\\') + 1), db.Length - db.LastIndexOf('\\') - 1);
                    vm.PasswordParam = string.Empty;
                }
                //vm.SqlServer.Connection.Close();
            }
        }

        public override bool CanExecute(object e)
        {
            return vm.AuthServer.AuthMethod == AuthenticationService.AuthMethods.Windows
                   || (vm.AuthServer.AuthMethod == AuthenticationService.AuthMethods.SqlServer
                       && string.IsNullOrEmpty(vm.LoginParam) 
                       && string.IsNullOrEmpty(vm.PasswordParam));
        }
    }
}
