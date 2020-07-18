using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using winForms = System.Windows.Forms;
using CefSharp;

namespace Fyp
{
    class cssPropertyBox : Window
    {
        private winForms.RichTextBox htmltextBox;
        private winForms.RichTextBox cssTextBox;
        private CefSharp.Wpf.ChromiumWebBrowser mwb;
        public cssPropertyBox(winForms.RichTextBox htmltextBox, winForms.RichTextBox csstextBox, CefSharp.Wpf.ChromiumWebBrowser mainWB)
        {


            this.cssTextBox = csstextBox;
            this.htmltextBox = htmltextBox;
            this.mwb = mainWB;
        }

        public void setColumns(int columnValue, String columnType, String idname)
        {
            if (columnValue < 12 && columnValue >= 1)
            {
                if (columnType.Equals("ColumnXS"))
                {
                    updateHTMLclass(htmltextBox, idname, "col-xs", columnValue);
                }
                else if (columnType.Equals("ColumnSM"))
                {
                    updateHTMLclass(htmltextBox, idname, "col-sm", columnValue);
                }
                else if (columnType.Equals("ColumnMD"))
                {
                    updateHTMLclass(htmltextBox, idname, "col-md", columnValue);
                }
                else if (columnType.Equals("ColumnLG"))
                {
                    updateHTMLclass(htmltextBox, idname, "col-lg", columnValue);
                }
                else
                {
                    winForms.MessageBox.Show("There was an error in changing the column!");

                }
            }
            else
            {
                winForms.MessageBox.Show("Please enter a value between 1 and 12");
            }

        }
        
        //color
        public void changeColor(String colorValue, String colorType, String idname)
        {

            if (colorType.Equals("BorderColor"))
            {
                updateCSSstring(cssTextBox, idname, "border-color", colorValue);
            }
            else if (colorType.Equals("BackgroundColor"))
            {
                updateCSSstring(cssTextBox, idname, "background-color", colorValue);
            }
            else if (colorType.Equals("FontColor"))
            {
                updateCSSstring(cssTextBox, idname, "color", colorValue);
            }
            else
            {
                MessageBox.Show("There was an error changing the color");
            }
        }
        public void changeComboBox(String comboValue, String comboType, String idname)
        {

            if (comboType.Equals("FloatProperty"))
            {
                updateCSSstring(cssTextBox, idname, "float", comboValue);
            }
            else if (comboType.Equals("DisplayProperty"))
            {
                updateCSSstring(cssTextBox, idname, "display", comboValue);
            }
            else if (comboType.Equals("BackgroundPosition"))
            {
                updateCSSstring(cssTextBox, idname, "background-position", comboValue);
            }
            else if (comboType.Equals("BackgroundRepeat"))
            {
                updateCSSstring(cssTextBox, idname, "background-repeat", comboValue);
            }
            else if (comboType.Equals("FloatProperty"))
            {
                updateCSSstring(cssTextBox, idname, "float", comboValue);
            }
            else if (comboType.Equals("FontFamily"))
            {
                updateCSSstring(cssTextBox, idname, "font-family", comboValue);
            }
            else if (comboType.Equals("FontWeights"))
            {
                updateCSSstring(cssTextBox, idname, "font-weight", comboValue);
            }
            else if (comboType.Equals("FontStyle"))
            {
                updateCSSstring(cssTextBox, idname, "font-style", comboValue);
            }
            else if (comboType.Equals("FontAlign"))
            {
                updateCSSstring(cssTextBox, idname, "text-align", comboValue);
            }
            else if (comboType.Equals("BorderType"))
            {
                updateCSSstring(cssTextBox, idname, "border-style", comboValue);
            }
            else if (comboType.Equals("FontDecoration"))
            {
                updateCSSstring(cssTextBox, idname, "font-decoration", comboValue);
            }
            else
            {
                MessageBox.Show("There was an error changing the size");
            }
        }

        public void changeURL(String Value, String Type, String idname)
        {
            if (Type.Equals("BackgroundUrl"))
            {
                updateCSSstring(cssTextBox, idname, "background-image", Value);
            }
        }




        //Width and height
        public void changeSize(int sizeValue, String sizeTyoe, String idname)
        {

            if (sizeTyoe.Equals("WidthProperty"))
            {
                updateCSSnumber(cssTextBox, idname, "width", sizeValue);
            }
            else if (sizeTyoe.Equals("HeightProperty"))
            {
                updateCSSnumber(cssTextBox, idname, "height", sizeValue);
            }
            else
            {
                MessageBox.Show("There was an error changing the size");
            }
        }

        //Border
        public void changeFont(int fontValue, String fontType, String idname)
        {

            if (fontType.Equals("FontSize"))
            {
                updateCSSnumber(cssTextBox, idname, "font-size", fontValue);
            }
            else
            {
                MessageBox.Show("There was an error changing the size");
            }
        }


        //Border
        public void changeBorder(String borderValue, String borderType, String idname)
        {

            if (borderType.Equals("BorderSize"))
            {
                updateCSSnumber(cssTextBox, idname, "border-width", Int32.Parse(borderValue));
            }
            else
            {
                MessageBox.Show("There was an error changing the border");
            }
        }
        //paddingtype 1=top, 2=bottom, 3=left, 4=right
        public void changePadding(int paddingvalue, String paddingtype, String idname)
        {

            if (paddingtype.Equals("TopPadding"))
            {
                updateCSSnumber(cssTextBox, idname, "padding-top", paddingvalue);
            }
            else if (paddingtype.Equals("BottomPadding"))
            {
                updateCSSnumber(cssTextBox, idname, "padding-bottom", paddingvalue);
            }
            else if (paddingtype.Equals("LeftPadding"))
            {
                updateCSSnumber(cssTextBox, idname, "padding-left", paddingvalue);
            }
            else if (paddingtype.Equals("RightPadding"))
            {
                updateCSSnumber(cssTextBox, idname, "padding-right", paddingvalue);
            }
            else
            {
                MessageBox.Show("There was an error changing the padding");
            }
        }

        //Margin
        public void changeMargin(int marginvalue, String margintype, String idname)
        {

            if (margintype.Equals("TopMargin"))
            {
                updateCSSnumber(cssTextBox, idname, "margin-top", marginvalue);
            }
            else if (margintype.Equals("BottomMargin"))
            {
                updateCSSnumber(cssTextBox, idname, "margin-bottom", marginvalue);
            }
            else if (margintype.Equals("LeftMargin"))
            {
                updateCSSnumber(cssTextBox, idname, "margin-left", marginvalue);
            }
            else if (margintype.Equals("RightMargin"))
            {
                updateCSSnumber(cssTextBox, idname, "margin-right", marginvalue);
            }
            else
            {
                MessageBox.Show("There was an error changing the margin");
            }
        }

        public void updateHTMLclass(winForms.RichTextBox htmltextBox, String idname, String colType, int columnValue)
        {
            //check if element selected
            if (DragnDrop.idHolder.Equals("noidsfound"))
            {
                MessageBox.Show("Please select an element to change css!");
            }
            else
            {
                int length = htmltextBox.Text.Length;
                int index = 0;
                int found = -1;
                found = htmltextBox.Find(idname, index, length, winForms.RichTextBoxFinds.WholeWord);
                int startLine = htmltextBox.GetLineFromCharIndex(found);

                index = htmltextBox.Text.IndexOf(idname, index) + 1;


                if (found == -1)
                {
                    winForms.MessageBox.Show("Cannot find element in HTML!");
                }
                if (found != -1)
                {
                    // Now find if it has class
                    int foundClass = -1;
                    int lastIndexofLine = htmltextBox.GetFirstCharIndexFromLine(startLine) + htmltextBox.Lines[startLine].Length;

                    foundClass = htmltextBox.Find("class=", found, lastIndexofLine, winForms.RichTextBoxFinds.MatchCase);
                    if (foundClass == -1)
                    {
                        //class is not found so adding class
                        String lineText = htmltextBox.Lines[startLine];
                        int idFind = lineText.IndexOf(idname + "\"");
                        String start = lineText.Substring(0, idFind) + idname + "\" " + "class=\"" + colType + "-" + columnValue + "\"";


                        //+1 is here so that " can also be taken into consideration
                        String end = lineText.Substring(idFind + idname.Length + 1, lineText.Length - idFind - idname.Length - 1);
                        start = start + "" + end;
                        changeLine(htmltextBox, startLine, start);

                    }
                    else if (foundClass != -1)
                    {
                        int endLine = htmltextBox.GetLineFromCharIndex(foundClass);

                        //Finding is current style exists
                        String lineText = "";
                        bool classColumnFound = false;
                        lineText = htmltextBox.Lines[endLine];

                        if (lineText.Contains(colType))
                        {
                            classColumnFound = true;

                            /*int colFound = -1;
                            int lastIndexofClassLine = htmltextBox.GetFirstCharIndexFromLine(endLine) + htmltextBox.Lines[endLine].Length;

                            colFound = htmltextBox.Find(colType, foundClass, lastIndexofClassLine, winForms.RichTextBoxFinds.WholeWord);
                            *///replacing number in between

                            int colTypeLocation = lineText.IndexOf(colType);

                            String startMarker = lineText.Substring(0, colTypeLocation) + colType + "-" + columnValue;
                            String endMarker = lineText.Substring(colTypeLocation + colType.Length + 2, lineText.Length - colTypeLocation - colType.Length - 2);
                            startMarker += endMarker;

                            changeLine(htmltextBox, endLine, startMarker);
                        }

                        //if property not found then add a new line and add property
                        if (!classColumnFound)
                        {
                            int classLocation = lineText.IndexOf("class=\"");

                            String startMarker = lineText.Substring(0, classLocation) + "class=\"" + colType + "-" + columnValue + " ";

                            String endMarker = lineText.Substring(classLocation + "class=\"".Length, lineText.Length - classLocation - "class=\"".Length);

                            startMarker += endMarker;

                            changeLine(htmltextBox, endLine, startMarker);

                            //changeLine(cssTextBox, endLine - 1, cssTextBox.Lines[endLine - 1] + "\n\t" + propertyname + " " + propertyValue + ";");

                        }
                    }

                }
            }
            

        }

        private void updateCSSstring(winForms.RichTextBox cssTextBox, String idname, String propertyName, string propertyValue)
        {
            //check if element selected
            if (DragnDrop.idHolder.Equals("noidsfound"))
            {
                MessageBox.Show("Please select an element to change css!");
            }
            else
            {
                String Line = "";
                propertyName = propertyName + ":";
                int length = cssTextBox.Text.Length;
                int index = 0;
                int found = -1;
                found = cssTextBox.Find("#" + idname, index, length, winForms.RichTextBoxFinds.WholeWord);
                int startLine = cssTextBox.GetLineFromCharIndex(found);

                index = cssTextBox.Text.IndexOf("#" + idname, index) + 1;


                if (found == -1)
                {
                    cssTextBox.Text += "\n#" + idname + "{\n\t" + propertyName + " " + propertyValue + ";\n}";
                }
                if (found != -1)
                {
                    int endLine = cssTextBox.GetLineFromCharIndex(cssTextBox.Find("}", found, length, winForms.RichTextBoxFinds.MatchCase));

                    //Finding is current style exists
                    String lineText = "";
                    bool propertyFound = false;
                    for (int i = startLine; i < endLine; i++)
                    {

                        lineText = cssTextBox.Lines[i];

                        if (propertyName.Equals("color:") && (lineText.Contains("border-color") || lineText.Contains("background-color")))
                        {
                            continue;
                        }
                        else if (lineText.Contains(propertyName))
                        {
                            propertyFound = true;

                            //replacing number in between
                            String startMarker = propertyName;
                            String endMarker = ";";
                            /*Regex x = new Regex("("+startMarker+")(.*?)("+endMarker+")");
                            string repl = paddingvalue+"";
                            string Result = x.Replace(lineText, "$1" + repl + "$3");*/


                            int start = lineText.IndexOf(startMarker) + startMarker.Length;
                            int end = lineText.IndexOf(endMarker);
                            string result = lineText.Substring(start, end - start);
                            lineText = lineText.Replace(result, " " + propertyValue);

                            changeLine(cssTextBox, i, lineText);
                            break;
                        }
                    }

                    //if property not found then add a new line and add property
                    if (!propertyFound)
                    {
                        String propertyname = propertyName;
                        changeLine(cssTextBox, endLine - 1, cssTextBox.Lines[endLine - 1] + "\n\t" + propertyname + " " + propertyValue + ";");

                    }
                }
                Line = idname + " " + propertyName + " " + propertyValue;
                IFrame cssStringFrame = mwb.GetMainFrame();
                cssStringFrame.ExecuteJavaScriptAsync(String.Format("cssStringFunc(`{0}`)", Line));
            }
            

        }


        private void updateCSSnumber(winForms.RichTextBox cssTextBox, String idname, String propertyName, int propertyValue)
        {
            //check if element selected
            if (DragnDrop.idHolder.Equals("noidsfound"))
            {
                MessageBox.Show("Please select an element to change css!");
            }
            else
            {
                String Line = "";
                propertyName = propertyName + ":";
                int length = cssTextBox.Text.Length;
                int index = 0;
                int found = -1;
                found = cssTextBox.Find("#" + idname, index, length, winForms.RichTextBoxFinds.WholeWord);
                int startLine = cssTextBox.GetLineFromCharIndex(found);

                //index = cssTextBox.Text.IndexOf("#" + idname, index) + 1;


                if (found == -1)
                {
                    cssTextBox.Text += "\n#" + idname + "{\n\t" + propertyName + " " + propertyValue + "px;\n}";

                }
                if (found != -1)
                {

                    int endLine = cssTextBox.GetLineFromCharIndex(cssTextBox.Find("}", found, length, winForms.RichTextBoxFinds.MatchCase));

                    //Finding is current style exists
                    String lineText = "";
                    bool propertyFound = false;
                    for (int i = startLine; i < endLine; i++)
                    {
                        lineText = cssTextBox.Lines[i];

                        if (lineText.Contains(propertyName))
                        {

                            propertyFound = true;

                            //replacing number in between
                            String startMarker = propertyName;
                            String endMarker = "px";
                            /*Regex x = new Regex("("+startMarker+")(.*?)("+endMarker+")");
                            string repl = paddingvalue+"";
                            string Result = x.Replace(lineText, "$1" + repl + "$3");*/

                            //if we change color in propertybox and we already have border-color or background-color it changes them and not adds color so below if condition is required

                            int start = lineText.IndexOf(startMarker) + startMarker.Length;
                            int end = lineText.IndexOf(endMarker);
                            string result = lineText.Substring(start, end - start);
                            lineText = lineText.Replace(result, " " + propertyValue);

                            changeLine(cssTextBox, i, lineText);
                            break;
                        }
                    }

                    //if property not found then add a new line and add property
                    if (!propertyFound)
                    {
                        String propertyname = propertyName;
                        changeLine(cssTextBox, endLine - 1, cssTextBox.Lines[endLine - 1] + "\n\t" + propertyname + " " + propertyValue + "px;");
                    }

                }
                Line = idname + " " + propertyName + " " + propertyValue;
                IFrame cssStringFrame = mwb.GetMainFrame();
                cssStringFrame.ExecuteJavaScriptAsync(String.Format("cssNumFunc(`{0}`)", Line));
            }

        }
        private void changeLine(winForms.RichTextBox RTB, int line, string text)
        {
            int s1 = RTB.GetFirstCharIndexFromLine(line);
            int s2 = line < RTB.Lines.Count() - 1 ?
                      RTB.GetFirstCharIndexFromLine(line + 1) - 1 :
                      RTB.Text.Length;
            RTB.Select(s1, s2 - s1);
            RTB.SelectedText = text;
        }
    }
}
