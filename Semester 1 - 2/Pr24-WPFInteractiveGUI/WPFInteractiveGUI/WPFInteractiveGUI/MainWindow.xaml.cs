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

namespace WPFInteractiveGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Controller controller;
        public MainWindow()
        {
            InitializeComponent();

            controller = new Controller();

            UpdateGUI();
        }

        public void UpdateGUI()
        {
            //Ved enhver ændring af indholdet i en af tekstboksene, skal data for den valgte person opdateres i Controlleren(via CurrentPerson)
            //Hint: Tekstboksen har et event, der aktiveres hver gang, tekstindholdet ændres
            if (controller.PersonCount == 0)
            {
                NewPersonButton.IsEnabled = true;
                DeletePersonButton.IsEnabled = false;
                UpButton.IsEnabled = false;
                DownButton.IsEnabled = false;

                FirstNameBox.IsEnabled = false;
                LastNameBox.IsEnabled = false;
                AgeBox.IsEnabled = false;
                TelephoneBox.IsEnabled = false;
            }
            else
            {
                NewPersonButton.IsEnabled = true;
                DeletePersonButton.IsEnabled = true;
                UpButton.IsEnabled = true;
                DownButton.IsEnabled = true;

                FirstNameBox.IsEnabled = true;
                LastNameBox.IsEnabled = true;
                AgeBox.IsEnabled = true;
                TelephoneBox.IsEnabled = true;
            }

            PersonCount.Content = controller.PersonCount;
            IndexCount.Content = controller.PersonIndex;
        }

        private void NewPersonButton_Click(object sender, RoutedEventArgs e)
        {
            //Ved klik på ”New Person”, kaldes AddPerson i Controlleren, så den nye person(uden data) indsættes i repositoriet
            //og gøres til den valgte person(CurrentPerson) i Controller’en
            //Den ændring skal afspejles i vinduet, så alle GUI-komponenter er aktive

            controller.AddPerson();

            string test = FirstNameBox.Text;

            UpdateGUI();
        }

        private void DeletePersonButton_Click(object sender, RoutedEventArgs e)
        {
            //Ved klik på ”Delete Person”, kaldes DeletePerson i Controlleren.
            //Dette skaber en ændring i CurrentPerson, der skal afspejles i vinduet.
            //Hvis repositoriet er tomt, da husk kravene foroven

            controller.DeletePerson();
            UpdateGUI();
        }

        private void UpButton_Click(object sender, RoutedEventArgs e)
        {
            //Ved klik på ”Up” kaldes tilsvarende metoder i Controlleren,
            //hvilket indebærer en ny valgt person (CurrentPerson). Denne ændring skal afspejles i vinduet

            controller.NextPerson();
            UpdateGUI();
        }

        private void DownButton_Click(object sender, RoutedEventArgs e)
        {
            //Ved klik på ”Down” kaldes tilsvarende metoder i Controlleren,
            //hvilket indebærer en ny valgt person (CurrentPerson). Denne ændring skal afspejles i vinduet
           
            controller.PrevPerson();
            UpdateGUI();
        }
    }
}
