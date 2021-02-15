using System.Runtime.InteropServices;

namespace WPF_EFCore_1.Infrastructure.pInvoke.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MINMAXINFO
    {
        public POINT ptReserved, ptMaxSize, ptMaxPosition, ptMinTrackSize, ptMaxTrackSize;
    };
}
