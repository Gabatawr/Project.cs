using System;
using System.Runtime.InteropServices;

namespace WPF_EFCore_1.Infrastructure.pInvoke.Structs
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public class MONITORINFO
    {
        public int cbSize = Marshal.SizeOf(typeof(MONITORINFO));
        public RECT rcMonitor, rcWork;
        public int dwFlags = 0;
    }
}
