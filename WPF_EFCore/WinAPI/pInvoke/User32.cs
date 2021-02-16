using System;
using System.Runtime.InteropServices;
using WinAPI.pInvoke.Structs;

namespace WinAPI.pInvoke
{
    public static class User32
    {
        const string FileName = "user32";
        const int MONITOR_DEFAULTTONEAREST = 0x00000002;

        [DllImport(FileName)]
        public static extern bool GetMonitorInfo(IntPtr hMonitor, MONITORINFO lpmi);

        [DllImport(FileName)]
        public static extern IntPtr MonitorFromWindow(IntPtr handle, int flags = MONITOR_DEFAULTTONEAREST);
    }
}
