using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFNavigation.Stores;
using WPFNavigation.ViewModels;
using WPFNavigation.Services;

namespace WPFNavigation.Commands
{
    public class NavigateCommand : ICommand
    {
        private readonly NavigationService _navigation;
        public event EventHandler? CanExecuteChanged;

        public NavigateCommand(NavigationService navigation)
        {
            _navigation = navigation;
            
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _navigation.Navigate();
        }
    }
}
