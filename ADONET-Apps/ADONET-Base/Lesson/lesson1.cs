using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ADONET_Base
{
    class Lesson1
    {
        public static void Run()
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
    }
}