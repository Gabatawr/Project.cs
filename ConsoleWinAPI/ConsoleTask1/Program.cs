using System;
using System.Diagnostics;
using System.Reflection;

namespace ConsoleTask1_2_3
{
    class Program
    {
        static Process p;

        static void Start(ProcessStartInfo info)
        {
            p = new() { StartInfo = info };

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

            Start(new("notepad.exe"));
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

            Start(new("notepad.exe"));
            Console.Write("Enter[wait/kill]: ");
            string s = Console.ReadLine().Trim().ToLower();

            switch (s)
            {
                case "wait": WaitForExit(); break;
                case "kill": p.Kill();      break;
            };
        }

        /// <summary>
        ///  Задание 3:
        ///   Разработайте приложение, которое умеет запускать дочерний процесс
        ///   и передавать ему аргументы командной строки.
        ///   В качестве аргументов должно быть два числа и операция, которую необходимо выполнить.
        ///   Например:
        ///     Аргументы: 7; 3; +.
        ///     Дочерний процесс должен отобразить аргументы
        ///     и вывести результат сложения 10 на экран.
        /// </summary>
        static void Task_3()
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);

            Start(new ProcessStartInfo()
            {
                UseShellExecute = true,
                WorkingDirectory = @"E:\Code\Project-cs\ConsoleWinAPI\task3child\bin\Debug\net5.0",
                FileName = "task3child.exe",
                Arguments = "7 3 +"
            });

            WaitForExit();
        }

        static void Main()
        {
            bool loop = true;
            while (loop)
            {
                Console.Write("Run task[1/2/3]: ");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1: Task_1(); break;
                    case 2: Task_2(); break;
                    case 3: Task_3(); break;
                    default: 
                        loop = false;
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}
