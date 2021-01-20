using System;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ADONET_Base
{
    static class GabQuery
    {
        public static SqlConnection TryConnection()
        {
            ConfigurationBuilder builder = new();
            builder.AddJsonFile("appsettings.json");
            IConfigurationRoot config = builder.Build();

            IConfigurationSection connectionString = config.GetSection("ConnectionStrings");
            SqlConnectionStringBuilder connectionStringBuilder = new() { IntegratedSecurity = true };

            connectionStringBuilder.DataSource = connectionString.GetSection("DataSource").Value;
            connectionStringBuilder.AttachDBFilename = connectionString.GetSection("AttachDBFilename").Value;

            SqlConnection connect = new SqlConnection();
            connect.ConnectionString = connectionStringBuilder.ConnectionString;

            try
            { connect.Open(); }
            catch (SqlException ex)
            {
                Console.Write(ex.Message);
                throw;
            }
            Console.WriteLine("Connection: OK");

            return connect;
        }
        public static void TryExecuteNonQuery(SqlCommand cmd, string cmdName)
        {
            try
            { cmd.ExecuteNonQuery(); }
            catch (SqlException ex)
            {
                Console.Write(ex.Message);
                throw;
            }
            Console.WriteLine(cmdName + ": OK");
        }

        public static T TryExecuteScalar<T>(SqlCommand cmd, string cmdName)
        {
            T scalar = default;

            try
            { scalar = (T)Convert.ChangeType(cmd.ExecuteScalar(), typeof(T)); }
            catch (SqlException ex)
            {
                Console.Write("SQL: ", ex.Message);
                throw;
            }
            catch (InvalidCastException ex)
            {
                Console.Write("NaN: ", ex.Message);
                throw;
            }
            Console.WriteLine(cmdName + $": {scalar} " + ": OK");

            return scalar;
        }
    }
}
