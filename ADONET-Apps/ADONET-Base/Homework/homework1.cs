using System;
using System.Data.SqlClient;

namespace ADONET_Base
{
    class Homework1
    {
        static void Main()
        {
            #region Сonnect

            SqlConnection connect = GabQuery.TryConnection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;

            #endregion Connect
            //-----------------------------------------------------------------
            #region Command

            cmd.CommandText = @"
                create table [Group]
                ( 
                    [Id] int identity primary key,
                    [Name] nvarchar(max) not null Check([Name] <> N'')
                )";

            GabQuery.TryExecuteNonQuery(cmd, "Created table Group");

            #endregion Command
            //-----------------------------------------------------------------
            #region Exit

            Console.ReadKey();
            connect.Close();
            connect.Dispose();

            #endregion Exit
        }
    }
}