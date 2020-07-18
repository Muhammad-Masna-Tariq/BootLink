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

namespace Fyp
{
    /// <summary>
    /// Interaction logic for FindDialog.xaml
    /// </summary>
    public partial class FindAndReplaceDialog : Window
    {
        private winForms.RichTextBox richTextBox;
        private winForms.RichTextBox cssTextBox;
        private winForms.RichTextBox htmlTextBox;

        public FindAndReplaceDialog(winForms.RichTextBox htmltextBox, winForms.RichTextBox csstextBox)
        {
            InitializeComponent();
            findLabel.Content = "Please enter word to find:";
            findTextbox.Text = "";
            replaceLabel.Content = "Please enter word to replace:";
            replaceTextbox.Text = "";

            this.cssTextBox = csstextBox;
            this.htmlTextBox = htmltextBox;

            if (FindCombobox.SelectedIndex == 0)
            {
                this.richTextBox = htmltextBox;

            }
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            findTextbox.SelectAll();
            findTextbox.Focus();
            replaceWord.IsEnabled = false;
            replaceTextbox.IsEnabled = false;
        }

        private void findWord_Click(object sender, RoutedEventArgs e)
        {
            int length = richTextBox.Text.Length;
            int index = 0;
            int lastIndex = richTextBox.Text.LastIndexOf(findTextbox.Text);
            int found = -1;

            while (index < lastIndex)
            {
                found = richTextBox.Find(findTextbox.Text, index, length, winForms.RichTextBoxFinds.None);
                richTextBox.SelectionBackColor = System.Drawing.Color.Yellow;
                richTextBox.Focus();
                index = richTextBox.Text.IndexOf(findTextbox.Text, index) + 1;
            }

            if (found == -1)
            {
                MessageBox.Show("Word is not Found!. Try Again....", "Find Word", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            if (found != -1)
            {
                replaceWord.IsEnabled = true;
                replaceTextbox.IsEnabled = true;
            }
        }

        private void replaceWord_Click(object sender, RoutedEventArgs e)
        {
            QuickReplace(richTextBox, findTextbox.Text, replaceTextbox.Text);
        }

        public static void QuickReplace(winForms.RichTextBox richTextBox, string findWord, string replaceWord)
        {
            richTextBox.Text = richTextBox.Text.Replace(findWord, replaceWord);
        }

        private void FindCombobox_DropDownClosed(object sender, EventArgs e)
        {
            //MessageBox.Show(FindCombobox.Text.ToString());
            string option = FindCombobox.Text.ToString();
            if (option == "Find in HTML")
            {
                this.richTextBox = this.htmlTextBox;
            }
            else if (option == "Find in CSS")
            {
                this.richTextBox = this.cssTextBox;
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            this.htmlTextBox.SelectionStart = 0;
            this.htmlTextBox.SelectAll();
            this.htmlTextBox.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
