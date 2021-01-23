using System.Windows.Media;

namespace ADONET_WPF.Models
{
    internal static class ConnectColor
    {
        public static Color Disconnect { get; } = new Color() { A = 255, R = 168, G = 29, B = 29 };
        public static Color Connect { get; } = new Color() { A = 255, R = 68, G = 168, B = 29 };
    }
}
