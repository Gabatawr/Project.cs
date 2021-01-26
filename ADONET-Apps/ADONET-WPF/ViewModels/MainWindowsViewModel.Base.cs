using ADONET_WPF.Infrastructure.Services;
using ADONET_WPF.ViewModels.Base;

namespace ADONET_WPF.ViewModels
{
    partial class MainWindowViewModel : ViewModel
    {
        public SqlService SqlServer { get; }
        public AuthenticationService AuthServer { get; }

        public MainWindowViewModel()
        {
            SqlServer = new SqlService(this);
            AuthServer = new AuthenticationService(this);
            _IsUserAuthParam = AuthServer.AuthMethod == AuthenticationService.AuthMethods.Windows;
        }
    }
}
