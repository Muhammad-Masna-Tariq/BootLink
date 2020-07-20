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
using System.Text.RegularExpressions;
using CefSharp;

namespace Fyp
{
    /// <summary>
    /// Interaction logic for CustomWindow.xaml
    /// </summary>
    public partial class CustomWindow : Window
    {
        public MainWindow mw {get; set;}

        //Checking if only numbers are entered
        private static readonly Regex _regex = new Regex("^([^0-9]+)$"); //regex that matches disallowed text
        public CustomWindow(string widthQuestion)
        {
            InitializeComponent();
            CustomWidthLabel.Content = widthQuestion;
            WidthTextbox.Text = "";
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            WidthTextbox.SelectAll();
            WidthTextbox.Focus();
        }

        private void ChangeWindowSize_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(WidthTextbox.Text))
            {
                string widthText = WidthTextbox.Text;
                IFrame mobileFrame = this.mw.MainWindowBrowser.GetMainFrame();
                mobileFrame.ExecuteJavaScriptAsync(String.Format("customview(`{0}`)", widthText));
                this.Close();
            }
            else
            {
                MessageBox.Show("Width cannot be empty", "Window Size Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void WidthTextbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
    }
}
