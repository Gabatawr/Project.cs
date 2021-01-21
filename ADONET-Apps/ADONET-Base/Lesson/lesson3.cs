using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text;

namespace ADONET_Base
{
    class Lesson3
    {
        #region Template cmd
        /*
        #region

        cmd.CommandText = @"";
        GabQuery.TryExecuteNonQuery(cmd, "");

        #endregion
        */
        #endregion Template cmd
        public static void Run()
        {
            #region Сonnect

            SqlConnection connect = GabQuery.TryConnection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;

            #endregion Connect
            //-----------------------------------------------------------------
            #region Create table

            cmd.CommandText = @"
                create table [Users]
                ( 
                    [Id] int identity primary key,
                    [Name] nvarchar(max) not null Check([Name] <> N''),
                    [Login] nvarchar(max) not null Check([Login] <> N'')
                )";

            GabQuery.TryExecuteNonQuery(cmd, "Create table");

            #endregion Create table
            //-----------------------------------------------------------------
            #region Insert values
            string cmdName = "Insert values";

            cmd.CommandText = @"
                insert into [Users] ([Name], [Login])
                             values (@name , @login)";

            cmd.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("@name", System.Data.SqlDbType.NVarChar, 64),
                    new SqlParameter("@login", System.Data.SqlDbType.NVarChar, 64)
                }
            );
            cmd.Prepare();

            List<(string, string)> vals = new()
            {
                ("John Doe", "God"),
                ("Donald Duck", "Duck")
            };

            for (int i = 0; i < vals.Count; i++)
            {
                cmd.Parameters["@name"].Value = vals[i].Item1;
                cmd.Parameters["@login"].Value = vals[i].Item2;
                GabQuery.TryExecuteNonQuery(cmd, cmdName + $": {vals[i].Item1}, {vals[i].Item2}");
            }

            #endregion Insert values
            //-----------------------------------------------------------------
            #region Drop table

            Console.Write("\nDrop table? [y/n] _\b");
            if (Console.ReadLine().ToLower() == "y")
            {
                cmd.CommandText = @"
                    drop table [Users]";

                GabQuery.TryExecuteNonQuery(cmd, "Drop table");
            }

            #endregion Drop table
            //-----------------------------------------------------------------
            #region Exit

            Console.ReadKey();
            connect.Close();
            connect.Dispose();

            #endregion Exit
        }
        public static void Run2()
        {
            #region Сonnect

            SqlConnection connect = GabQuery.TryConnection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;

            #endregion Connect
            //-----------------------------------------------------------------
            #region Select first name

            cmd.CommandText = @"select top 1 [Name] from [Users]";
            GabQuery.TryExecuteScalar<string>(cmd, "Select first name");

            #endregion Select first name
            //-----------------------------------------------------------------
            #region Select Count

            cmd.CommandText = @"select Count(Id) from [Users]";
            GabQuery.TryExecuteScalar<int>(cmd, "Select Count");

            #endregion Select double
            //-----------------------------------------------------------------
            #region Select double value

            cmd.CommandText = @"select Avg(Cast(Id as float)) from [Users]";
            GabQuery.TryExecuteScalar<double>(cmd, "Select double value");

            #endregion Select double value
            //-----------------------------------------------------------------
            #region Insert 2000 numbers

            cmd.CommandText = @"truncate table [Numbers]";
            GabQuery.TryExecuteNonQuery(cmd, "Truncate table Numbers");

            int countAll = 2000;
            int countVal = 10;

            StringBuilder strb = new(@"insert into [Numbers] ([N]) values ");
            for (int i = 0; i < countVal; i++)
                strb.Append("(@n" + i + ")" + (i == countVal - 1 ? "" : ","));
            cmd.CommandText = strb.ToString();

            List<SqlParameter> paramArray = new();
            for (int i = 0; i < countVal; i++)
                paramArray.Add(new SqlParameter("@n" + i, System.Data.SqlDbType.Int, 0));

            cmd.Parameters.AddRange(paramArray.ToArray());
            cmd.Prepare();

            Random rand = new();

            for (int i = 0, j = 0; i < countAll; i++, j++)
            {
                cmd.Parameters["@n" + j].Value = rand.Next(100);

                if (j == countVal - 1)
                {
                    GabQuery.TryExecuteNonQuery(cmd, "Insert" + countVal + " values");
                    j = -1;
                }
            }
            cmd.Parameters.Clear();

            #endregion Insert 2000 numbers
            //-----------------------------------------------------------------
            #region Select N >> Count

            cmd.CommandText = @"select count([N]) from [Numbers] where N = @val";
            cmd.Parameters.Add(new SqlParameter("@val", System.Data.SqlDbType.Int, 0));
            cmd.Prepare();

            for (int i = 0; i < 100; i++)
            {
                cmd.Parameters["@val"].Value = i;
                Console.WriteLine(i + " >> " + GabQuery.TryExecuteScalar<int>(cmd));
            }
            #endregion Select N >> Count
            //-----------------------------------------------------------------
            #region Exit

            Console.ReadKey();
            connect.Close();
            connect.Dispose();

            #endregion Exit
        }
    }
}