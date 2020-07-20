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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using winForms = System.Windows.Forms;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading;
using System.ComponentModel; //Background Worker
using MahApps.Metro.Controls;
using CefSharp;
using System.Xml;

namespace Fyp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow 
    {
        public TypeAssistant assistant;
        public TypeAssistant cssPropertyBoxTypeAssistant;

        public static bool fire = true;
        public static bool htmlfire = true;
        public static bool newProjectcheck = false;


        public String idname = "";

        public static String browserAddress = "";
        
        //for ctrl + v to execute only one time
        private bool isPressed = false;


        //Creating csstextBox Object
        csstextBoxClass ctb = new csstextBoxClass();
        fileSystem fs = new fileSystem();
        htmltextBoxClass htb = new htmltextBoxClass();
        DOMHierarchy DOMHierarchy = new DOMHierarchy();
        DragnDrop dnd = new DragnDrop();
        EditProperties ep = new EditProperties();
        cssPropertyBox cpb;

        public MainWindow()
        {
            InitializeComponent();

            newProjectcheck = false;


            //giving fs the mainwindow instance so it can use it to load any files
            fs.mw = this;
            //Initializing a CSS Property Box Class
            cpb = new cssPropertyBox(htmlTextBox, csstextBox, MainWindowBrowser);

            //CSS Property Box Combo Box Sub
            BorderType.SelectionChanged += new SelectionChangedEventHandler(cssPropertyBox_ComboBox_SelectionChanged);

            FloatProperty.SelectionChanged += new SelectionChangedEventHandler(cssPropertyBox_ComboBox_SelectionChanged);
            DisplayProperty.SelectionChanged += new SelectionChangedEventHandler(cssPropertyBox_ComboBox_SelectionChanged);

            FontFamily.SelectionChanged += new SelectionChangedEventHandler(cssPropertyBox_FontFamily_SelectionChanged);

            FontWeights.SelectionChanged += new SelectionChangedEventHandler(cssPropertyBox_ComboBox_SelectionChanged);

            FontStyle.SelectionChanged += new SelectionChangedEventHandler(cssPropertyBox_FontStyle_SelectionChanged);


            FontAlign.SelectionChanged += new SelectionChangedEventHandler(cssPropertyBox_ComboBox_SelectionChanged);
            FontDecoration.SelectionChanged += new SelectionChangedEventHandler(cssPropertyBox_ComboBox_SelectionChanged);

            BackgroundPosition.SelectionChanged += new SelectionChangedEventHandler(cssPropertyBox_ComboBox_SelectionChanged);
            BackgroundRepeat.SelectionChanged += new SelectionChangedEventHandler(cssPropertyBox_ComboBox_SelectionChanged);



            //CssPropertyBox
            ColumnXS.TextChanged += new TextChangedEventHandler(cssPropertyBox_TextChanged);
            ColumnSM.TextChanged += new TextChangedEventHandler(cssPropertyBox_TextChanged);
            ColumnMD.TextChanged += new TextChangedEventHandler(cssPropertyBox_TextChanged);
            ColumnLG.TextChanged += new TextChangedEventHandler(cssPropertyBox_TextChanged);

            WidthProperty.TextChanged += new TextChangedEventHandler(cssPropertyBox_TextChanged);
            HeightProperty.TextChanged += new TextChangedEventHandler(cssPropertyBox_TextChanged);

            TopPadding.TextChanged += new TextChangedEventHandler(cssPropertyBox_TextChanged);
            BottomPadding.TextChanged += new TextChangedEventHandler(cssPropertyBox_TextChanged);
            LeftPadding.TextChanged += new TextChangedEventHandler(cssPropertyBox_TextChanged);
            RightPadding.TextChanged += new TextChangedEventHandler(cssPropertyBox_TextChanged);

            TopMargin.TextChanged += new TextChangedEventHandler(cssPropertyBox_TextChanged);
            BottomMargin.TextChanged += new TextChangedEventHandler(cssPropertyBox_TextChanged);
            LeftMargin.TextChanged += new TextChangedEventHandler(cssPropertyBox_TextChanged);
            RightMargin.TextChanged += new TextChangedEventHandler(cssPropertyBox_TextChanged);


            BorderSize.TextChanged += new TextChangedEventHandler(cssPropertyBox_TextChanged);
            FontSize.TextChanged += new TextChangedEventHandler(cssPropertyBox_TextChanged);

            BackgroundUrl.TextChanged += new TextChangedEventHandler(cssPropertyBox_TextChanged);


            //Typing Assistant
            assistant = new TypeAssistant();
            assistant.Idled += assistant_Idled;
            cssPropertyBoxTypeAssistant = new TypeAssistant();
            cssPropertyBoxTypeAssistant.Idled += cssPropertyBoxTypeAssistant_Idled;

            //Setting up Main Window Here
            //Using local drag and drop files (html css js) on a web browser

            //Getting the local js drag and drop files
            //string dndFiles = System.Windows.Forms.Application.StartupPath + @"\\dnd\album.html";
            Console.WriteLine(MainWindowBrowser.Address.Trim());
            if (MainWindowBrowser.Address.Trim().Equals("www.google.com"))
            {
                browserAddress = System.Windows.Forms.Application.StartupPath + @"\\dnd\dandd.html";
            }

            //MainWindowBrowser.Address = browserAddress;

            CefSharpSettings.ConcurrentTaskExecution = true;
            
            //For async object registration (equivalent to the old RegisterAsyncJsObject)

            dnd.mw = this;
            dnd.setChange = true;
            MainWindowBrowser.JavascriptObjectRepository.ResolveObject += (sender, e) =>
            {
                var repo = e.ObjectRepository;
                if (e.ObjectName == "getHTMLfromjs")
                {
                    BindingOptions bindingOptions = null; //Binding options is an optional param, defaults to null
                    bindingOptions = BindingOptions.DefaultBinder; //Use the default binder to serialize values into complex objects, CamelCaseJavascriptNames = true is the default
                    repo.Register("getHTMLfromjs", dnd, isAsync: true, options: bindingOptions);
                }
                else if (e.ObjectName == "getClassfromjs")
                {
                    BindingOptions bindingOptions = null; //Binding options is an optional param, defaults to null
                    bindingOptions = BindingOptions.DefaultBinder; //Use the default binder to serialize values into complex objects, CamelCaseJavascriptNames = true is the default
                    repo.Register("getClassfromjs", dnd, isAsync: true, options: bindingOptions);
                }

            };
            MainWindowBrowser.JavascriptObjectRepository.ObjectBoundInJavascript += (sender, e) =>
            {
                var name = e.ObjectName;

                Console.WriteLine($"Object {e.ObjectName} was bound successfully.");
            };

            

            SaveProject.IsEnabled = false;
            csstextBoxLine.ReadOnly = true;

            //Wait for the page to finish loading (all resources will have been loaded, rendering is likely still happening)
            /*MainWindowBrowser.LoadingStateChanged += (sender, args) =>
            {
                //Wait for the Page to finish loading
                if (args.IsLoading == false)
                {
                    MainWindowBrowser.ShowDevTools();
                }
            };*/

            ////setting csstextbox properties
            //System.Drawing.Color backtempcolor = System.Drawing.Color.FromArgb(0x2c2c2c); //Change hex color to rgb
            //csstextBoxLine.BackColor = System.Drawing.Color.FromArgb(backtempcolor.R, backtempcolor.G, backtempcolor.B);
            //csstextBox.Font = new System.Drawing.Font("Consolas, 'Courier New', monospace", 10);
            //csstextBoxLine.Font = new System.Drawing.Font("Consolas, 'Courier New', monospace", 10);

            ////setting htmltextbox Properties
            //htmlTextBoxLine.BackColor = System.Drawing.Color.FromArgb(backtempcolor.R, backtempcolor.G, backtempcolor.B);
            //htmlTextBox.Font = new System.Drawing.Font("Consolas, 'Courier New', monospace", 10);
            //htmlTextBoxLine.Font = new System.Drawing.Font("Consolas, 'Courier New', monospace", 10);


        }

        //Css Property Box Methods
        /*private void cssPropertyBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var a = sender as System.Windows.Controls.TextBox;
            if (String.IsNullOrWhiteSpace(a.Text))
            {
                //wpf convert hex to brush color
                var bc = new BrushConverter();
                a.Foreground = (System.Windows.Media.Brush)bc.ConvertFrom("#3d4047");
                a.Text = "Enter text here...";
            }
                
        }

        private void cssPropertyBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var a = sender as System.Windows.Controls.TextBox;
            a.Foreground = System.Windows.Media.Brushes.White;
            a.Text = "";
        }*/

        public void cssPropertyBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            cssPropertyBoxTypeAssistant.boxName = ((System.Windows.Controls.TextBox)sender).Name;
            cssPropertyBoxTypeAssistant.boxValue = ((System.Windows.Controls.TextBox)sender).Text;

            cssPropertyBoxTypeAssistant.TextChanged();
            /*String textBoxName = ((System.Windows.Controls.TextBox)sender).Name;
            if (textBoxName.Equals("ColumnXS") || textBoxName.Equals("ColumnSM") || textBoxName.Equals("ColumnMD") || textBoxName.Equals("ColumnLG"))
            {
                winForms.MessageBox.Show("here");
            }*/
        }

        
        //CSS PropertyBox Combo Selection
        private void cssPropertyBox_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String propertyName = ((System.Windows.Controls.ComboBox)sender).Name;
            System.Windows.Controls.ComboBox cmb = sender as System.Windows.Controls.ComboBox;
            string propertyContent = ((ComboBoxItem)cmb.SelectedItem).Content as string;

            IFrame cssPropertyBoxFrame = MainWindowBrowser.GetMainFrame();
            cssPropertyBoxFrame.ExecuteJavaScriptAsync("getIDofSelectedElements()");

            System.Threading.Thread.Sleep(10);

            cpb.changeComboBox(propertyContent.ToLower(), propertyName, DragnDrop.idHolder);
        }

        private void cssPropertyBox_FontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String propertyName = "FontFamily";
            string propertyContent = FontFamily.SelectedItem.ToString();

            IFrame cssPropertyBoxFrame = MainWindowBrowser.GetMainFrame();
            cssPropertyBoxFrame.ExecuteJavaScriptAsync("getIDofSelectedElements()");

            System.Threading.Thread.Sleep(10);

            cpb.changeComboBox(propertyContent.ToLower(), propertyName, DragnDrop.idHolder);
        }

        /*private void cssPropertyBox_FontWeight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String propertyName = "FontWeight";
            string propertyContent = FontWeights.SelectedItem.Content.ToString();
            winForms.MessageBox.Show(propertyName + " has value " + propertyContent);

            IFrame cssPropertyBoxFrame = MainWindowBrowser.GetMainFrame();
            cssPropertyBoxFrame.ExecuteJavaScriptAsync("getIDofSelectedElements()");

            System.Threading.Thread.Sleep(10);

            cpb.changeComboBox(propertyContent.ToLower(), propertyName, DragnDrop.idHolder);
        }*/

        private void cssPropertyBox_FontStyle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String propertyName = "FontStyle";
            string propertyContent = FontStyle.SelectedItem.ToString();

            IFrame cssPropertyBoxFrame = MainWindowBrowser.GetMainFrame();
            cssPropertyBoxFrame.ExecuteJavaScriptAsync("getIDofSelectedElements()");

            System.Threading.Thread.Sleep(10);

            cpb.changeComboBox(propertyContent.ToLower(), propertyName, DragnDrop.idHolder);
        }

        public void cssPropertyBoxTypeAssistant_Idled(object sender, EventArgs e)
        {
            Action action = delegate {
                String textBoxName = cssPropertyBoxTypeAssistant.boxName;
                String textBoxValue = cssPropertyBoxTypeAssistant.boxValue;
                
                IFrame cssPropertyBoxFrame = MainWindowBrowser.GetMainFrame();
                cssPropertyBoxFrame.ExecuteJavaScriptAsync("getIDofSelectedElements()");

                System.Threading.Thread.Sleep(10);
                //Column Set;
                if ((textBoxName.Equals("ColumnXS") || textBoxName.Equals("ColumnSM") || textBoxName.Equals("ColumnMD") || textBoxName.Equals("ColumnLG")) && !textBoxValue.Trim().Equals(""))
                {
                    var isNumeric = int.TryParse(textBoxValue, out int n);
                    Console.WriteLine("is Numeric is " + isNumeric);

                    if (isNumeric)
                    {
                        cpb.setColumns(Int32.Parse(textBoxValue), textBoxName, DragnDrop.idHolder);
                    }
                    else
                    {
                        winForms.MessageBox.Show("Please enter an integer","Integer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                //Width and Height Set
                else if ((textBoxName.Equals("WidthProperty") || textBoxName.Equals("HeightProperty")) && !textBoxValue.Trim().Equals(""))
                {
                    var isNumeric = int.TryParse(textBoxValue, out int n);
                    Console.WriteLine("is Numeric is " + isNumeric);

                    if (isNumeric)
                    {
                        cpb.changeSize(Int32.Parse(textBoxValue), textBoxName, DragnDrop.idHolder);
                    }
                    else
                    {
                        winForms.MessageBox.Show("Please enter an integer", "Integer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                //Border Size
                else if ((textBoxName.Equals("BorderSize")) && !textBoxValue.Trim().Equals(""))
                {
                    var isNumeric = int.TryParse(textBoxValue, out int n);
                    Console.WriteLine("is Numeric is " + isNumeric);

                    if (isNumeric)
                    {
                        cpb.changeBorder(textBoxValue, textBoxName, DragnDrop.idHolder);
                    }
                    else
                    {
                        winForms.MessageBox.Show("Please enter an integer", "Integer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if ((textBoxName.Equals("FontSize")) && !textBoxValue.Trim().Equals(""))
                {
                    var isNumeric = int.TryParse(textBoxValue, out int n);
                    Console.WriteLine("is Numeric is " + isNumeric);

                    if (isNumeric)
                    {
                        cpb.changeFont(Int32.Parse(textBoxValue), textBoxName, DragnDrop.idHolder);
                    }
                    else
                    {
                        winForms.MessageBox.Show("Please enter an integer", "Integer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                //Padding Set
                else if((textBoxName.Equals("TopPadding") || textBoxName.Equals("BottomPadding") || textBoxName.Equals("LeftPadding") || textBoxName.Equals("RightPadding")) && !textBoxValue.Trim().Equals(""))
                {
                    var isNumeric = int.TryParse(textBoxValue, out int n);
                    Console.WriteLine("is Numeric is " + isNumeric);

                    if (isNumeric)
                    {
                        cpb.changePadding(Int32.Parse(textBoxValue), textBoxName, DragnDrop.idHolder);
                    }
                    else
                    {
                        winForms.MessageBox.Show("Please enter an integer", "Integer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                //Margin Set
                else if ((textBoxName.Equals("TopMargin") || textBoxName.Equals("BottomMargin") || textBoxName.Equals("LeftMargin") || textBoxName.Equals("RightMargin")) && !textBoxValue.Trim().Equals(""))
                {
                    var isNumeric = int.TryParse(textBoxValue, out int n);
                    Console.WriteLine("is Numeric is " + isNumeric);

                    if (isNumeric)
                    {
                        cpb.changeMargin(Int32.Parse(textBoxValue), textBoxName, DragnDrop.idHolder);
                    }
                    else
                    {
                        winForms.MessageBox.Show("Please enter an integer", "Integer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else if(textBoxName.Equals("BackgroundUrl") && !textBoxValue.Trim().Equals(""))
                {
                    textBoxValue = "url(\""+textBoxValue+"\")";
                    cpb.changeURL(textBoxValue, textBoxName, DragnDrop.idHolder);
                }

            };
            this.Invoke(action);
            
        }
        /*private void OnBrowserJavascriptMessageReceived(object sender, JavascriptMessageReceivedEventArgs e)
        {
            //Complext objects are initially expresses as IDicionary
            //You can use dynamic to access properties (the IDicionary is an ExpandoObject)
            //dynamic msg = e.Message;
            //Alternatively you can use the built in Model Binder to convert to a custom model
            var msg = e.ConvertMessageTo<String>();
            var callback = msg.k;

            //Call a javascript function with your response data
            callback.ExecuteAsync(type);
        }*/
        /*
                public void Testing()
                {
                    String htmlH = htmlTextBox.Text;
                    winForms.MessageBox.Show(htmlH);
                    //MainWindowBrowser.ExecuteScriptAsync(String.Format("testFunc('{0}');", htmlH));
                    IFrame frame = MainWindowBrowser.GetMainFrame();
                    frame.ExecuteJavaScriptAsync(String.Format("testFunc(`{0}`)", htmlH));
                }*/
        public void assistant_Idled(object sender, EventArgs e)
        {
            Action action = delegate {
                if (dnd.setChange)
                {
                    
                    Regex singlelinepattern = new Regex(@"\s*?(\r\n|\n|\r)\s*");
                    String htmlH = htmlTextBox.Text;
                    String singleLineString = singlelinepattern.Replace(htmlH, "");
                    //winForms.MessageBox.Show(singleLineString);
                    IFrame frame = MainWindowBrowser.GetMainFrame();
                    frame.ExecuteJavaScriptAsync(String.Format("testFunc(`{0}`)", htmlH));

                }
                else
                {
                    dnd.setChange = true;
                }
                
            };
            this.Invoke(action);

        }
        private void WindowKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (isPressed) {
                isPressed = false;
            }
        }
        private void WindowKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.S && Keyboard.Modifiers == ModifierKeys.Control)
            {
                int result = fs.SaveProject(htmlTextBox, csstextBox);
                if (result == 1 || result == 2)
                {
                    SaveProject.IsEnabled = false;
                }
            }
            else if (e.Key == Key.O && Keyboard.Modifiers == ModifierKeys.Control)
            {
                fs.OpenProject(htmlTextBox, csstextBox, SaveProject, MainWindowBrowser);
            }
            else if (e.Key == Key.N && Keyboard.Modifiers == ModifierKeys.Control)
            {
                fs.NewProject(htmlTextBox, csstextBox, SaveProject, this);
            }
            else if (e.Key == Key.F && Keyboard.Modifiers == ModifierKeys.Control)
            {
                FindAndReplaceDialog dialog = new FindAndReplaceDialog(htmlTextBox, csstextBox);
                dialog.ShowDialog();
            }
            else if (e.Key == Key.D && Keyboard.Modifiers == ModifierKeys.Control)
            {
                DOMHierarchy dOM = new DOMHierarchy();
                dOM.generate(htmlTextBox, DomHierarchyTree);
            }
            else if (e.Key == Key.C && Keyboard.Modifiers == ModifierKeys.Control)
            {
                IFrame copyFrame = MainWindowBrowser.GetMainFrame();
                copyFrame.ExecuteJavaScriptAsync("copyAllElements()");
            }
            else if (e.Key == Key.V && Keyboard.Modifiers == ModifierKeys.Control && !isPressed)
            {
                isPressed = true;
                if (EditProperties.copycheck)
                {
                    var clipboarddata = System.Windows.Clipboard.GetText();
                    IFrame frame = MainWindowBrowser.GetMainFrame();
                    frame.ExecuteJavaScriptAsync(String.Format("pasteAllElements(`{0}`)", clipboarddata));
                    EditProperties.copycheck = false;
                }
                else
                {
                    winForms.MessageBox.Show("Please select an element to paste", "Element Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (e.Key == Key.A && Keyboard.Modifiers == ModifierKeys.Control)
            {
                IFrame selectFrame = MainWindowBrowser.GetMainFrame();
                selectFrame.ExecuteJavaScriptAsync("selectAllElements()");
            }
            else if (e.Key == Key.Delete)
            {
                IFrame deleteFrame = MainWindowBrowser.GetMainFrame();
                deleteFrame.ExecuteJavaScriptAsync("deleteAllElements()");
            }
        }
            //FileSystem
        private void NewProject_Click(object sender, RoutedEventArgs e)
        {
            fs.NewProject(htmlTextBox, csstextBox, SaveProject, this);
        }

        public void OpenProject_Startup()
        {
            fs.OpenProject(htmlTextBox, csstextBox, SaveProject, MainWindowBrowser);
            //DOMHierarchy.generateDOM(DomHierarchyTree, htmlTextBox);
        }


        private void OpenProject_Click(object sender, RoutedEventArgs e)
        {
            fs.OpenProject(htmlTextBox, csstextBox, SaveProject, MainWindowBrowser);
            //DOMHierarchy.generateDOM(DomHierarchyTree, htmlTextBox);
        }

        private void SaveProject_Click(object sender, RoutedEventArgs e)
        {
            int result = fs.SaveProject(htmlTextBox, csstextBox);
            if (result == 1 || result == 2)
            {
                SaveProject.IsEnabled = false;
            }
            //SaveProject.IsEnabled = false;
            //DOMHierarchy.generateDOM(DomHierarchyTree, htmlTextBox);
        }

        private void ExitApplication_Click(object sender, RoutedEventArgs e)
        {
            fs.ExitApplication(htmlTextBox, csstextBox, SaveProject);
        }

        private void ChangeFontSize_Click(object sender, RoutedEventArgs e)
        {
            fs.ChangeFontSize(htmlTextBox, csstextBox, htmlTextBoxLine, csstextBoxLine);
        }

        private void Preview_Click(object sender, RoutedEventArgs e)
        {
            fs.Preview();
        }


        private void cssTextBox_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.OemOpenBrackets)// OemOpenBrackets { keyvalue
            {

                ctb.autoAddBrackets(csstextBox);
            }
            else if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                // create & set Point pt to (0,0)    
                System.Drawing.Point pt = new System.Drawing.Point(0, 0);
                // set X & Y coordinates of Point pt to ClientRectangle Width & Height respectively    
                int x = (int)RenderSize.Width;
                int y = (int)RenderSize.Height;
                ctb.AddLineNumbers(csstextBox, csstextBoxLine, pt, x, y);
            }
            else if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
            {
                //stop single line grammercheck firing
                fire = false;
                //Overriding Paste Functionality
                //Showing busy work with mouse
                Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
                try
                {
                    ctb.clipboardGrammerCheck(csstextBox);

                }
                finally
                {
                    Mouse.OverrideCursor = null;
                }
                fire = true;
                

            }

        }

        private void cssTextBox_TextChanged(object sender, EventArgs e)
        {
            SaveProject.IsEnabled = true;

            if (csstextBox.Text == "")
            {
                // create & set Point pt to (0,0)    
                System.Drawing.Point pt = new System.Drawing.Point(0, 0);
                // set X & Y coordinates of Point pt to ClientRectangle Width & Height respectively    
                int x = (int)RenderSize.Width;
                int y = (int)RenderSize.Height;
                ctb.AddLineNumbers(csstextBox, csstextBoxLine, pt, x, y);
            }

            //Manage line numbers of css editor
            ctb.LineNumbers(csstextBox);

            //Check Grammer of the css entered
            /*if (!worker.IsBusy)
            {
                worker.RunWorkerAsync();
                worker.DoWork += backgroundcheck;
                worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            }*/

            if (fire)
            {
                ctb.GrammerCheck(csstextBox);
            }

            //Updating the GUI Values
            //totalerrorslabel.Content = ctb.errors + " Errors Found";
            csslineslabel.Content = ctb.totallines + " Lines";


        }

        /*private void backgroundcheck(object sender, DoWorkEventArgs e)
        {
            // run all background tasks here
            Console.WriteLine("Work Started");
            Action action = () => ctb.GrammerCheck(csstextBox);
            csstextBox.Invoke(action); // Or use BeginInvoke
        }
        private void worker_RunWorkerCompleted(object sender,
                                           RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("Work comepleted");
            //update ui once worker complete his work
        }*/

        private void CsstextBoxLine_MouseDown(object sender, winForms.MouseEventArgs e)
        {
            csstextBox.Select();
            csstextBoxLine.DeselectAll();
        }

        private void CsstextBox_SelectionChanged(object sender, EventArgs e)
        {
            System.Drawing.Point pt = csstextBox.GetPositionFromCharIndex(csstextBox.SelectionStart);
            if (pt.X == 1)
            {
                // create & set Point pt to (0,0)    
                System.Drawing.Point newpt = new System.Drawing.Point(0, 0);
                // set X & Y coordinates of Point pt to ClientRectangle Width & Height respectively    
                int x = (int)RenderSize.Width;
                int y = (int)RenderSize.Height;
                ctb.AddLineNumbers(csstextBox, csstextBoxLine, newpt, x, y);
            }
        }

        private void CsstextBox_VScroll(object sender, EventArgs e)
        {
            csstextBoxLine.Text = "";


            // create & set Point pt to (0,0)    
            System.Drawing.Point pt = new System.Drawing.Point(0, 0);
            // set X & Y coordinates of Point pt to ClientRectangle Width & Height respectively    
            int x = (int)RenderSize.Width;
            int y = (int)RenderSize.Height;
            ctb.AddLineNumbers(csstextBox, csstextBoxLine, pt, x, y);
            csstextBoxLine.Invalidate();
        }

        private void CsstextBox_FontChanged(object sender, EventArgs e)
        {
            csstextBoxLine.Font = csstextBox.Font;
            csstextBox.Select();


            // create & set Point pt to (0,0)    
            System.Drawing.Point pt = new System.Drawing.Point(0, 0);
            // set X & Y coordinates of Point pt to ClientRectangle Width & Height respectively    
            int x = (int)RenderSize.Width;
            int y = (int)RenderSize.Height;
            ctb.AddLineNumbers(csstextBox, csstextBoxLine, pt, x, y);
        }

        /*public void AddLineNumbers()
        {
            // create & set Point pt to (0,0)    
            System.Drawing.Point pt = new System.Drawing.Point(0, 0);
            // get First Index & First Line from richTextBox1    
            int First_Index = csstextBox.GetCharIndexFromPosition(pt);
            int First_Line = csstextBox.GetLineFromCharIndex(First_Index);
            // set X & Y coordinates of Point pt to ClientRectangle Width & Height respectively    
            pt.X = (int)RenderSize.Width;
            pt.Y = (int)RenderSize.Height;

            // get Last Index & Last Line from richTextBox1    
            int Last_Index = csstextBox.GetCharIndexFromPosition(pt);
            int Last_Line = csstextBox.GetLineFromCharIndex(Last_Index);
            // set Center alignment to LineNumberTextBox    
            csstextBoxLine.SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            // set LineNumberTextBox text to null & width to getWidth() function value    
            csstextBoxLine.Text = "";
            csstextBoxLine.Width = getWidth();
            // now add each line number to LineNumberTextBox upto last line    
            for (int i = First_Line; i <= Last_Line; i++)
            {
                csstextBoxLine.Text += i + 1 + "\n";
            }
        }*/



        //HTML
        

        private void htmlTextBox_TextChanged(object sender, EventArgs e)
        {
            assistant.TextChanged();
            
            SaveProject.IsEnabled = true;

            if (htmlTextBox.Text == "")
            {
                // create & set Point pt to (0,0)    
                System.Drawing.Point pt = new System.Drawing.Point(0, 0);
                // set X & Y coordinates of Point pt to ClientRectangle Width & Height respectively    
                int x = (int)RenderSize.Width;
                int y = (int)RenderSize.Height;
                htb.AddLineNumbers(htmlTextBox, htmlTextBoxLine, pt, x, y);
            }

            htb.LineNumbers(htmlTextBox);
            htmllineslabel.Content = htb.totallines + " Lines";

            // for html tags validation
            //if (htmlfire)
            //{
            //    htb.currentValidateTags(htmlTextBox);
            //}
        }

        private void htmlTextBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            String ch = e.KeyChar.ToString();

            htb.ProcessAutoCompleteBrackets(ch, htmlTextBox);
            htb.AutoCompleteTags(ch, htmlTextBox);
        }

        private void htmlTextBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            
            htb.CheckAutoComplete(e, htmlTextBox);

        }
        private void htmlTextBox_KeyUp(object sender, winForms.KeyEventArgs e)
        {
            /*if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
            {
                //stop single line grammercheck firing
                htmlfire = false;
                //Overriding Paste Functionality
                //Showing busy work with mouse
                Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
                try
                {
                   htb.ValidateTags(htmlTextBox);

                }
                finally
                {
                    Mouse.OverrideCursor = null;
                }
                htmlfire = true;


            }*/
        }
        private void htmlTextBox_SelectionChanged(object sender, EventArgs e)
        {
            System.Drawing.Point pt = htmlTextBox.GetPositionFromCharIndex(htmlTextBox.SelectionStart);
            if (pt.X == 1)
            {
                // create & set Point pt to (0,0)    
                System.Drawing.Point newpt = new System.Drawing.Point(0, 0);
                // set X & Y coordinates of Point pt to ClientRectangle Width & Height respectively    
                int x = (int)RenderSize.Width;
                int y = (int)RenderSize.Height;
                htb.AddLineNumbers(htmlTextBox, htmlTextBoxLine, newpt, x, y);
            }
        }

        private void htmlTextBox_VScroll(object sender, EventArgs e)
        {
            htmlTextBoxLine.Text = "";
            // create & set Point pt to (0,0)    
            System.Drawing.Point pt = new System.Drawing.Point(0, 0);
            // set X & Y coordinates of Point pt to ClientRectangle Width & Height respectively    
            int x = (int)RenderSize.Width;
            int y = (int)RenderSize.Height;
            htb.AddLineNumbers(htmlTextBox, htmlTextBoxLine, pt, x, y);
            htmlTextBoxLine.Invalidate();
        }

        private void htmlTextBox_FontChanged(object sender, EventArgs e)
        {
            htmlTextBoxLine.Font = htmlTextBox.Font;
            htmlTextBox.Select();
            // create & set Point pt to (0,0)    
            System.Drawing.Point pt = new System.Drawing.Point(0, 0);
            // set X & Y coordinates of Point pt to ClientRectangle Width & Height respectively    
            int x = (int)RenderSize.Width;
            int y = (int)RenderSize.Height;
            htb.AddLineNumbers(htmlTextBox, htmlTextBoxLine, pt, x, y);
        }

        private void htmlTextBox_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            htmlTextBox.Select();
            htmlTextBoxLine.DeselectAll();
        }

        private void copy_Click(object sender, RoutedEventArgs e)
        {
            ep.CopyElement(MainWindowBrowser);
        }

        private void paste_Click(object sender, RoutedEventArgs e)
        {
            ep.PasteElement(MainWindowBrowser);
        }

        private void selectAll_Click(object sender, RoutedEventArgs e)
        {
            ep.SelectAllElements(MainWindowBrowser);
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            ep.DeleteElement(MainWindowBrowser);
        }

        private void findAndReplace_Click(object sender, RoutedEventArgs e)
        {
            FindAndReplaceDialog dialog = new FindAndReplaceDialog(htmlTextBox, csstextBox);
            dialog.Show();
        }

        private void mobileView_Click(object sender, RoutedEventArgs e)
        {
            IFrame mobileFrame = MainWindowBrowser.GetMainFrame();
            mobileFrame.ExecuteJavaScriptAsync("mobileview()");
        }

        private void tabletView_Click(object sender, RoutedEventArgs e)
        {
            IFrame mobileFrame = MainWindowBrowser.GetMainFrame();
            mobileFrame.ExecuteJavaScriptAsync("tabletview()");
        }

        private void laptopView_Click(object sender, RoutedEventArgs e)
        {
            IFrame mobileFrame = MainWindowBrowser.GetMainFrame();
            mobileFrame.ExecuteJavaScriptAsync("laptopview()");
        }

        private void customView_Click(object sender, RoutedEventArgs e)
        {
            CustomWindow customWindow = new CustomWindow("Enter Width");
            customWindow.mw = this;
            customWindow.ShowDialog();
        }

        private void manual_Click(object sender, RoutedEventArgs e)
        {
            fs.Manual();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DOMHierarchy dOMHierarchy = new DOMHierarchy();
            XmlDocument xmlDocument = new XmlDocument();
            string path = winForms.Application.StartupPath + @"\\DOM.html";
            string text = "<html></html>";
            File.WriteAllText(path, text);
            DomHierarchyTree.Nodes.Clear();
            xmlDocument.Load(path);
            dOMHierarchy.LoadTreeViewFromXmlDoc(xmlDocument, DomHierarchyTree);
        }

        private void DomHierarchyTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //winForms.MessageBox.Show("id="+ "\"" + DomHierarchyTree.SelectedNode.Name + "\"");
            string id = "id=" + "\"" + DomHierarchyTree.SelectedNode.Name + "\"";
            if (id != "")
            {
                DOMHierarchy.findAndHighlightTag(htmlTextBox, id);
            }



            //TreeNodeCollection nodetreeview = DomHierarchyTree.SelectedNode.Nodes;
            //Console.WriteLine(DomHierarchyTree.SelectedNode.Text +" "+ DomHierarchyTree.SelectedNode.Name);
            //foreach (TreeNode item in nodetreeview)
            //{
            //        Console.WriteLine(item +" " +item.Name +" "+ item.Tag);
            //}
            //Console.WriteLine();
        }

        private void DomHierarchyTree_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            htmlTextBox.SelectionStart = 0;
            htmlTextBox.SelectAll();
            htmlTextBox.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
        }

        private void BorderColor_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<System.Windows.Media.Color> e)
        {
            String colorValue = e.NewValue.ToString();
            String temp = colorValue.Substring(0, 1);
            String temp2 = colorValue.Substring(3);
            colorValue = temp + "" + temp2;

            IFrame cssPropertyBoxFrame = MainWindowBrowser.GetMainFrame();
            cssPropertyBoxFrame.ExecuteJavaScriptAsync("getIDofSelectedElements()");

            System.Threading.Thread.Sleep(10);

            cpb.changeColor(colorValue, "BorderColor", DragnDrop.idHolder);

        }
        private void FontColor_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<System.Windows.Media.Color> e)
        {
            String colorValue = e.NewValue.ToString();
            String temp = colorValue.Substring(0, 1);
            String temp2 = colorValue.Substring(3);
            colorValue = temp + "" + temp2;

            IFrame cssPropertyBoxFrame = MainWindowBrowser.GetMainFrame();
            cssPropertyBoxFrame.ExecuteJavaScriptAsync("getIDofSelectedElements()");

            System.Threading.Thread.Sleep(10);

            cpb.changeColor(colorValue, "FontColor", DragnDrop.idHolder);
        }
        private void BackgroundColor_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<System.Windows.Media.Color> e)
        {
            String colorValue = e.NewValue.ToString();
            String temp = colorValue.Substring(0, 1);
            String temp2 = colorValue.Substring(3);
            colorValue = temp + "" + temp2;

            IFrame cssPropertyBoxFrame = MainWindowBrowser.GetMainFrame();
            cssPropertyBoxFrame.ExecuteJavaScriptAsync("getIDofSelectedElements()");

            System.Threading.Thread.Sleep(10);

            cpb.changeColor(colorValue, "BackgroundColor", DragnDrop.idHolder);
        }
        private void demo_Click(object sender, RoutedEventArgs e)
        {
            VideoDemo demo = new VideoDemo();
            demo.Show();
        }

        private void generateDOM_Click(object sender, RoutedEventArgs e)
        {
            DOMHierarchy dOM = new DOMHierarchy();
            dOM.generate(htmlTextBox, DomHierarchyTree);
        }
        private void DomHierarchyTree_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            htmlTextBox.SelectionStart = 0;
            htmlTextBox.SelectAll();
            htmlTextBox.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (!newProjectcheck)
            {
                winForms.Application.ExitThread();
                Environment.Exit(0);
            }
            
        }
    }
}
