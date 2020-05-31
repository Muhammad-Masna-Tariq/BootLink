using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using winForms = System.Windows.Forms;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Windows.Input;
using CefSharp;
namespace Fyp
{
    class DragnDrop
    {
        public static String htmlHolder { get; set; }
        public MainWindow mw { get; set; }
        public bool setChange { get; set; }

        private static string path = winForms.Application.StartupPath + @"\dnd\media\";
        public void updateHTMLBox(string msg)
        {
            if(this.setChange == false)
            {
                //Read Note
                htmlHolder = msg;
                this.mw.Dispatcher.Invoke(() =>
                {
                    this.mw.htmlTextBox.Text = msg;
                    this.mw.assistant.TextChanged();
                    //((MainWindow)System.Windows.Application.Current.MainWindow)

                    //validation
                    //stop single line grammercheck firing
                    MainWindow.htmlfire = false;
                    MainWindow.fire = false;

                    //creating objects to simulate validation
                    htmltextBoxClass htb = new htmltextBoxClass();
                    //csstextBoxClass ctb = new csstextBoxClass();


                    //Overriding Paste Functionality
                    //Showing busy work with mouse
                    Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
                    try
                    {
                        htb.ValidateTags(this.mw.htmlTextBox);
                    }
                    finally
                    {
                        Mouse.OverrideCursor = null;
                    }
                    MainWindow.htmlfire = true;
                    MainWindow.fire = true;
                });
            }

        }
        public void updateChange(String value)
        {

            if (value == "false")
            {
                this.setChange = false;
            }
            else if (value == "true")
            {
                this.setChange = true;
            }
        }

        public string uploadItem(String type)
        {
            String linkpath = "";
            this.mw.Dispatcher.Invoke(() =>
            {
                linkingDialog ld = new linkingDialog();
                ld.ShowDialog();
            

            if (ld.filedialog)
            {
                // Set the file dialog to filter for graphics files.
                Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();

                if (type.Equals("image"))
                {
                    ofd.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF| All files (*.*)|*.*";
                    ofd.Title = "Select Image";
                    if (ofd.ShowDialog() == true)
                    {
                        string imageFN = ofd.FileName;
                        string location = path + "images\\";
                        string filename = Path.GetFileName(imageFN);
                        filename = filename.Replace(" ", "_");
                        string fullPath = Path.Combine(@"media\images\", filename);
                        System.IO.File.Copy(imageFN, Path.Combine(location, filename), true);

                            linkpath =  fullPath;

                    }
                }
                else if (type.Equals("video"))
                {
                    ofd.Filter = "Video Files|*.avi;*.flv;*.mkv;*.mov;*.mp4;*.webm;*.wmv";

                    ofd.Title = "Select Video";
                    if (ofd.ShowDialog() == true)
                    {
                        string videoFN = ofd.FileName;
                        string location = path + "videos\\";
                        string filename = Path.GetFileName(videoFN);
                        filename = filename.Replace(" ", "_");
                        string fullPath = Path.Combine(@"media\videos\", filename);
                        System.IO.File.Copy(videoFN, Path.Combine(location, filename), true);

                        linkpath =  fullPath;

                    }
                }
            }
            else
            {
                linkpath = ld.link;
            }
            });
            return linkpath;
        }
    }
    
}
