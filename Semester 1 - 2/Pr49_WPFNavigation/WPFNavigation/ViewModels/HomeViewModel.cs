using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFNavigation.Commands;
using WPFNavigation.Stores;
using WPFNavigation.Services;

namespace WPFNavigation.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly NavigationService _Service;
        public ICommand NavigateCommand { get; }
        public ICommand NavigateToScondViewCommand { get; }
        public HomeViewModel(NavigationStore navigation, NavigationService service)
        {
           
            NavigateCommand = new NavigateCommand(service);
            
        }
    }
   
}
