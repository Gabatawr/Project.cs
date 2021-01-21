using System;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace ADONET_Base
{
    class Lesson3
    {
        public static void Run()
        {
            
            //-----------------------------------------------------------------
            #region Exit

            Console.ReadKey();
            connect.Close();
            connect.Dispose();

            #endregion Exit
        }
    }
}