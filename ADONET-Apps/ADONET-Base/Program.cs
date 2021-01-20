using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Extensions.Configuration;



namespace ADONET_Base
{
    class Program
    {
        static void Main_lesson1()
        {
            /*
                ADO / PDO / JDBC - Технологии доступа к БД
                Промужуточное звено между программой и СУБД
                + Универсальность (заменяемость)
                + Скрытие SQL - применения языковых инструкций (LINQ), адаптеров и т.п.
                + Идеология CodeFirst - БД строится из анализа кода (Entity)
                + 
            */

            // 0. Config ------------------------------------------------------
            ConfigurationBuilder builder = new();
            builder.AddJsonFile("appsettings.json");
            IConfigurationRoot config = builder.Build();

            // 1. Подключение -------------------------------------------------
            //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Code\Project-cs\ADONET-Apps\ADONET-Base\Database\Database-ADOBase.mdf;Integrated Security=True";
            
            IConfigurationSection connectionString = config.GetSection("ConnectionStrings");
            SqlConnectionStringBuilder connectionStringBuilder = new() { IntegratedSecurity = true };
            connectionStringBuilder.DataSource = connectionString.GetSection("DataSource").Value;
            connectionStringBuilder.AttachDBFilename = connectionString.GetSection("AttachDBFilename").Value;

            //SqlConnection connect = new SqlConnection(connectionString);
            SqlConnection connect = new SqlConnection();
            connect.ConnectionString = connectionStringBuilder.ConnectionString;

            try { connect.Open(); }
            catch (SqlException ex)
            {
                Console.Write(ex.Message);
                return;
            }
            Console.WriteLine("\nConnection: OK");

            // 2. Выполнение команд -------------------------------------------
            #region cmd: Created table Test
            ///*
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "create table Test( Id int identity primary key, str nvarchar(32) )";

            // cmd.ExecuteNonQuery(); команды без возврата значений, возвращает int(кол-во обраб строк)
            // cmd.ExecuteScalar(); возврат одного значения
            // cmd.ExecuteReader(); возврат таблиц

            try
            { cmd.ExecuteNonQuery(); }
            catch (SqlException ex)
            {
                Console.Write(ex.Message);
                return;
            }
            Console.WriteLine("\nCreated table Test: OK");
            //*/
            #endregion cmd: Created table Test

            #region cmd: Insert values in Test
            ///*
            //SqlCommand 
            cmd = new SqlCommand();
            cmd.Connection = connect;

            ///*
            Console.WriteLine();
            while (true)
            {
                Console.Write("val: ");
                string value = Console.ReadLine().Trim();
                if (string.IsNullOrEmpty(value)) break;

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@value", value);
                cmd.CommandText = $"insert into [Test] ([str]) values (@value)";

                try
                { cmd.ExecuteNonQuery(); }
                catch (SqlException ex)
                {
                    Console.Write(ex.Message);
                    return;
                }
            }
            //*/
            /*
            cmd.CommandText = $"insert into [Test] ([str]) values ";

            List<string> arr = new();
            while (true)
            {
                Console.Write("val: ");
                string value = Console.ReadLine().Trim();
                if (string.IsNullOrEmpty(value)) break;
                arr.Add(value);
            }

            for (int i = 0; i < arr.Count; i++)
                cmd.CommandText += $"(N'{arr[i]}')" + (i == arr.Count - 1 ? "" : ",");

            try { cmd.ExecuteNonQuery(); }
            catch (SqlException ex)
            {
                Console.Write(ex.Message);
                return;
            }
            */
            Console.WriteLine("\nInsert value in Test: OK");
            //*/
            #endregion cmd: Insert values in Test

            #region cmd: Select values in Test

            cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = $"select * from [Test]";

            SqlDataReader reader;
            try { reader = cmd.ExecuteReader(); }
            catch (SqlException ex)
            {
                Console.Write(ex.Message);
                return;
            }

            Console.WriteLine();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write(reader.GetName(i) + ": " + reader[i] + '\t');
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nSelect table Test: OK");

            #endregion cmd: Select values in Test

            //----------------
            Console.ReadKey();
            connect.Close();
            connect.Dispose();
        }
        //---------------------------------------------------------------------
        static Random rand = new();
        static void TryExecuteNonQuery(SqlCommand cmd, string cmdName)
        {
            try { cmd.ExecuteNonQuery(); }
            catch (SqlException ex)
            {
                Console.Write(ex.Message);
                throw;
            }
            Console.WriteLine(cmdName + ": OK");
        }
        static T TryExecuteScalar<T>(SqlCommand cmd, string cmdName)
        {
            T scalar = default;

            try { scalar = (T)Convert.ChangeType(cmd.ExecuteScalar(), typeof(T)); }
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
        static void Main()
        {
            /*
                Режимы работы. Присоединенный режим
                Редими работы - в зависимости от наличия активного (открытого) подкл к БД
                - Присоединенный: при открытом подключении, данные сразу попадают в БД
                - Отсоединенный: создается программный оъект-буфер, в который считываются данные
                                 действия пользователя происходят с этим объектом (не с БД)
                                 в нужный момент производится синхронизация с БД
            */
            //-----------------------------------------------------------------
            #region Сonnect

            ConfigurationBuilder builder = new();
            builder.AddJsonFile("appsettings.json");
            IConfigurationRoot config = builder.Build();

            IConfigurationSection connectionString = config.GetSection("ConnectionStrings");
            SqlConnectionStringBuilder connectionStringBuilder = new() { IntegratedSecurity = true };

            connectionStringBuilder.DataSource = connectionString.GetSection("DataSource").Value;
            connectionStringBuilder.AttachDBFilename = connectionString.GetSection("AttachDBFilename").Value;

            SqlConnection connect = new SqlConnection();
            connect.ConnectionString = connectionStringBuilder.ConnectionString;

            try { connect.Open(); }
            catch (SqlException ex)
            {
                Console.Write(ex.Message);
                return;
            }
            Console.WriteLine("Connection: OK");

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;

            #endregion Connect
            //-----------------------------------------------------------------
            #region cmd: Created table Test
            ///*
            cmd.CommandText = 
                @"create table [Test] 
                ( 
                    [Id] int identity primary key,
                    [Numbers] int not null
                )";

            TryExecuteNonQuery(cmd, "Created table Test");
            //*/
            #endregion cmd: Created table Test
            //-----------------------------------------------------------------
            #region cmd: Add column [AddDate] in Test
            ///*
            cmd.CommandText =
                @"alter table [Test] 
                add [AddDate] datetime null default getdate()";

            TryExecuteNonQuery(cmd, "Add column [AddDate] in Test");
            //*/
            #endregion cmd: Add column [AddDate] in Test
            //-----------------------------------------------------------------
            #region cmd: Add 10 numbers in Test
            ///*
            StringBuilder tmpCmd = new("insert into[Test]([Numbers]) values");

            int cnt = 10;
            for (int i = 0; i < cnt; i++)
            {
                string valName = "@value" + i;
                cmd.Parameters.AddWithValue(valName, rand.Next(1000));

                tmpCmd.Append($"({valName})");
                if (i < cnt - 1) tmpCmd.Append(',');
            }

            cmd.CommandText = tmpCmd.ToString();
            TryExecuteNonQuery(cmd, "Add 10 numbers in Test");
            cmd.Parameters.Clear();
            //*/
            #endregion cmd: Add 10 numbers in Test
            //-----------------------------------------------------------------
            #region cmd: Select AVG Numbers
            ///*
            cmd.CommandText = "select Avg([Numbers]) from [Test]";
            TryExecuteScalar<double>(cmd, "Select AVG Numbers");
            //*/
            #endregion cmd: Select AVG Numbers

            //-----------------------------------------------------------------
            #region Exit

            Console.ReadKey();
            connect.Close();
            connect.Dispose();

            #endregion Exit
        }
    }
}