using System;
using System.Windows;
using System.Windows.Interop;
using WPF_EFCore_1.Infrastructure.Commands.Base;
using WPF_EFCore_1.Infrastructure.Hooks;

namespace WPF_EFCore_1.ViewModels
{
    partial class MainWindowViewModel
    {
        #region Event : SourceInitializedEvent
        //--------------------------------------------------------------------
        private Command _SourceInitializedEvent;
        public Command SourceInitializedEvent
        {
            get => _SourceInitializedEvent ??= new ActionCommand
            (
                param => HwndSource.FromHwnd(new WindowInteropHelper(Application.Current.MainWindow).Handle)?.AddHook
                (
                    (IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled) =>
                    {
                        if (msg == 0x0024)
                        {
                            FullScreen.NativeFix(hwnd, lParam, (int)MinWidthParameter, (int)MinHeightParameter);
                            handled = true;
                        }
                        return (IntPtr)0;
                    }
                )
            );
            set => _SourceInitializedEvent = value;
        }
        //--------------------------------------------------------------------
        #endregion Event : SourceInitializedEvent
    }
}
