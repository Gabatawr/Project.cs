using System;
using System.Windows;
using System.Windows.Interop;
using WPF_EFCore_1.Infrastructure.Commands.Base;
using WPF_EFCore_1.Infrastructure.Fixers;

namespace WPF_EFCore_1.ViewModels
{
    partial class MainWindowViewModel
    {
        //--------------------------------------------------------------------
        #region Event : SourceInitializedEvent

        private Command _SourceInitializedEvent;
        public Command SourceInitializedEvent
        {
            get => _SourceInitializedEvent ??= new ActionCommand(exec => WindowSizeFixer.Fix());
            set => _SourceInitializedEvent = value;
        }

        #endregion Event : SourceInitializedEvent
        //--------------------------------------------------------------------
    }
}
