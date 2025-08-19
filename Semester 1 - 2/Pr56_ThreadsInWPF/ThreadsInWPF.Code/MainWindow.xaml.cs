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

        // Creates our boolean
        bool stopBlender1;
        bool stopBlender2;

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

            // locks buttons
            btnBlend1.IsEnabled = false;
            btnClean1.IsEnabled = false;

            // Unlocks buttons
            btnStop1.IsEnabled = true;

            // Set status for boolean
            stopBlender1 = false;

            // Set start value for our Progress bar
            pbBar1.Value = 0;

            // Blend1();
        }

        // Blend button 2
        private void BtnBlend2_Click(object sender, RoutedEventArgs e)
        {
            mainThread = new Thread(Blend2);
            mainThread.Start();

            // locks buttons
            btnBlend2.IsEnabled = false;
            btnClean2.IsEnabled = false;

            // Unlocks buttons
            btnStop2.IsEnabled = true;

            // Set status for boolean
            stopBlender2 = false;

            // Set start value for our Progress bar
            pbBar2.Value = 0;

            // Blend2();
        }

        // Clean button 1
        private void btnClean1_Click(object sender, RoutedEventArgs e)
        {
            lblStatus1.Content = "Cleaned";
            lbBlender1.Items.Clear();
            pbBar1.Value = 0;

            // Lock button
            btnStop1.IsEnabled = false;
        }

        // Clean button 2
        private void btnClean2_Click(object sender, RoutedEventArgs e)
        {
            lblStatus2.Content = "Cleaned";
            lbBlender2.Items.Clear();
            pbBar2.Value = 0;

            // Lock button
            btnStop2.IsEnabled = false;
        }

        // Stop button 1
        private void btnStop1_Click(object sender, RoutedEventArgs e)
        {
            // Sets new status for boolean
            stopBlender1 = true;
        }

        // Stop button 2
        private void btnStop2_Click(object sender, RoutedEventArgs e)
        {
            // Sets new status for boolean
            stopBlender2 = true;
        }

        // Method for blender 1 to blend items
        private void Blend1()
        {
            int blendTime = 10;
            for (int i = 0; i < blendTime; i++)
            {
                if (stopBlender1 == true)
                {
                    // Break to jump out of statement
                    break;
                }

                // Sets up our progress bar
                pbBar1.Dispatcher.Invoke(new Action(() => { pbBar1.Value = i; }));

                // Updates our content for display
                if (i < 2)
                {
                    lblStatus1.Dispatcher.Invoke(new Action(() => { lblStatus1.Content = "Blender Starting"; }));
                    // lblStatus1.Dispatcher.Invoke(new Action(() => { lblStatus1.Content = $"Blending {i}"; }));
                }
                else if (i < 4)
                {
                    lblStatus1.Dispatcher.Invoke(new Action(() => { lblStatus1.Content = "Blender Halfway"; }));
                }
                else if (i > 8)
                {
                    lblStatus1.Dispatcher.Invoke(new Action(() => { lblStatus1.Content = "Blender Finishing"; }));
                }

                //lblStatus1.Content = $"Blending {i}";
                Thread.Sleep(1000);
            }
            if (stopBlender1 == true)
            {
                lblStatus1.Dispatcher.Invoke(new Action(() => { lblStatus1.Content = "ABORTED"; }));
            }
            else
            {
                lblStatus1.Dispatcher.Invoke(new Action(() => { lblStatus1.Content = "Juice Ready"; }));
            }

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
                // Sets up our progress bar
                pbBar2.Dispatcher.Invoke(new Action(() => { pbBar2.Value = i; }));

                // Updates our content for display
                if (i < 3)
                {
                    lblStatus2.Dispatcher.Invoke(new Action(() => { lblStatus2.Content = "Blender Starting"; }));
                    // lblStatus1.Dispatcher.Invoke(new Action(() => { lblStatus1.Content = $"Blending {i}"; }));
                }
                else if (i < 4)
                {
                    lblStatus2.Dispatcher.Invoke(new Action(() => { lblStatus2.Content = "Blender Halfway"; }));
                }
                else if (i > 8)
                {
                    lblStatus2.Dispatcher.Invoke(new Action(() => { lblStatus2.Content = "Blender Finishing"; }));
                }

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
