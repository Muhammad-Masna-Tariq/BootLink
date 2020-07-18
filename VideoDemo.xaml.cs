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
using System.Windows.Threading;
using winForms = System.Windows.Forms;

namespace Fyp
{
    /// <summary>
    /// Interaction logic for VideoDemo.xaml
    /// </summary>
    public partial class VideoDemo : Window
    {
        private int check = 2;

        public VideoDemo()
        {
            InitializeComponent();

            string path = winForms.Application.StartupPath + @"\\Video\demo.mp4";
            Uri uri = new Uri(path, UriKind.Absolute);
            demoPlayer.Source = uri;

            check = 1;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        public void timer_Tick(object sender, EventArgs e)
        {
            if (demoPlayer.Source != null)
            {
                if (demoPlayer.NaturalDuration.HasTimeSpan)
                    lblStatus.Content = string.Format("{0} / {1}", demoPlayer.Position.ToString(@"mm\:ss"), demoPlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
            }
            else
                lblStatus.Content = "No file selected...";
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            demoPlayer.Play();
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            demoPlayer.Pause();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            demoPlayer.Stop();
        }
    }
}
