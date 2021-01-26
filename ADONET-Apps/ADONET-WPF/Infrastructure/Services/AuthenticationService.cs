using System.Data.SqlClient;
using System.Windows.Media;
using ADONET_WPF.ViewModels;

namespace ADONET_WPF.Infrastructure.Services
{
    internal class AuthenticationService
    {
        public enum AuthMethods { Windows, SqlServer }
        public AuthMethods AuthMethod { get; set; } = AuthMethods.Windows;

        public Color GetAuthMethodColor(AuthMethods p)
            => AuthMethod == p ? 
                new Color() { A = 255, R = 119, G = 119, B = 119 } // Enable
                : new Color() { A = 255, R = 68, G = 68, B = 68 }; // Disable

        private MainWindowViewModel vm;
        private SqlConnectionStringBuilder connectionStringBuilder;

        public AuthenticationService(MainWindowViewModel vm) { this.vm = vm; }

        private bool CanAuthenticationWindows()
        {
            connectionStringBuilder = new();

            string cs = "ConnectionStrings";
            string a = "AuthenticationWindows";

            connectionStringBuilder.IntegratedSecurity = true;

            string dataSource = ConfigurationService.GetSectionValue(cs, a, "DataSource");
            connectionStringBuilder.DataSource = dataSource;

            string attachDBFilename = ConfigurationService.GetSectionValue(cs, a, "AttachDBFilename");
            connectionStringBuilder.AttachDBFilename = attachDBFilename;

            return string.IsNullOrEmpty(dataSource) is false && string.IsNullOrEmpty(attachDBFilename) is false;
        }

        public bool AuthenticationWindows()
        {
            bool canAuth = CanAuthenticationWindows();
            if (canAuth) vm.SqlServer.Connect(connectionStringBuilder);
            return canAuth;
        }

        private bool CanAuthenticationSqlServer(string userID, string password)
        {
            connectionStringBuilder = new();

            string cs = "ConnectionStrings";
            string a = "AuthenticationSqlServer";

            string dataSource = ConfigurationService.GetSectionValue(cs, a, "DataSource");
            connectionStringBuilder.DataSource = dataSource;

            string initialCatalog = ConfigurationService.GetSectionValue(cs, a, "InitialCatalog");
            connectionStringBuilder.InitialCatalog = initialCatalog;

            connectionStringBuilder.UserID = userID;
            connectionStringBuilder.Password = password;


            return string.IsNullOrEmpty(dataSource)     is false && 
                   string.IsNullOrEmpty(initialCatalog) is false &&
                   string.IsNullOrEmpty(userID)         is false &&
                   string.IsNullOrEmpty(password)       is false;
        }

        public bool AuthenticationSqlServer()
        {
            bool canAuth = CanAuthenticationSqlServer(vm.LoginParam, vm.PasswordParam);
            if (canAuth) vm.SqlServer.Connect(connectionStringBuilder);
            return canAuth;
        }
    }
}
