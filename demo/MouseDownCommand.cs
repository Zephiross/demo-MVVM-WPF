using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace demo
{
    class MouseDownCommand:ICommand
    {
        private Action WhattoExecute;
        private Func<bool> WhentoExecute;
        public event EventHandler CanExecuteChanged;
        public MouseDownCommand(Action What, Func<bool> When)
        {
            WhattoExecute = What;
            WhentoExecute = When;
        }
        public bool CanExecute(object parameter)
        {
            return WhentoExecute();
        }
        public void Execute(object parameter)
        {
            WhattoExecute();
        }
    }
}
