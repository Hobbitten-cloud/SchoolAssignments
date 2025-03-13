using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFNavigation02.Stores;

namespace WPFNavigation02.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly NavigationStore navigationStore;
        public BaseViewModel CurrentViewModel { get => navigationStore.CurrentViewModel; }

        public MainViewModel(NavigationStore navigationStore)
        {
            this.navigationStore = navigationStore;
            this.navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
