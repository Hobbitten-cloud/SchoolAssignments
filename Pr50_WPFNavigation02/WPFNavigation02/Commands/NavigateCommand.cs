using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFNavigation02.ViewModels;
using WPFNavigation02.Services;
using WPFNavigation02.Models;

namespace WPFNavigation02.Commands
{
    public class NavigateCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly NavigationService navigationService;
      

        public NavigateCommand(NavigationService navigationService)
        {
            this.navigationService = navigationService;
        }
        
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            navigationService.Navigate();
        }
    }
}
