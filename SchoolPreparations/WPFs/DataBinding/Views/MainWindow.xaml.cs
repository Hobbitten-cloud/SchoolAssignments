using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestWPF.ViewModels;

namespace TestWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        MainViewModel mvm = new MainViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = mvm;
        }

        private void Button_Update(object sender, RoutedEventArgs e)
        {
            mvm.FirstName = DateTime.Now.ToString();
            mvm.LastName = DateTime.Now.ToString();
        }
    }
}