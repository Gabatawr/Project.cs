using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_EFCore_1.Infrastructure.Commands.Base
{
    class ActionCommand : Command
    {
        private readonly Action<object> _Execute;
        private readonly Func<object, bool> _CanExecute;

        public ActionCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _Execute = execute ?? throw new ArgumentNullException(nameof(Execute));
            _CanExecute = canExecute;
        }

        public override bool CanExecute(object p) => _CanExecute?.Invoke(p) ?? true;
        public override void Execute(object p) { if (CanExecute(p)) _Execute(p); }
    }
}
