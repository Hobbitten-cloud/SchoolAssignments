using ListBox.Models;
using ListBox.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CommandBindingWithListBox.Command
{
    public class DeleteCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            bool result = true;

            if (parameter is MainViewModel mvm)
            {
                if (mvm.SelectedPerson == null)
                {
                    result = false;
                }
            }

            CommandManager.InvalidateRequerySuggested();

            return result;
        }

        public void Execute(object parameter)
        {
            if (parameter is MainViewModel mvm)
            {
                mvm.Persons.Remove(mvm.SelectedPerson);
            }
        }
    }
}
