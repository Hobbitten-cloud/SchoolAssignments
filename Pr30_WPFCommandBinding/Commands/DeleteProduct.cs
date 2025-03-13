using Pr30_WPFCommandBinding.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pr30_WPFCommandBinding.Commands
{
    public class DeleteProduct : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }


        public bool CanExecute(object? parameter)
        {
            bool result = true;

            if (parameter is MainViewModel mvm)
            {
                if (mvm.SelectedProduct == null)
                {
                    result = false;
                }
            }

            CommandManager.InvalidateRequerySuggested();

            return result;
        }

        public void Execute(object? parameter)
        {
            if (parameter is MainViewModel mvm)
            {
                mvm.DeleteSelectedProduct();
            }
        }
    }
}
