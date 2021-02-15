using System;
using System.Runtime.InteropServices;
using WPF_EFCore_1.Infrastructure.pInvoke.Structs;

namespace WPF_EFCore_1.Infrastructure.pInvoke
{
    internal static class User32
    {
        const string FileName = "user32";
        const int MONITOR_DEFAULTTONEAREST = 0x00000002;

        [DllImport(FileName)]
        public static extern bool GetMonitorInfo(IntPtr hMonitor, MONITORINFO lpmi);

        [DllImport(FileName)]
        public static extern IntPtr MonitorFromWindow(IntPtr handle, int flags = MONITOR_DEFAULTTONEAREST);
    }
}
