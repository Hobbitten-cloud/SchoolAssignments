using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFNavigation.ViewModels;

namespace WPFNavigation.Stores
{
    public class NavigationStore
    {
		public event Action CurrentViewModelChanged;

        private BaseViewModel _currentViewModel;

		public BaseViewModel CurrentViewModel
		{
			get { return _currentViewModel; }
			set 
			{ 
				_currentViewModel = value;
				OnCurrentViewModelChanged();

            }
		}

		public void OnCurrentViewModelChanged() 
		{
			CurrentViewModelChanged?.Invoke();
		}

    }
}
