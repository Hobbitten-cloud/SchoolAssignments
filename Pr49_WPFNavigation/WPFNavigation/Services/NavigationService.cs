using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFNavigation.Stores;
using WPFNavigation.ViewModels;

namespace WPFNavigation.Services
{
    public class NavigationService
    {
        private readonly NavigationStore _navigation;
        private readonly Func<BaseViewModel> _createViewModel;

        public NavigationService(NavigationStore navigation, Func<BaseViewModel> createViewModel)
        {
            _navigation = navigation;
            _createViewModel = createViewModel; 
        }
        public void Navigate() 
        {
            _navigation.CurrentViewModel = _createViewModel();
        }
    }
}
