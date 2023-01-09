using System;
using System.Windows.Input;


namespace Pemrog.Setup
{
    public class RelayCommand : ICommand
    {
        public RelayCommand(Action cmdactone)
        {
            this.cmdactone = cmdactone;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object paramater)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            cmdactone();
        }

        private readonly Action cmdactone;
    }
}
