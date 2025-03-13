using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFAndMVVM2.ViewModels;

namespace WPFAndMVVM2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Instansiere mainviewmodel 
        MainViewModel mainViewModel = new MainViewModel();

        public MainWindow()
        {
            InitializeComponent();

            // Databinder informationen fra backend kode delen til design området.
            DataContext = mainViewModel;

        }

        //private void btnNewPerson_Click(object sender, RoutedEventArgs e)
        //{
        //    mainViewModel.AddDefaultPerson();
        //    LB_Person.ScrollIntoView(mainViewModel.SelectedPerson);
        //}

        //private void btnDeletePerson_Click(object sender, RoutedEventArgs e)
        //{
        //    mainViewModel.DeleteSelectedPerson();
        //    LB_Person.ScrollIntoView(mainViewModel.SelectedPerson);
        //}
    }
}
