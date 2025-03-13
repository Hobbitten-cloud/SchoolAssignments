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

namespace TusindfrydWPF
{
    /// <summary>
    /// Interaction logic for CreateFlowerSortDialog.xaml
    /// </summary>
    public partial class CreateFlowerSortDialog : Window
    {
        public FlowerSort flowerSort = new FlowerSort();

        public CreateFlowerSortDialog()
        {
            InitializeComponent();
            okButton.IsEnabled = false;
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            if (NameBox.Text != "" && PictureBox.Text != "" && ProductiontimeBox.Text != "" && HalflifetimeBox.Text != "" && SizeBox.Text != "")
            {
                okButton.IsEnabled = true;
                bool fail = true;

                if (okButton.IsMouseOver)
                {
                    flowerSort.Name = NameBox.Text;
                    flowerSort.PicturePath = PictureBox.Text;

                    try
                    {
                        flowerSort.ProductionTime = int.Parse(ProductiontimeBox.Text);
                        flowerSort.HalfLifeTime = int.Parse(HalflifetimeBox.Text);
                        flowerSort.Size = int.Parse(SizeBox.Text);
                    }
                    catch (FormatException b)
                    {
                        fail = false;
                        MessageBox.Show("Der er fejl i dine informationer. Prøv igen");
                    }

                    if (fail == true)
                    {
                        MessageBox.Show("Informationerne er gemt");
                        fail = false;

                        DialogResult = true;
                    }
                }
            }
            else
            {
                okButton.IsEnabled = false;
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            NameBox.Clear();
            PictureBox.Clear();
            ProductiontimeBox.Clear();
            HalflifetimeBox.Clear();
            SizeBox.Clear();
        }

        private void AllFieldsChanged(object sender, TextChangedEventArgs e)
        {
            okButton_Click(sender, e);
        }

        private void PictureBox_LostFocus(object sender, RoutedEventArgs e)
        {
            okButton_Click(sender, e);

            try
            {
                BitmapImage bitmap = new BitmapImage(new Uri(PictureBox.Text, UriKind.RelativeOrAbsolute));
                PictureImage.Source = bitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kunne ikke indlæse billedet. Tjek stien og prøv igen.");
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Du er klikket på den her checkbox!");
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Du er klikket på den her checkbox!");
        }

        // Alle felter skal være udfyldt for, at en gyldig blomstersort accepteres ved klik på OK-knappen

        /*
            Image UI-kontrollen skal vise det billede, som stien peger på (foroven vises bare et eksempel). 
            Så snart TextBox’en for billedstien mister fokus (LostFocus-eventet) skal det angivne billede vises, 
            hvis muligt. Hvis der opstår en fejl, så håndtér den med brug af exceptions (try-catch-finally).
            Selve billedet skal ikke gemmes i FlowerSort-objektet, kun stien til billedet
        */






    }
}
