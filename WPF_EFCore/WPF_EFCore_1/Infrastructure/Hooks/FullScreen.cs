using System;
using System.Runtime.InteropServices;

namespace WPF_EFCore_1.Infrastructure.Hooks
{
    public static class FullScreen

    {
        //---------------------------------------------------------------------
        [DllImport("user32")]
        private static extern bool GetMonitorInfo(IntPtr hMonitor, MonitorInfo lpmi);

        [DllImport("user32")]
        private static extern IntPtr MonitorFromWindow(IntPtr handle, int flags);
        //---------------------------------------------------------------------
        [StructLayout(LayoutKind.Sequential)]
        private struct Point { public int X, Y; }

        [StructLayout(LayoutKind.Sequential)]
        private struct MinMaxInfo 
        { 
            public Point ptReserved, ptMaxSize, ptMaxPosition, ptMinTrackSize, ptMaxTrackSize;
        };
        //---------------------------------------------------------------------
        [StructLayout(LayoutKind.Sequential, Pack = 0)]
        private struct Rect { public int left, top, right, bottom; }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private class MonitorInfo
        {
            public int cbSize = Marshal.SizeOf(typeof(MonitorInfo));
            public Rect rcMonitor, rcWork;
            public int dwFlags = 0;
            public MonitorInfo(IntPtr monitor) => GetMonitorInfo(monitor, this);
        }
        //---------------------------------------------------------------------
        public static void NativeFix(IntPtr hwnd, IntPtr lParam, int minWidth, int minHeight)
        {
            MinMaxInfo mmi = (MinMaxInfo)Marshal.PtrToStructure(lParam, typeof(MinMaxInfo));
            {
                IntPtr monitor = MonitorFromWindow(hwnd, 0x00000002);
                if (monitor != IntPtr.Zero)
                {
                    MonitorInfo monitorInfo = new(monitor);

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
        //---------------------------------------------------------------------
    }
}
