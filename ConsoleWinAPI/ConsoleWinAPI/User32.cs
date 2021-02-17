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

        public enum MB_Button : uint
        {
            MB_OK                = 0x00000000U,
            MB_OKCANCEL          = 0x00000001U,
            MB_ABORTRETRYIGNORE  = 0x00000002U,
            MB_YESNOCANCEL       = 0x00000003U,
            MB_YESNO             = 0x00000004U,
            MB_RETRYCANCEL       = 0x00000005U,
            MB_CANCELTRYCONTINUE = 0x00000006U,
            MB_HELP              = 0x00004000U
        }
        public enum MB_RValue : int
        {
            IDOK       = 1,
            IDCANCEL   = 2,
            IDABORT    = 3,
            IDRETRY    = 4,
            IDIGNORE   = 5,
            IDYES      = 6,
            IDNO       = 7,
            IDTRYAGAIN = 10,
            IDCONTINUE = 11
        }

        [DllImport(FileName, SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern MB_RValue MessageBox(IntPtr hWnd,
                                                  String text, String caption, 
                                                  MB_Button type = MB_Button.MB_OK);

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
