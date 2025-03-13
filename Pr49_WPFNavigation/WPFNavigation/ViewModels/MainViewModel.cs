using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFNavigation.Stores;

namespace WPFNavigation.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _currentViewModel;

        public BaseViewModel CurrentViewModel
        {
            get { return _navigation.CurrentViewModel; }
        }


        private readonly NavigationStore _navigation;
        public MainViewModel(NavigationStore navigation)
        {
            _navigation = navigation;
            _navigation.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }
        public void OnCurrentViewModelChanged() 
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
