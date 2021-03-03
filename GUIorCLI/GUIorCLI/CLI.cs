using System;
using System.Diagnostics;

namespace GUIorCLI
{
    internal class CLI
    {
        internal static void Run()
        {
            bool attached = false;

            Process process;
            {
                int u;
                Kernel32.GetWindowThreadProcessId(Kernel32.GetForegroundWindow(), out u);
                process =  Process.GetProcessById(u);
            }

            if (process.ProcessName == "cmd")
            {
                Kernel32.AttachConsole(process.Id);
                attached = true;
            }
            else
            {
                Kernel32.AllocConsole();

                Console.Title = "GUIorCLI";
                Console.Clear();
            }

            Console.WriteLine("Hello Console!");
            Console.ReadKey();

            Kernel32.FreeConsole();
            if (attached) Kernel32.PostMessage(process.MainWindowHandle);
        }
    }
}
