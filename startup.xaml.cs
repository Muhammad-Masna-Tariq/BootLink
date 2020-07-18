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
using winForms = System.Windows.Forms;

using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Threading;

namespace Fyp
{

    /// <summary>
    /// Interaction logic for startup.xaml
    /// </summary>
    public partial class startup : Window
    {
        

        public startup()
        {
            InitializeComponent();
        }
        public void New_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            String templateFiles = System.Windows.Forms.Application.StartupPath + @"\\dnd\";
            mw.MainWindowBrowser.Address = templateFiles + "dandd.html";
            mw.Show();
            this.Close();

        }
        public void Open_Click(object sender, RoutedEventArgs e)
        {
            String templateFiles = System.Windows.Forms.Application.StartupPath + @"\\dnd\";

            MainWindow mw = new MainWindow();
            mw.MainWindowBrowser.Address = templateFiles + "dandd.html";
            mw.Show();
            this.Close();
            mw.OpenProject_Startup();
            

        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public void Template_Click(object sender, RoutedEventArgs e)
        {
            String templateFiles = System.Windows.Forms.Application.StartupPath + @"\\dnd\";
            
            String name = ((Button)sender).Name;
            MainWindow mw = new MainWindow();

            if (name.Equals("Blank"))
            {
                mw.MainWindowBrowser.Address = templateFiles + "dandd.html";

            }
            else if(name.Equals("Album"))
            {
                mw.MainWindowBrowser.Address = templateFiles + "album.html";
            }
            else if (name.Equals("Pricing"))
            {
                mw.MainWindowBrowser.Address = templateFiles + "pricing.html";

            }
            else if (name.Equals("Shipping"))
            {
                mw.MainWindowBrowser.Address = templateFiles + "shipping.html";

            }
            else if (name.Equals("Product"))
            {
                mw.MainWindowBrowser.Address = templateFiles + "product.html";

            }
            else if (name.Equals("Landing"))
            {
                mw.MainWindowBrowser.Address = templateFiles + "cover.html";

            }
            else if (name.Equals("Carousel"))
            {
                mw.MainWindowBrowser.Address = templateFiles + "carousel.html";


            }
            else if (name.Equals("Login"))
            {
                mw.MainWindowBrowser.Address = templateFiles + "signin.html";

            }
            else
            {
                MessageBox.Show("There was some kind of error!");
            }
           
            mw.Show();
            this.Close();
        }

        //For dragging and moving window
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg,
                int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void TitleBar_MoveWindow(object sender, MouseButtonEventArgs e)
        {
            ReleaseCapture();
            SendMessage(new WindowInteropHelper(this).Handle,
                WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

    }
}
