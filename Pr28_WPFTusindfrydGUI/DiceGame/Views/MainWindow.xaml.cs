using System.Text;
using System.Windows;
using DiceGame.Views;
using DiceGame.Models;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;
using System.Security.Cryptography;

namespace DiceGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Die> dice = new List<Die>();

        public MainWindow()
        {
            dice.Add(new Die(1, 1));
            dice.Add(new Die(2, 2));
            dice.Add(new Die(3, 3));
            dice.Add(new Die(4, 4));
            dice.Add(new Die(5, 5));
            dice.Add(new Die(6, 6));


            InitializeComponent();

            Dice1.IsEnabled = false;
            Dice2.IsEnabled = false;
            Dice3.IsEnabled = false;
            Dice4.IsEnabled = false;
            Dice5.IsEnabled = false;
            Dice6.IsEnabled = false;
        }

        private void ButtonRules_Click(object sender, RoutedEventArgs e)
        {
            BookOfRules rules = new BookOfRules();
            rules.ShowDialog();
        }

        public void ButtonRoll_Click(object sender, RoutedEventArgs e)
        {
            Dice1.IsEnabled = true;
            Dice2.IsEnabled = true;
            Dice3.IsEnabled = true;
            Dice4.IsEnabled = true;
            Dice5.IsEnabled = true;
            Dice6.IsEnabled = true;


            int i = 0;
            dice[i].FaceValue = 0;
            for (i = 0; i <= 5; i++)
            {

                int x = RandomNumberGenerator.GetInt32(1, 7);
                dice[i].FaceValue = x;

                switch (i)
                {
                    case 0:
                        Dice1.Source = new BitmapImage(new Uri($"/Ressourcer/Image/{x}.png", UriKind.Relative));
                        break;
                    case 1:
                        Dice2.Source = new BitmapImage(new Uri($"/Ressourcer/Image/{x}.png", UriKind.Relative));
                        break;
                    case 2:
                        Dice3.Source = new BitmapImage(new Uri($"/Ressourcer/Image/{x}.png", UriKind.Relative));
                        break;
                    case 3:
                        Dice4.Source = new BitmapImage(new Uri($"/Ressourcer/Image/{x}.png", UriKind.Relative));
                        break;
                    case 4:
                        Dice5.Source = new BitmapImage(new Uri($"/Ressourcer/Image/{x}.png", UriKind.Relative));
                        break;
                    case 5:
                        Dice6.Source = new BitmapImage(new Uri($"/Ressourcer/Image/{x}.png", UriKind.Relative));
                        break;
                }
                dice[i].Status = DiceStatus.Rolled;
            }
        }

        public void Dice1Image(object sender, MouseButtonEventArgs e)
        {

            string selected;
            if (dice[0].Status == DiceStatus.Selected)
            {
                dice[0].Status = DiceStatus.Rolled;
                selected = "";
            }
            else
            {
                dice[0].Status = DiceStatus.Selected;
                selected = "a";
            }
            string face = dice[0].FaceValue.ToString();
            Dice1.Source = new BitmapImage(new Uri($"/Ressourcer/Image/{face}{selected}.png", UriKind.Relative));


            // string selected = dice[0].Status == DiceStatus.Selected ? "" : "a";
            // dice[0].Status = dice[0].Status == DiceStatus.Selected ? DiceStatus.Rolled : DiceStatus.Selected;
        }

        //public void Dice1Image(object sender, MouseButtonEventArgs e)
        //{
        //    // [0] referer til den 1 terning af objekt
        //    if (dice[0].FaceValue == 1)
        //    {
        //        Dice1.Source = new BitmapImage(new Uri($"/Ressourcer/Image/1a.png", UriKind.Relative));

        //        if (dice[0].Status == DiceStatus.Selected)
        //        {
        //            Dice1.Source = new BitmapImage(new Uri($"/Ressourcer/Image/1.png", UriKind.Relative));
        //        }
        //    }
        //    else if (dice[0].FaceValue == 2)
        //    {
        //        Dice1.Source = new BitmapImage(new Uri($"/Ressourcer/Image/2a.png", UriKind.Relative));

        //        if (dice[0].Status == DiceStatus.Selected)
        //        {
        //            Dice1.Source = new BitmapImage(new Uri($"/Ressourcer/Image/2.png", UriKind.Relative));
        //        }
        //    }
        //    else if (dice[0].FaceValue == 3)
        //    {
        //        Dice1.Source = new BitmapImage(new Uri($"/Ressourcer/Image/3a.png", UriKind.Relative));

        //        if (dice[0].Status == DiceStatus.Selected)
        //        {
        //            Dice1.Source = new BitmapImage(new Uri($"/Ressourcer/Image/3.png", UriKind.Relative));
        //        }
        //    }
        //    else if (dice[0].FaceValue == 4)
        //    {
        //        Dice1.Source = new BitmapImage(new Uri($"/Ressourcer/Image/4a.png", UriKind.Relative));

        //        if (dice[0].Status == DiceStatus.Selected)
        //        {
        //            Dice1.Source = new BitmapImage(new Uri($"/Ressourcer/Image/4.png", UriKind.Relative));
        //        }
        //    }
        //    else if (dice[0].FaceValue == 5)
        //    {
        //        Dice1.Source = new BitmapImage(new Uri($"/Ressourcer/Image/5a.png", UriKind.Relative));

        //        if (dice[0].Status == DiceStatus.Selected)
        //        {
        //            Dice1.Source = new BitmapImage(new Uri($"/Ressourcer/Image/5.png", UriKind.Relative));
        //        }
        //    }
        //    else if (dice[0].FaceValue == 6)
        //    {
        //        Dice1.Source = new BitmapImage(new Uri($"/Ressourcer/Image/6a.png", UriKind.Relative));

        //        if (dice[0].Status == DiceStatus.Selected)
        //        {
        //            Dice1.Source = new BitmapImage(new Uri($"/Ressourcer/Image/6.png", UriKind.Relative));
        //        }
        //    }
        //    dice[0].Status = DiceStatus.Selected;
        //}

        private void Dice2Image(object sender, MouseButtonEventArgs e)
        {
            // [1] referer til den 2 terning af objekt
            if (dice[1].FaceValue == 1)
            {
                Dice2.Source = new BitmapImage(new Uri($"/Ressourcer/Image/1a.png", UriKind.Relative));
            }
            else if (dice[1].FaceValue == 2)
            {
                Dice2.Source = new BitmapImage(new Uri($"/Ressourcer/Image/2a.png", UriKind.Relative));
            }
            else if (dice[1].FaceValue == 3)
            {
                Dice2.Source = new BitmapImage(new Uri($"/Ressourcer/Image/3a.png", UriKind.Relative));
            }
            else if (dice[1].FaceValue == 4)
            {
                Dice2.Source = new BitmapImage(new Uri($"/Ressourcer/Image/4a.png", UriKind.Relative));
            }
            else if (dice[1].FaceValue == 5)
            {
                Dice2.Source = new BitmapImage(new Uri($"/Ressourcer/Image/5a.png", UriKind.Relative));
            }
            else if (dice[1].FaceValue == 6)
            {
                Dice2.Source = new BitmapImage(new Uri($"/Ressourcer/Image/6a.png", UriKind.Relative));
            }
        }

        private void Dice3Image(object sender, MouseButtonEventArgs e)
        {
            // [2] referer til den 3 terning af objekt
            if (dice[2].FaceValue == 1)
            {
                Dice3.Source = new BitmapImage(new Uri($"/Ressourcer/Image/1a.png", UriKind.Relative));
            }
            else if (dice[2].FaceValue == 2)
            {
                Dice3.Source = new BitmapImage(new Uri($"/Ressourcer/Image/2a.png", UriKind.Relative));
            }
            else if (dice[2].FaceValue == 3)
            {
                Dice3.Source = new BitmapImage(new Uri($"/Ressourcer/Image/3a.png", UriKind.Relative));
            }
            else if (dice[2].FaceValue == 4)
            {
                Dice3.Source = new BitmapImage(new Uri($"/Ressourcer/Image/4a.png", UriKind.Relative));
            }
            else if (dice[2].FaceValue == 5)
            {
                Dice3.Source = new BitmapImage(new Uri($"/Ressourcer/Image/5a.png", UriKind.Relative));
            }
            else if (dice[2].FaceValue == 6)
            {
                Dice3.Source = new BitmapImage(new Uri($"/Ressourcer/Image/6a.png", UriKind.Relative));
            }
        }

        private void Dice4Image(object sender, MouseButtonEventArgs e)
        {
            // [3] referer til den 4 terning af objekt
            if (dice[3].FaceValue == 1)
            {
                Dice4.Source = new BitmapImage(new Uri($"/Ressourcer/Image/1a.png", UriKind.Relative));
            }
            else if (dice[3].FaceValue == 2)
            {
                Dice4.Source = new BitmapImage(new Uri($"/Ressourcer/Image/2a.png", UriKind.Relative));
            }
            else if (dice[3].FaceValue == 3)
            {
                Dice4.Source = new BitmapImage(new Uri($"/Ressourcer/Image/3a.png", UriKind.Relative));
            }
            else if (dice[3].FaceValue == 4)
            {
                Dice4.Source = new BitmapImage(new Uri($"/Ressourcer/Image/4a.png", UriKind.Relative));
            }
            else if (dice[3].FaceValue == 5)
            {
                Dice4.Source = new BitmapImage(new Uri($"/Ressourcer/Image/5a.png", UriKind.Relative));
            }
            else if (dice[3].FaceValue == 6)
            {
                Dice4.Source = new BitmapImage(new Uri($"/Ressourcer/Image/6a.png", UriKind.Relative));
            }
        }

        private void Dice5Image(object sender, MouseButtonEventArgs e)
        {
            // [4] referer til den 5 terning af objekt
            if (dice[4].FaceValue == 1)
            {
                Dice5.Source = new BitmapImage(new Uri($"/Ressourcer/Image/1a.png", UriKind.Relative));
            }
            else if (dice[4].FaceValue == 2)
            {
                Dice5.Source = new BitmapImage(new Uri($"/Ressourcer/Image/2a.png", UriKind.Relative));
            }
            else if (dice[4].FaceValue == 3)
            {
                Dice5.Source = new BitmapImage(new Uri($"/Ressourcer/Image/3a.png", UriKind.Relative));
            }
            else if (dice[4].FaceValue == 4)
            {
                Dice5.Source = new BitmapImage(new Uri($"/Ressourcer/Image/4a.png", UriKind.Relative));
            }
            else if (dice[4].FaceValue == 5)
            {
                Dice5.Source = new BitmapImage(new Uri($"/Ressourcer/Image/5a.png", UriKind.Relative));
            }
            else if (dice[4].FaceValue == 6)
            {
                Dice5.Source = new BitmapImage(new Uri($"/Ressourcer/Image/6a.png", UriKind.Relative));
            }
        }

        private void Dice6Image(object sender, MouseButtonEventArgs e)
        {
            // [5] referer til den 6 terning af objekt
            if (dice[5].FaceValue == 1)
            {
                Dice6.Source = new BitmapImage(new Uri($"/Ressourcer/Image/1a.png", UriKind.Relative));
            }
            else if (dice[5].FaceValue == 2)
            {
                Dice6.Source = new BitmapImage(new Uri($"/Ressourcer/Image/2a.png", UriKind.Relative));
            }
            else if (dice[5].FaceValue == 3)
            {
                Dice6.Source = new BitmapImage(new Uri($"/Ressourcer/Image/3a.png", UriKind.Relative));
            }
            else if (dice[5].FaceValue == 4)
            {
                Dice6.Source = new BitmapImage(new Uri($"/Ressourcer/Image/4a.png", UriKind.Relative));
            }
            else if (dice[5].FaceValue == 5)
            {
                Dice6.Source = new BitmapImage(new Uri($"/Ressourcer/Image/5a.png", UriKind.Relative));
            }
            else if (dice[5].FaceValue == 6)
            {
                Dice6.Source = new BitmapImage(new Uri($"/Ressourcer/Image/6a.png", UriKind.Relative));
            }
        }
    }

}