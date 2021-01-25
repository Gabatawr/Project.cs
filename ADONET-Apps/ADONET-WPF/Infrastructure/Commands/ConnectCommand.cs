using ADONET_WPF.Infrastructure.Commands.Base;
using ADONET_WPF.Infrastructure.Services;
using ADONET_WPF.Models;
using ADONET_WPF.ViewModels;

namespace ADONET_WPF.Infrastructure.Commands
{
    class ConnectCommand : Command
    {
        private readonly MainWindowViewModel vm;
        public ConnectCommand(MainWindowViewModel vm) { this.vm = vm; }

        public override void Execute(object e) 
        {
            

            if (AuthenticationService.AuthenticationWindows())
            {
                vm.ConnectColorParam.Color = Palitra.Connect;

                // Test
                SqlService.Connection.Open();
                string db = SqlService.Connection.Database;
                vm.LoginParam = db.Substring((db.LastIndexOf('\\') + 1), db.Length - db.LastIndexOf('\\') - 1);
                SqlService.Connection.Close();
            }
        }
                
        public override bool CanExecute(object e) => true;//string.IsNullOrEmpty(vm.LoginParam) && string.IsNullOrEmpty(vm.PasswordParam);
    }
}
