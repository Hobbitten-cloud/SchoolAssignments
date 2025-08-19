using System.Diagnostics.Eventing.Reader;
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

namespace ThreadsInWPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    // Creates our thread
    Thread workThread;

    // Creates our boolean
    bool workAborted;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void BT_StartWork_Click(object sender, RoutedEventArgs e)
    {
        // Resets our progress bar to 0
        PB_Work.Value = 0;

        // Sets our boolean to be false on start work
        workAborted = false;

        // We create a new thread to handle the DoWork which prevents the program from freezing.
        workThread = new Thread(DoWork);
        workThread.Start();
    }

    private void TB_AbortWork_Click(object sender, RoutedEventArgs e)
    {
        // Aborts our work
        workAborted = true;
    }

    private void DoWork()
    {
        for (int i = 0; i < 100; i++)
        {
            // Stops our code from continuing
            if (workAborted == true) // to test if workAborted is true
            {
                break; // Jumps out of the code.
            }

            // Sleep for 50 miliseconds
            Thread.Sleep(50);

            // Sets up our progress bar
            PB_Work.Dispatcher.Invoke(new Action(() => { PB_Work.Value = i; })); // Delegate, Lambda & Dispatcher

            // Works with a textbox to display text while the task is finishing up.
            if (i < 20)
            {
                TB_Work.Dispatcher.Invoke(new Action(() => { TB_Work.Text = "Work Starting ..."; }));
            }
            else if (i < 80)
            {
                TB_Work.Dispatcher.Invoke(new Action(() => { TB_Work.Text = "Work work work ..."; }));
            }
            else if (i < 100)
            {
                TB_Work.Dispatcher.Invoke(new Action(() => { TB_Work.Text = "Work finishing ..."; }));
            }
        }
        if (workAborted == true)
        {
            TB_Work.Dispatcher.Invoke(new Action(() => { TB_Work.Text = "Work Aborted"; }));
        }
        else
        {
            TB_Work.Dispatcher.Invoke(new Action(() => { TB_Work.Text = "Work Finished"; }));
        }
    }
}