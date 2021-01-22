using ADONET_WPF.Infrastructure.Commands;
using ADONET_WPF.Infrastructure.Commands.Base;

namespace ADONET_WPF.ViewModels
{
    partial class MainWindowViewModel
    {
        #region Command : MoveAppCommand

        private Command _MoveAppCommand;
        public Command MoveAppCommand
        {
            get => _MoveAppCommand ?? new MoveAppCommand();
            set => _MoveAppCommand = value;
        }

        #endregion Command : MoveAppCommand
        //--------------------------------------------------------------------
        #region Command : CloseAppCommand

        private Command _CloseAppCommand;
        public Command CloseAppCommand
        {
            get => _CloseAppCommand ?? new CloseAppCommand();
            set => _CloseAppCommand = value;
        }

        #endregion Command : CloseAppCommand
        //--------------------------------------------------------------------
        #region Command : MinimizeAppCommand

        private Command _MinimizeAppCommand;
        public Command MinimizeAppCommand
        {
            get => _MinimizeAppCommand ?? new MinimizeAppCommand();
            set => _MinimizeAppCommand = value;
        }

        #endregion Command : MinimizeAppCommand
    }
}
