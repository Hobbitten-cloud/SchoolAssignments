using System.Configuration;
using System.Data;
using System.Windows;
using WPFNavigation02.Stores;
using WPFNavigation02.ViewModels;
using WPFNavigation02.Services;
using WPFNavigation02.Persistence;

namespace WPFNavigation02
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            PersonRepo personRepo = new PersonRepo();
            PersonService personService = new PersonService(personRepo);
            NavigationStore navigationStore = new NavigationStore();

            navigationStore.CurrentViewModel = new PersonListViewModel(navigationStore, personService);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
