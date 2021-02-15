using System.Runtime.InteropServices;

namespace WPF_EFCore_1.Infrastructure.pInvoke.Structs
{
    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    public struct RECT 
    { 
        public int left, top, right, bottom; 
    }
}
