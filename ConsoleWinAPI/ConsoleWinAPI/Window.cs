using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ConsoleWinAPI
{
    class Window
    {
        public IntPtr Handle { get; private set; }
        public Window(IntPtr Handle) => this.Handle = Handle;

        #region ThrowLastWin32Error

        private static void ThrowLastWin32Error()
            => Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());

        #endregion ThrowLastWin32Error

        #region Text

        public string Text
        {
            get => GetWindowText();
            set
            {
                bool isError = SetWindowTest(value) is false;
                if (isError)
                    ThrowLastWin32Error();
            }
        }
        private string GetWindowText()
        {
            var buffer = new StringBuilder(User32.GetWindowTextLength(Handle) + 1);
            if (buffer.Capacity > 0)
                User32.GetWindowText(Handle, buffer, (uint)buffer.Capacity);

            return buffer.ToString();
        }
        private bool SetWindowTest(string text) => User32.SetWindowText(Handle, text);

        #endregion Text

        #region Find

        public static List<Window> Find(Func<Window, bool> Selector)
        {
            var result = new List<Window>();

            bool WindowSelector(IntPtr hWnd, IntPtr lParam)
            {
                var window = new Window(hWnd);
                if (Selector(window))
                    result.Add(window);

                return true;
            }

            User32.EnumWindows(WindowSelector, IntPtr.Zero);

            return result;
        }

        #endregion Find

        #region ToString

        public override string ToString() => Handle.ToString();

        #endregion ToString
    }
}
