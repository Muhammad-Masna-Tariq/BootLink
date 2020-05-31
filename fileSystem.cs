﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using winForms = System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace Fyp
{
    class fileSystem
    {
        private static bool save = false; // used to check that the HTML file is already saved or not
        private static string savepath;
        private static string csssavepath;
        private string htmlpathString;
        private string csspathString;

        public void NewProject(winForms.RichTextBox htmlTextBox, winForms.RichTextBox csstextBox, MenuItem SaveProject)
        {
            if (SaveProject.IsEnabled == true)
            {

                MessageBoxResult msgBoxRes = MessageBox.Show("Do you want to save content or not?", "Save File", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (msgBoxRes == MessageBoxResult.Yes)
                {
                    Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog();
                    sfd.DefaultExt = ".html";
                    sfd.Filter = "HTML File (.html)|*.html";
                    if (sfd.ShowDialog() == true && sfd.FileName.Length > 0)
                    {
                        File.WriteAllText(sfd.FileName, htmlTextBox.Text);
                    }

                    //For CSS
                    Microsoft.Win32.SaveFileDialog csssfd = new Microsoft.Win32.SaveFileDialog();
                    sfd.DefaultExt = ".css";
                    sfd.Filter = "CSS File (.css)|*.css";
                    if (csssfd.ShowDialog() == true && csssfd.FileName.Length > 0)
                    {
                        File.WriteAllText(csssfd.FileName, csstextBox.Text);
                    }
                }

            }
            //Need to use System.Windows.Forms to get open folder dialog
            // Show the FolderBrowserDialog.
            winForms.FolderBrowserDialog folderDialog = new winForms.FolderBrowserDialog();
            folderDialog.SelectedPath = System.AppDomain.CurrentDomain.BaseDirectory;
            winForms.DialogResult fdr = folderDialog.ShowDialog();

            if (fdr == winForms.DialogResult.OK)
            {
                String folderPath = folderDialog.SelectedPath;
                String htmlfilename = "index.html";
                String cssfilename = "style.css";
                htmlpathString = System.IO.Path.Combine(folderPath, htmlfilename);
                csspathString = System.IO.Path.Combine(folderPath, cssfilename);
                if (!System.IO.File.Exists(htmlpathString))
                {
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(htmlpathString))
                        {
                            writer.WriteLine("<html>");
                            writer.WriteLine("  <head>");
                            writer.WriteLine("    <!-- Required meta tags -->");
                            writer.WriteLine("    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1, shrink-to-fit=no\">");
                            writer.WriteLine("");
                            writer.WriteLine("    <!-- Bootstrap CSS -->");
                            writer.WriteLine("    <link rel=\"stylesheet\" href=\"https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css\" integrity=\"sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T\" crossorigin=\"anonymous\">");
                            writer.WriteLine("    <link rel=\"stylesheet\" href=\"style.css\">");
                            writer.WriteLine("");
                            writer.WriteLine("    <title>Hello, world!</title>");
                            writer.WriteLine("  </head>");
                            writer.WriteLine("  <body>");
                            writer.WriteLine("    <ul class=\"nav\">");
                            writer.WriteLine("      <li class=\"nav-item\">");
                            writer.WriteLine("        <a class=\"nav-link active\" href=\"#\">Active</a>");
                            writer.WriteLine("      </li>");
                            writer.WriteLine("      <li class=\"nav-item\">");
                            writer.WriteLine("        <a class=\"nav-link\" href=\"#\">Link</a>");
                            writer.WriteLine("      </li>");
                            writer.WriteLine("    </ul>");
                            writer.WriteLine("    <h1>Hello World!</h1>");
                            writer.WriteLine("");
                            writer.WriteLine("    <!-- Optional JavaScript -->");
                            writer.WriteLine("    <!-- jQuery first, then Popper.js, then Bootstrap JS -->");
                            writer.WriteLine("    <script src=\"https://code.jquery.com/jquery-3.3.1.slim.min.js\" integrity=\"sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo\" crossorigin=\"anonymous\"></script>");
                            writer.WriteLine("    <script src=\"https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js\" integrity=\"sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1\" crossorigin=\"anonymous\"></script>");
                            writer.WriteLine("    <script src=\"https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js\" integrity=\"sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM\" crossorigin=\"anonymous\"></script>");
                            writer.WriteLine("  </body>");
                            writer.WriteLine("</html>");
                        }
                        //After html success, For CSS file creation
                        if (!System.IO.File.Exists(csspathString))
                        {
                            using (StreamWriter writer = new StreamWriter(csspathString))
                            {
                                writer.WriteLine("body{");
                                writer.WriteLine("\tbackground-color:black;");
                                writer.WriteLine("}");
                                writer.WriteLine("h1{");
                                writer.WriteLine("\tcolor:white;");
                                writer.WriteLine("}");
                            }
                        }
                        else
                        {
                            System.Windows.MessageBox.Show("Error! File already exists.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    }
                    catch (Exception e)
                    {
                        winForms.MessageBox.Show("There seems to be some error creating a directory");
                        return;
                    }

                    save = true;
                    savepath = htmlpathString;
                    csssavepath = csspathString;
                }
                else
                {
                    System.Windows.MessageBox.Show("Error! File already exists.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }






                StreamReader sr1 = new StreamReader(htmlpathString, Encoding.Default);
                htmlTextBox.Text = sr1.ReadToEnd();

                StreamReader sr2 = new StreamReader(csspathString, Encoding.Default);
                csstextBox.Text = sr2.ReadToEnd();

                sr1.Dispose();
                sr2.Dispose();

                //stop single line grammercheck firing
                MainWindow.htmlfire = false;
                MainWindow.fire = false;
                //creating objects to simulate validation
                htmltextBoxClass htb = new htmltextBoxClass();
                csstextBoxClass ctb = new csstextBoxClass();


                //Overriding Paste Functionality
                //Showing busy work with mouse
                Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
                try
                {
                    htb.ValidateTags(htmlTextBox);
                    ctb.clipboardGrammerCheck(csstextBox);

                }
                finally
                {
                    Mouse.OverrideCursor = null;
                }
                MainWindow.htmlfire = true;
                MainWindow.fire = true;

            }

            SaveProject.IsEnabled = false;
        }

        public void OpenProject(winForms.RichTextBox htmlTextBox, winForms.RichTextBox csstextBox, MenuItem SaveProject)
        {
            if (SaveProject.IsEnabled == true)
            {
                MessageBoxResult msgBoxRes = MessageBox.Show("Do you want to save content or not?", "Save File", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (msgBoxRes == MessageBoxResult.Yes)
                {
                    Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog();
                    sfd.DefaultExt = ".html";
                    sfd.Filter = "HTML File (.html)|*.html";
                    if (sfd.ShowDialog() == true && sfd.FileName.Length > 0)
                    {
                        File.WriteAllText(sfd.FileName, htmlTextBox.Text);
                        savepath = sfd.FileName.ToString();
                        save = true;
                    }

                    //Open the respective css file
                    sfd.DefaultExt = ".css";
                    sfd.Filter = "CSS File (.css)|*.css";
                    if (sfd.ShowDialog() == true && sfd.FileName.Length > 0)
                    {
                        File.WriteAllText(sfd.FileName, csstextBox.Text);
                        csssavepath = sfd.FileName.ToString();
                        save = true;
                    }
                }
            }
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.DefaultExt = ".html";
            ofd.Filter = "HTML File (.html)|*.html|ALL Files (.)|*.*";
            if (ofd.ShowDialog() == true)
            {
                StreamReader sr1 = new StreamReader(ofd.FileName, Encoding.Default);
                htmlTextBox.Text = sr1.ReadToEnd();
                save = true;
                savepath = ofd.FileName.ToString();
            }

            ofd.Title = "Open CSS file";
            ofd.DefaultExt = ".css";
            ofd.Filter = "CSS File (.css)|*.css|ALL Files (.)|*.*";
            if (ofd.ShowDialog() == true)
            {
                StreamReader sr1 = new StreamReader(ofd.FileName, Encoding.Default);
                csstextBox.Text = sr1.ReadToEnd();
                save = true;
                csssavepath = ofd.FileName.ToString();

            }


            //validation
            //stop single line grammercheck firing
            MainWindow.htmlfire = false;
            MainWindow.fire = false;
            //creating objects to simulate validation
            htmltextBoxClass htb = new htmltextBoxClass();
            csstextBoxClass ctb = new csstextBoxClass();


            //Overriding Paste Functionality
            //Showing busy work with mouse
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
            try
            {
                htb.ValidateTags(htmlTextBox);
                ctb.clipboardGrammerCheck(csstextBox);

            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
            MainWindow.htmlfire = true;
            MainWindow.fire = true;


            SaveProject.IsEnabled = false;
            save = true;
        }

        public void SaveProject(winForms.RichTextBox htmlTextBox, winForms.RichTextBox csstextBox)
        {
            if (save == false)
            {
                Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog();
                sfd.DefaultExt = ".html";
                sfd.Filter = "HTML File (.html)|*.html";
                if (sfd.ShowDialog() == true && sfd.FileName.Length > 0)
                {
                    File.WriteAllText(sfd.FileName, htmlTextBox.Text);
                    savepath = sfd.FileName.ToString();
                    save = true;
                }

                sfd.DefaultExt = ".css";
                sfd.Filter = "CSS File (.css)|*.css";

                if (sfd.ShowDialog() == true && sfd.FileName.Length > 0)
                {
                    File.WriteAllText(sfd.FileName, csstextBox.Text);
                    csssavepath = sfd.FileName.ToString();
                    save = true;
                }

                /*string newpath = savepath.LastIndexOf("/");
                Console.WriteLine(savepath + "\n" + newpath);
                //copying media folder to dest file
                //CloneDirectory(winForms.Application.StartupPath + @"\dnd\media\", sfd.Get);*/
            }
            else
            {
                File.WriteAllText(savepath, htmlTextBox.Text);
                File.WriteAllText(csssavepath, csstextBox.Text);

                
            }

            

            //validation
            //stop single line grammercheck firing
            MainWindow.htmlfire = false;
            MainWindow.fire = false;
            //creating objects to simulate validation
            htmltextBoxClass htb = new htmltextBoxClass();
            csstextBoxClass ctb = new csstextBoxClass();


            //Overriding Paste Functionality
            //Showing busy work with mouse
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
            try
            {
                htb.ValidateTags(htmlTextBox);
                ctb.clipboardGrammerCheck(csstextBox);

            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
            MainWindow.htmlfire = true;
            MainWindow.fire = true;
        }

        public void ExitApplication(winForms.RichTextBox htmlTextBox, winForms.RichTextBox csstextBox, MenuItem SaveProject)
        {
            if (SaveProject.IsEnabled == true)
            {
                MessageBoxResult msgBoxRes = MessageBox.Show("Do you want to save content or not?", "Save File", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                if (msgBoxRes == MessageBoxResult.Yes)
                {
                    Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog();
                    sfd.DefaultExt = ".html";
                    sfd.Filter = "HTML File (.html)|*html";
                    if (sfd.ShowDialog() == true && sfd.FileName.Length > 0)
                    {
                        File.WriteAllText(sfd.FileName, htmlTextBox.Text);
                    }
                    sfd.DefaultExt = ".css";
                    sfd.Filter = "CSS File (.css)|*css";
                    if (sfd.ShowDialog() == true && sfd.FileName.Length > 0)
                    {
                        File.WriteAllText(sfd.FileName, csstextBox.Text);
                    }
                    Application.Current.Shutdown();
                }
                else if (msgBoxRes == MessageBoxResult.No)
                {
                    Application.Current.Shutdown();
                }
            }
        }

        public void ChangeFontSize(winForms.RichTextBox htmlTextBox, winForms.RichTextBox csstextBox, winForms.RichTextBox htmlTextBoxLine, winForms.RichTextBox csstextBoxLine)
        {
            System.Windows.Forms.FontDialog fDialog = new System.Windows.Forms.FontDialog();
            fDialog.MaxSize = 20;
            System.Windows.Forms.DialogResult res = fDialog.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                htmlTextBox.Font = fDialog.Font;
                htmlTextBoxLine.Font = fDialog.Font;

                csstextBox.Font = fDialog.Font;
                csstextBoxLine.Font = fDialog.Font;
            }
        }

        public void Preview()
        {
            if (save == true)
            {
                Preview p = new Preview(savepath);
                p.Show();
            }
            else
            {
                MessageBox.Show("Please first save your file", "Save File", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public void Manual()
        {
            string path = winForms.Application.StartupPath + @"\\scope.pdf";
            Preview p = new Preview(path);
            p.Show();
        }
    }
}