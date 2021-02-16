using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ConsoleWinAPI
{
    public static class User32
    {
        public const string FileName = "user32.dll";

        #region MessageBox

        public sealed class MB_Buttons
        {
            public const uint MB_ABORTRETRYIGNORE  = 0x00000002U;
            public const uint MB_CANCELTRYCONTINUE = 0x00000006U;
            public const uint MB_HELP              = 0x00004000U;
            public const uint MB_OK                = 0x00000000U;
            public const uint MB_OKCANCEL          = 0x00000001U;
            public const uint MB_RETRYCANCEL       = 0x00000005U;
            public const uint MB_YESNO             = 0x00000004U;
            public const uint MB_YESNOCANCEL       = 0x00000003U;
        }

        [DllImport(FileName, SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern int MessageBox(IntPtr hWnd, String text, String caption, uint type = MB_Buttons.MB_OK);

        #endregion MessageBox

        #region WindowText

        [DllImport(FileName, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetWindowTextLength(IntPtr hWnd);
        
        [DllImport(FileName, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, uint nMaxCount);
        
        [DllImport(FileName, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool SetWindowText(IntPtr hWnd, string lpString);

        #endregion WindowText

        #region FindWindow

        [DllImport(FileName, SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        #endregion FindWindow

        #region DestroyWindow

        [DllImport(FileName, SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool DestroyWindow(IntPtr hWnd);


        #endregion DestroyWindow

        #region EnumWindows

        [Serializable]
        [return: MarshalAs(UnmanagedType.Bool)]
        public delegate bool EnumWindowProc(IntPtr hWnd, IntPtr lParam);

        [DllImport(FileName, SetLastError = true)]
        public static extern IntPtr EnumWindows(EnumWindowProc hWnd, IntPtr lParam);

        #endregion EnumWindows
    }
}
