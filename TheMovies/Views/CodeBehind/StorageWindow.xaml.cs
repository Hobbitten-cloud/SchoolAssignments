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
using System.Windows.Shapes;
using TheMovies.Views.CodeBehind;

namespace TheMovies.ViewModel
{
    /// <summary>
    /// Interaction logic for StorageWindow.xaml
    /// </summary>
    public partial class StorageWindow : Window
    {
        public StorageWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FilmWindow filmWindow = new FilmWindow();
            filmWindow.Show();
            this.Close();
        }
    }
}
