using System.Collections.Generic;
using WPF_EFCore_1.Infrastructure.Commands;
using WPF_EFCore_1.Infrastructure.Commands.Base;

namespace WPF_EFCore_1.ViewModels
{
    partial class MainWindowViewModel
    {
        //--------------------------------------------------------------------
        #region Command : AppCommands

        private Dictionary<string, Command> _AppCommands = new()
        {
            { nameof(MoveAppCommand),     new MoveAppCommand()     },
            { nameof(MinimizeAppCommand), new MinimizeAppCommand() },
            { nameof(MaximizeAppCommand), new MaximizeAppCommand() },
            { nameof(CloseAppCommand),    new CloseAppCommand()    }
        };
        public Dictionary<string, Command> AppCommands => _AppCommands;

        #endregion Command : AppCommands
        //--------------------------------------------------------------------
    }
}