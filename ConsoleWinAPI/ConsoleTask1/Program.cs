using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;

namespace ConsoleTask1_2
{
    class Program
    {
        static Process p;

        static void Start()
        {
            p = new() { StartInfo = new("notepad.exe") };

            p.Start();
            Console.WriteLine("Process is running");
        }

        static void WaitForExit()
        {
            Console.WriteLine("Waiting process exit..");
            p.WaitForExit();
            Console.WriteLine("Process completed: " + p.ExitCode);
        }

        /// <summary>
        ///  Задание 1:
        ///    Разработайте приложение, которое умеет запускать дочерний процесс и ожидать его завершения.
        ///    Когда дочерний процесс завершен, родительское приложение должно отобразить код завершения.
        /// </summary>
        static void Task_1()
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);

            Start();
            WaitForExit();
        }

        /// <summary>
        ///  Задание 2:
        ///   Разработайте приложение, которое умеет запускать дочерний процесс.
        ///   В зависимости от выбора пользователя родительское приложение должно ожидать
        ///   завершения дочернего процесса и отображать код завершения
        ///   либо принудительно завершать работу дочернего процесса.
        /// </summary>
        static void Task_2()
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);

            Start();
            Console.Write("Enter[wait/kill]: ");
            string s = Console.ReadLine().Trim().ToLower();

            switch (s)
            {
                case "wait": WaitForExit(); break;
                case "kill": p.Kill();      break;
            };
        }
           
        static void Main()
        {
            Task_1();
            Console.WriteLine();

            Task_2();
            Console.ReadKey();
        }
    }
}
