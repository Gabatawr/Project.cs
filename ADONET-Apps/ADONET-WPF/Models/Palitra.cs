using System.Collections.Generic;
using System.Windows.Media;

namespace ADONET_WPF.Models
{
    internal static class Palitra
    {
        public static Color ServerDisconnected { get; } = new Color() { A = 255, R = 168, G = 29, B = 29 };
        public static Color ServerConnected { get; } = new Color() { A = 255, R = 68, G = 168, B = 29 };


        public static Color GetAuthMethodColor(ConnectionMethods chosenMethod, ConnectionMethods comparableMethod)
        {
            return comparableMethod == chosenMethod ? Palitra.AuthMethodEnabled : Palitra.AuthMethodDisabled;
        }
        static Color AuthMethodDisabled { get; } = new Color() { A = 255, R = 68, G = 68, B = 68 };
        static Color AuthMethodEnabled { get; } = new Color() { A = 255, R = 119, G = 119, B = 119 };
    }
}
