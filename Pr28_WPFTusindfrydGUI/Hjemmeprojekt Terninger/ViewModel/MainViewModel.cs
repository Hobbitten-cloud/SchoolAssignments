using Hjemmeprojekt_Terninger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Net.Mime;
using System.Windows.Controls;
using System.ComponentModel;

namespace Hjemmeprojekt_Terninger.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public Image[] dieImages = new Image[6];
        public List<Die> dice = new List<Die>();

        public event PropertyChangedEventHandler? PropertyChanged;

        private string _image1Path = "/Resources/Images/Terning1.png";

        public string Image1Path
        {
            get { return _image1Path; }
            set { _image1Path = value; }
        }

        public MainViewModel() 
        {

            dice.Add(new Die(1, 1));
            dice.Add(new Die(2, 2));
            dice.Add(new Die(3, 3));
            dice.Add(new Die(4, 4));
            dice.Add(new Die(5, 5));
            dice.Add(new Die(6, 6));

            dieImages[0] = imageDice1;
            dieImages[1] = imageDice2;
            dieImages[2] = imageDice3;
            dieImages[3] = imageDice4;
            dieImages[4] = imageDice5;
            dieImages[5] = imageDice6;
        }
        public void UpdateDieColorToBlue(int die)
        {
            for (int i = 1; i <= 6; i++)
            {
                if (dice[die - 1].FaceValue == i)
                {
                    dieImages[die - 1].Source = new BitmapImage(new Uri($"/Resources/Images/BlaaTerning{i}.png", UriKind.Relative));
                    break;
                }
            }
        }
    }
}
