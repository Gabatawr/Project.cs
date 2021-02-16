using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

using WinAPI.pInvoke.Structs;
using static WinAPI.pInvoke.User32;

namespace WPF_EFCore_1.Infrastructure.Fixers
{
    public static class WindowSizeFixer
    {
        private static Window wnd;

        public static void Fix()
        {
            wnd = Application.Current.MainWindow;

            var handle = new WindowInteropHelper(wnd).Handle;
            HwndSource.FromHwnd(handle)?.AddHook(Hook);
        }
            
        private static IntPtr Hook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == 0x0024)
            {
                WM_GetMinMaxInfo(hwnd, lParam, (int)wnd.MinWidth, (int)wnd.MinHeight);
                handled = true;
            }
            return (IntPtr)0;
        }

        private static void WM_GetMinMaxInfo(IntPtr hwnd, IntPtr lParam, int minWidth, int minHeight)
        {
            MINMAXINFO mmi = (MINMAXINFO)Marshal.PtrToStructure(lParam, typeof(MINMAXINFO));
            {
                IntPtr monitor = MonitorFromWindow(hwnd);
                if (monitor != IntPtr.Zero)
                {
                    MONITORINFO monitorInfo = new();
                    GetMonitorInfo(monitor, monitorInfo);

                    mmi.ptMaxPosition.X = Math.Abs(monitorInfo.rcWork.left - monitorInfo.rcMonitor.left);
                    mmi.ptMaxPosition.Y = Math.Abs(monitorInfo.rcWork.top - monitorInfo.rcMonitor.top);

                    mmi.ptMaxSize.X = Math.Abs(monitorInfo.rcWork.right - monitorInfo.rcWork.left);
                    mmi.ptMaxSize.Y = Math.Abs(monitorInfo.rcWork.bottom - monitorInfo.rcWork.top);

                    mmi.ptMinTrackSize.X = minWidth;
                    mmi.ptMinTrackSize.Y = minHeight;
                }
            }
            Marshal.StructureToPtr(mmi, lParam, true);
        }
    }
}
