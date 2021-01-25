using System.Data.SqlClient;

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

        public static bool AuthenticationWindows()
        {
            bool canAuth = CanAuthenticationWindows();
            if (canAuth) SqlService.Connection = new(connectionStringBuilder.ConnectionString);
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

            return string.IsNullOrEmpty(dataSource)     is false && 
                   string.IsNullOrEmpty(initialCatalog) is false &&
                   string.IsNullOrEmpty(userID)         is false &&
                   string.IsNullOrEmpty(password)       is false;
        }

        public static bool AuthenticationSqlServer(string userID, string password)
        {
            bool canAuth = CanAuthenticationSqlServer(userID, password);
            if (canAuth) SqlService.Connection = new(connectionStringBuilder.ConnectionString);
            return canAuth;
        }
    }
}
