using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ThreadsInWPF.Code
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Background thread.
        Thread mainThread;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Put in button 1
        private void BtnPutIn1_Click(object sender, RoutedEventArgs e)
        {
            if (lbFruits.SelectedItem != null)
            {
                var fruit = (lbFruits.SelectedItem as ListBoxItem).Content;
                lbBlender1.Items.Add(new ListBoxItem { Content = fruit });
            }
        }

        // Put in button 2
        private void BtnPutIn2_Click(object sender, RoutedEventArgs e)
        {
            if (lbFruits.SelectedItem != null)
            {
                var fruit = (lbFruits.SelectedItem as ListBoxItem).Content;
                lbBlender2.Items.Add(new ListBoxItem { Content = fruit });
            }
        }

        // Blend button 1
        private void BtnBlend1_Click(object sender, RoutedEventArgs e)
        {
            mainThread = new Thread(Blend1);
            mainThread.Start();

            // locks button
            btnBlend1.IsEnabled = false;
            btnClean1.IsEnabled = false;

            // Blend1();
        }

        // Blend button 2
        private void BtnBlend2_Click(object sender, RoutedEventArgs e)
        {
            mainThread = new Thread(Blend2);
            mainThread.Start();

            // locks button
            btnBlend2.IsEnabled = false;
            btnClean2.IsEnabled = false;

            // Blend2();
        }

        // Clean button 1
        private void btnClean1_Click(object sender, RoutedEventArgs e)
        {
            lblStatus1.Content = "Cleaned";
            lbBlender1.Items.Clear();
        }

        // Clean button 2
        private void btnClean2_Click(object sender, RoutedEventArgs e)
        {
            lblStatus2.Content = "Cleaned";
            lbBlender2.Items.Clear();
        }

        // Method for blender 1 to blend items
        private void Blend1()
        {
            int blendTime = 10;
            for (int i = 0; i < blendTime; i++)
            {
                lblStatus1.Dispatcher.Invoke(new Action(() => { lblStatus1.Content = $"Blending {i}"; }));
                // lblStatus1.Dispatcher.Invoke(new Action(() => { lblStatus1.Content = "Blending " + i; }));

                //lblStatus1.Content = $"Blending {i}";
                Thread.Sleep(1000);
            }
            lblStatus1.Dispatcher.Invoke(new Action(() => { lblStatus1.Content = "Juice Ready"; }));

            // unlocks button
            //btnBlend1.IsEnabled = true;
            btnBlend1.Dispatcher.Invoke(new Action(() => { btnBlend1.IsEnabled = true; }));
            btnClean1.Dispatcher.Invoke(new Action(() => { btnClean1.IsEnabled = true; }));

            //lblStatus1.Content = "Juice Ready";
        }


        // Method for blender 2 to blend items
        private void Blend2()
        {
            int blendTime = 10;
            for (int i = 0; i < blendTime; i++)
            {
                lblStatus2.Dispatcher.Invoke(new Action(() => { lblStatus2.Content = $"Blending {i}"; }));

                //lblStatus2.Content = $"Blending {i}";
                Thread.Sleep(1000);
            }
            lblStatus2.Dispatcher.Invoke(new Action(() => { lblStatus2.Content = "Juice Ready"; }));

            // unlocks button
            //btnBlend2.IsEnabled = true;
            btnBlend2.Dispatcher.Invoke(new Action(() => { btnBlend2.IsEnabled = true; }));
            btnClean2.Dispatcher.Invoke(new Action(() => { btnClean2.IsEnabled = true; }));

            //lblStatus2.Content = "Juice Ready";
        }
    }
}
