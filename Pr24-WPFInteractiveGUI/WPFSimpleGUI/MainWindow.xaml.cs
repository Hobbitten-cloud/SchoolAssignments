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

namespace WPFSimpleGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Scroll_Up(object sender, RoutedEventArgs e)
        {
            // Ved klik på ”Scroll Up” flyttes informationen i tekstboksene ”en linje op”,
            // forstået på den måde, at indholdet i tekstboks 4 flyttes til tekstboks 3,
            // indholdet i tekstboks 3 flyttes til tekstboks 2,
            // osv.Bemærk, at indholdet tekstboks 1 flyttes til tekstboks 4

            string temp1 = tbLine1.Text;
            string temp2 = tbLine2.Text;
            string temp3 = tbLine3.Text;
            string temp4 = tbLine4.Text;

            tbLine4.Text = temp1;
            tbLine3.Text = temp4;
            tbLine2.Text = temp3;
            tbLine1.Text = temp2;

        }

        private void Button_Clear(object sender, RoutedEventArgs e)
        {
            // Ved klik på ”Clear” ryddes indholdet i alle tekstboksene

            tbLine1.Clear();
            tbLine2.Clear();
            tbLine3.Clear();
            tbLine4.Clear();
        }

        private void Button_Scroll_Down(object sender, RoutedEventArgs e)
        {
            // Ved klik på ”Scroll Down” flyttes informationen ”en linje ned”, dvs. det modsatte af ”Scroll Up”

            string temp1 = tbLine1.Text;
            string temp2 = tbLine2.Text;
            string temp3 = tbLine3.Text;
            string temp4 = tbLine4.Text;

            tbLine1.Text = temp2;
            tbLine2.Text = temp3;
            tbLine3.Text = temp4;
            tbLine4.Text = temp1;

        }

        private void Button_Reset(object sender, RoutedEventArgs e)
        {
            string temp1 = "Linje 1";
            string temp2 = "Linje 2";
            string temp3 = "Linje 3";
            string temp4 = "Linje 4";

            tbLine1.Text = temp1;
            tbLine2.Text = temp2;
            tbLine3.Text = temp3;
            tbLine4.Text = temp4;
        }
    }
}