using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace TheMovies.ViewModel.Commands
{
    // Inherits the ICommand. That is where the methods comes from
    public class LoginCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }

        }
        public bool CanExecute(object parameter) // Checks if the button can be executed or not
        {
            bool result = false;

            if (parameter is LoginViewModel lvm)

            {
                if (lvm.Username != null && lvm.Password != null)
                {
                    result = true;
                }
            }

            CommandManager.InvalidateRequerySuggested();

            return result;
        }

        public void Execute(object? parameter) // What the button does when clicked on
        {
            // Checks wether if the employee exist or does not exist
            if (parameter is LoginViewModel lvm)
            {
                if (lvm.EmployeeLogin(lvm.Username, lvm.Password) == null) // Fail
                {
                    if (MessageBox.Show("Der er fejl i dit login!", "Fejl Login", MessageBoxButton.OK) == MessageBoxResult.OK)
                    {

                    }
                }
                else // Success
                {
                    StorageWindow storageWindow = new StorageWindow()
                    {
                        Title = "Storage",
                        Topmost = true,
                        ResizeMode = ResizeMode.NoResize,
                        ShowInTaskbar = false,
                        Owner = null
                    };
                    storageWindow.ShowDialog();
                }
            }

        }
    }
}
