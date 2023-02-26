using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Chemsoft.Core.Commands
{
    internal sealed class UndoCommand : ICommand
    {
        private UserControl _closeControl;

        public event EventHandler? CanExecuteChanged;

        public UndoCommand(UserControl closeControl)
        {
            _closeControl = closeControl;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter is not UserControl control) return;

            _closeControl.Content = control.Content;
        }
    }
}
