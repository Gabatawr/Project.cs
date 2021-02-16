using System.Runtime.InteropServices;

namespace WinAPI.pInvoke.Structs
{
    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    public struct RECT 
    { 
        public int left, top, right, bottom; 
    }
}
