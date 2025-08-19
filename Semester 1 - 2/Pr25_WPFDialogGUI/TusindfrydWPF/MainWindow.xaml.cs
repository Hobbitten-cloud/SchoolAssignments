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

namespace TusindfrydWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Creates the flowerSort class as a list
        List<FlowerSort> flowerSorts;

        public MainWindow()
        {
            InitializeComponent();
            flowerSorts = new List<FlowerSort>();
        }

        private void CreateFlowerButton_Click(object sender, RoutedEventArgs e)
        {
            CreateFlowerSortDialog dialog = new CreateFlowerSortDialog();

            if(dialog.ShowDialog() == true)
            {
                flowerSorts.Add(dialog.flowerSort);
                tbRepo.Text = string.Empty;
                foreach (FlowerSort flowerSort in flowerSorts)
                {
                    tbRepo.Text = tbRepo.Text + flowerSort.Name + "\n";
                }
            }
        }
    }
}