using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace ConsoleWinAPI
{
    class Program
    {
        static void ShowMessageBox(string textDialog, string textHeader = "MessageBox")
            => User32.MessageBox(new IntPtr(0), textDialog, textHeader, User32.MB_Buttons.MB_YESNOCANCEL);

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

        static void Main()
        {
            //ShowMessageBox("Hello!");
            //RunNotepad();

            FindAndDestroyInstaller();

            Console.ReadKey();
        }
    }
}
