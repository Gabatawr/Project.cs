using System.Data.SqlClient;
using ADONET_WPF.ViewModels;

namespace ADONET_WPF.Infrastructure.Services
{
    static class AuthenticationService
    {
        static SqlConnectionStringBuilder connectionStringBuilder;

        static bool CanAuthenticationWindows()
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

        public static bool AuthenticationWindows(MainWindowViewModel vm)
        {
            bool canAuth = CanAuthenticationWindows();
            if (canAuth) vm.SqlServer.Connect(vm, connectionStringBuilder);
            return canAuth;
        }

        static bool CanAuthenticationSqlServer(string userID, string password)
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

        public static bool AuthenticationSqlServer(MainWindowViewModel vm)
        {
            bool canAuth = CanAuthenticationSqlServer(vm.LoginParam, vm.PasswordParam);
            if (canAuth) vm.SqlServer.Connect(vm, connectionStringBuilder);
            return canAuth;
        }
    }
}
