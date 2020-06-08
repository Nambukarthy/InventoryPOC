using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace InventoryMobileApp.Commands
{
    public class CommandBase : ICommand
    {
        protected bool isExecuting;

        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter)
        {
            return !isExecuting;
        }

        public virtual void Execute(object parameter)
        {
            
        }
    }
}
