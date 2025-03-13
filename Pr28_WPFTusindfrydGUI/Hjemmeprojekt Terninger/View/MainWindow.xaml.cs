using Hjemmeprojekt_Terninger.Model;
using Hjemmeprojekt_Terninger.View;
using Hjemmeprojekt_Terninger.ViewModel;
using System.Security.Cryptography;
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


namespace Hjemmeprojekt_Terninger
{
    public partial class MainWindow : Window
    {
        

        MainViewModel viewModel;
        public MainWindow()
        {

            InitializeComponent();
            DataContext = viewModel;
            

            viewModel = new MainViewModel();
        }


        private void buttonBookRules_Click(object sender, RoutedEventArgs e)
        {
            RulesTable rulesTable = new RulesTable();
            rulesTable.ShowDialog();
        }

        private void buttonRollDice_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i <= 5; i++)
            {
                int x = RandomNumberGenerator.GetInt32(1, 7);
                dice[i].FaceValue = x;
                switch (i)
                {
                    case 0:
                        imageDice1.Source = new BitmapImage(new Uri($"/Resources/Images/Terning{x}.png", UriKind.Relative));
                        break;
                    case 1:
                        imageDice2.Source = new BitmapImage(new Uri($"/Resources/Images/Terning{x}.png", UriKind.Relative));
                        break;
                    case 2:
                        imageDice3.Source = new BitmapImage(new Uri($"/Resources/Images/Terning{x}.png", UriKind.Relative));
                        break;
                    case 3:
                        imageDice4.Source = new BitmapImage(new Uri($"/Resources/Images/Terning{x}.png", UriKind.Relative));
                        break;
                    case 4:
                        imageDice5.Source = new BitmapImage(new Uri($"/Resources/Images/Terning{x}.png", UriKind.Relative));
                        break;
                    case 5:
                        imageDice6.Source = new BitmapImage(new Uri($"/Resources/Images/Terning{x}.png", UriKind.Relative));
                        break;
                }
            }
        }
       
        private void imageDice1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            viewModel.UpdateDieColorToBlue(1);
        }
        private void imageDice2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            viewModel.UpdateDieColorToBlue(2);
        }
        private void imageDice3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            viewModel.UpdateDieColorToBlue(3);
        }
        private void imageDice4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            viewModel.UpdateDieColorToBlue(4);
        }
        private void imageDice5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            viewModel.UpdateDieColorToBlue(5);
        }
        private void imageDice6_MouseDown(object sender, MouseButtonEventArgs e)
        {
            viewModel.UpdateDieColorToBlue(6);
        }
    }
}