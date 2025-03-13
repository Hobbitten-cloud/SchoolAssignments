using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestWPF.ViewModels;

namespace CommandBindingWPF.Commands
{
    public class UpdateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is MainViewModel mvm)
            {
                // MainViewModel mvm = (MainViewModel)parameter;
                mvm.FirstName = DateTime.Now.ToString();
            }
            else
            {
                throw new ArgumentException("Invalid type");
            }
        }
    }
}
