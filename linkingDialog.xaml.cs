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

namespace Fyp
{
    /// <summary>
    /// Interaction logic for linkingDialog.xaml
    /// </summary>
    public partial class linkingDialog : Window
    {
        public String link = "";
        public bool filedialog = false;

        public linkingDialog()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            link = linkbox.Text;
            filedialog = false;
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            filedialog = true;
            this.Close();
        }
    }
}
