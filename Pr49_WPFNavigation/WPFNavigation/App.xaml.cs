using System.Configuration;
using System.Data;
using System.Windows;
using WPFNavigation.Stores;
using WPFNavigation.ViewModels;
using WPFNavigation.Views;
using WPFNavigation.Services;

namespace WPFNavigation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private NavigationStore _navigation;
        private NavigationService _service;

        public App()
        {
          _navigation = new NavigationStore();
          _navigation.CurrentViewModel = new HomeViewModel(_navigation, _service);
        }

        protected override void OnStartup(StartupEventArgs e) 
        { 
            MainWindow = new MainWindow() 
        { 
            DataContext = new MainViewModel(_navigation) 
        }; 
            MainWindow.Show(); base.OnStartup(e); 
        }
    }

}
