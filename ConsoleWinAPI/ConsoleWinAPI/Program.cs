using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace ConsoleWinAPI
{
    class Program
    {
        #region lesson 1

        //ShowMessageBox("Hello!");
        //RunNotepad();
        //FindAndDestroyInstaller();
        //Homework.Task_1.Run();

        static void ShowMessageBox(string textDialog, string textHeader = "MessageBox")
            => User32.MessageBox(new IntPtr(0), textDialog, textHeader, User32.MB_Button.MB_YESNOCANCEL);
        static void RunNotepad()
        {
            Process notepad = Process.Start("notepad");
            Thread.Sleep(100);

            var window = new Window(notepad.MainWindowHandle);

            Console.WriteLine($"Notepad title: {window.Text}");

            Console.Write("Enter title: ");
            window.Text = Console.ReadLine();
            Console.WriteLine($"Notepad title: {window.Text}");
        }
        static void FindAndDestroyInstaller()
        {
            string wHeader = "Visual Studio Installer";

            var wnd = new Window(User32.FindWindow(null, wHeader));

            bool isDestroy = User32.DestroyWindow(wnd.Handle);
            Console.WriteLine(isDestroy);

            //var windows = Window.Find(w => w.Text.Equals(wHeader));
            //windows.ForEach(Console.WriteLine);
            //bool isDestroy = User32.DestroyWindow(windows.FirstOrDefault().Handle);
            //Console.WriteLine(isDestroy);
        }

        #endregion lesson 1
        #region lesson 2

        //Process mp = Process.GetCurrentProcess();
        //foreach (var p in Process.GetProcesses())
        //{
        //    if (p != mp)
        //    {
        //        try { p.Kill(); }
        //        catch (Exception) { }
        //    }
        //}

        //AppDomain appDomain = AppDomain.CreateDomain("new domain");
        //Assembly asm = appDomain.Load(AssemblyName.GetAssemblyName("HelloClass.dll"));
        //asm.GetModule("HelloClass.dll").GetType("HelloClass.HelloClass").GetMethod("HelloWorld").Invoke(null, null);

        static void Practice_1()
        {
            Console.Write("Run [notepad/calc/..]: ");
            var info = new ProcessStartInfo(Console.ReadLine());

            Process p = new Process() { StartInfo = info };
            bool s = false;

            try
            { s = p.Start(); }
            catch (Exception) { Console.WriteLine("Invalid process name!"); }
            if (s)
                Console.WriteLine("Process started");

            Console.ReadKey();
            if (s)
                p.Kill();
        }

        #endregion lesson 2
        static void Main()
        {
            //Practice_1();
        }
    }
}
