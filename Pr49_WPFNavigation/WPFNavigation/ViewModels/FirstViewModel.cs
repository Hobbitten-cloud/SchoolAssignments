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
    public class FirstViewModel : BaseViewModel
    {
        public ICommand NavigateCommand { get; }
        public FirstViewModel(NavigationStore navigation, NavigationService service)
        {
            NavigateCommand = new NavigateCommand(service);
        }
    }
}
