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


namespace Fyp
{
    class csstextBoxClass : TextboxPropertiesClass
    {
        public int errors { get; set; }
        
        //Auto Add Brackets -- KeyUp Event
        public void autoAddBrackets(winForms.RichTextBox csstextBox)
        {
            csstextBox.SelectedText = "\n\t";
            int cursorpointer = csstextBox.SelectionStart;
            csstextBox.SelectedText = "\n}";
            csstextBox.SelectionColor = System.Drawing.Color.FromArgb(unchecked((int)0xB59D3E)); // selector color for }
            csstextBox.SelectionStart = cursorpointer;
        }


        //Checking whole grammer of css text box -- TextChanged Event
        public void GrammerCheck(winForms.RichTextBox csstextBox)
        {
            String fullproperty = "";
            this.errors = 0;
            bool erroradded = false;


            //Simple Regex ^((\.|\#)?([A-Za-z_-]+[a-z0-9_-]*)((\,)(\ )*(\.|\#)?([A-Za-z]+[A-Za-z0-9]*))*(\{))$                                                                                      \\.a, #abc, @cd{
            //Combinator Regex ^((\.|\#)?([A-Za-z_-]+[a-z0-9_-]*)((\ | \> | \+ | \~)*(\.|\#|\@)?([A-Za-z]+[A-Za-z0-9]*))*(\ )*(\{))$                                                                \\.a ~ #abc > cd  {
            //Psuedo Class Regex ^((\.|\#)?([A-Za-z_-]+[a-z0-9_-]*)(\:(hover|link|visited|active))?(\ )*(\{))$                                                                                      \\a:link {
            //Pseudo Element Regex ^((\.|\#)?([A-Za-z_-]+[a-z0-9_-]*)(\:\:(after|before|first\-letter|first\-line|marker|placeholder|selection))?(\ )*(\{))$                                       \\.a::placeholder {
            //Attribute Selector Regex ^(((\.|\#)?([A-Za-z_-]+[a-z0-9_-]*))((\ )*(\> | \+ | \~)?(\ )*(\.|\#)?([A-Za-z]+[A-Za-z0-9]*))*)?(\[([a-z]+(\~|\||\^|\$|\*)?\=\"\_?[a-z]+\"\])(\ )*(\{))$   \\\.abc > .cde[target^="_blank"] {


            Regex selectorPattern = new Regex(@"^((\ )*((\.|\#)?([A-Za-z_-]+[a-z0-9_-]*)((\,)(\ )*(\.|\#)?([A-Za-z_-]+[a-z0-9_-]*))*(\{))|((\.|\#)?([A-Za-z_-]+[a-z0-9_-]*)((\ | \> | \+ | \~)*(\.|\#)?([A-Za-z_-]+[a-z0-9_-]*))*(\ )*(\{))|((\.|\#)?([A-Za-z_-]+[a-z0-9_-]*)(\:(hover|link|visited|active))?(\ )*(\{))|((\.|\#)?([A-Za-z_-]+[a-z0-9_-]*)(\:\:(after|before|first\-letter|first\-line|marker|placeholder|selection))?(\ )*(\{))|(((\.|\#)?([A-Za-z_-]+[a-z0-9_-]*))((\ )*(\> | \+ | \~)?(\ )*(\.|\#)?([A-Za-z]+[A-Za-z0-9]*))*)?(\[([a-z]+(\~|\||\^|\$|\*)?\=""_?[a-z]+""\])(\ )*(\{)))$");


            //Simple key value property check for number, color rgb and rgba and simple text value background-color with three tier key font-variant-weight
            //^([a-z]*\-?[a-z]+(\-?[a-z]+)?(\ )*\:(\ )*(([a-z]+|(([0-9]+|\d+(\.\d+)?)(\ )?(px|pt|em|cm|\%|in|mm|in|rem))|(\#([A-Fa-f0-9]){3,6})|([a-z]+))|(rgb\((1?[0-9]{1,2}|2[0-4][0-9]|25[0-5])(\,(\ )?(1?[0-9]{1,2}|2[0-4][0-9]|25[0-5])){2}\))|(rgba\((1?[0-9]{1,2}|2[0-4][0-9]|25[0-5])(\,(\ )?(1?[0-9]{1,2}|2[0-4][0-9]|25[0-5])){2}\,(0(\.([0-9]+|\d+(\.\d+)?)(\ )?)?|1(\.0+)?)\))))?(\ )?\;)$
            //Box Model Properties Border Margin
            //^([a-z]*\-?[a-z]+(\-?[a-z]+)?(\ )*\:(\ )*(((([0-9]+|\d+(\.\d+)?)(\ )?(px|pt|em|cm|\%|in|mm|in|rem))(\ )?){1,4})?(\ )?\;)
            //Border
            //^([a-z]*\-?[a-z]+(\-?[a-z]+)?(\ )*\:(\ )*(((([0-9]+|\d+(\.\d+)?)(\ )?(px|pt|em|cm|\%|in|mm|in|rem))(\ )?){1,4})?((\ )(solid|dotted|dashed|doyble|groove|ridge|inset|outset|none|hidden))?((\ )((\#([A-Fa-f0-9]){3,6})|[a-z]+|(rgb\((1?[0-9]{1,2}|2[0-4][0-9]|25[0-5])(\,(\ )?(1?[0-9]{1,2}|2[0-4][0-9]|25[0-5])){2}\))|(rgba\((1?[0-9]{1,2}|2[0-4][0-9]|25[0-5])(\,(\ )?(1?[0-9]{1,2}|2[0-4][0-9]|25[0-5])){2}(\,(\ )?(0(\.([0-9]+|\d+(\.\d+)?)(\ )?)?|1(\.0+)?))\))))?(\ )?\;)$
            //URL Checker
            //^([a-z]*\-?[a-z]+(\-?[a-z]+)?(\ )*\:(\ )*(url\(\"((http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)?[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?)\"\))?(\ )?\;)
            //Font family
            //^((font-family)?(\ )*\:(\ )*((\"[A-Za-z\s]+\")((\,(\ )?[A-Za-z\s]*)*))(\ )?\;)
            Regex propertyPattern = new Regex(@"^(((\ )*([a-z]*\-?[a-z]+(\-?[a-z]+)?(\ )*\:(\ )*((([a-z]+(\-?[a-z]+)?|(([0-9]+|\d+(\.\d+)?)(\ )?(px|pt|em|cm|\%|in|mm|in|rem))|(\#([A-Fa-f0-9]){3,6})|([a-z]+))|(rgb\((1?[0-9]{1,2}|2[0-4][0-9]|25[0-5])(\,(\ )?(1?[0-9]{1,2}|2[0-4][0-9]|25[0-5])){2}\))|(rgba\((1?[0-9]{1,2}|2[0-4][0-9]|25[0-5])(\,(\ )?(1?[0-9]{1,2}|2[0-4][0-9]|25[0-5])){2}\,(0(\.([0-9]+|\d+(\.\d+)?)(\ )?)?|1(\.0+)?)\)))?|(((([0-9]+(px|pt|em|cm|\%|in|mm|in|rem))(\ )*){1,4})?)|((url\((\""|\')((http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)?[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?)(\""|\')\))?))(\ )?\;)|(((\ )*(font-family)?(\ )*\:(\ )*((\""[A-Za-z\s]+\"")((\,(\ )?[A-Za-z\s\-]*)*))(\ )?\;)))(\ )*(\})?)+$");
            Regex borderPattern = new Regex(@"^([a-z]*\-?[a-z]+(\-?[a-z]+)?(\ )*\:(\ )*(((([0-9]+|\d+(\.\d+)?)(\ )?(px|pt|em|cm|\%|in|mm|in|rem))(\ )?){1,4})?(\ )?\;)|([a-z]*\-?[a-z]+(\-?[a-z]+)?(\ )*\:(\ )*(((([0-9]+|\d+(\.\d+)?)(\ )?(px|pt|em|cm|\%|in|mm|in|rem))(\ )?){1,4})?((\ )(solid|dotted|dashed|doyble|groove|ridge|inset|outset|none|hidden))?((\ )((\#([A-Fa-f0-9]){3,6})|[a-z]+|(rgb\((1?[0-9]{1,2}|2[0-4][0-9]|25[0-5])(\,(\ )?(1?[0-9]{1,2}|2[0-4][0-9]|25[0-5])){2}\))|(rgba\((1?[0-9]{1,2}|2[0-4][0-9]|25[0-5])(\,(\ )?(1?[0-9]{1,2}|2[0-4][0-9]|25[0-5])){2}(\,(\ )?(0(\.([0-9]+|\d+(\.\d+)?)(\ )?)?|1(\.0+)?))\))))?(\ )?\;)$");
            Regex cssEndPattern = new Regex(@"^((\ )*\})$");
            bool inaSingleLine = false;

            int index = csstextBox.SelectionStart;
            int lineno = csstextBox.GetLineFromCharIndex(index);
            string line = "";
            try
            {
                line = csstextBox.Lines[lineno];
            }
            catch(System.IndexOutOfRangeException e)
            {
                line = "";
            }

            //Check Keywords
            //if line is empty
            string checkEmptyLine = line.Trim();
            if (string.IsNullOrEmpty(checkEmptyLine))
            {
                this.errors -= 1;
            }
            //checking for words after {
            string checkwords = "";
            int checklen = 0;

            //commenting
            if (line.Contains('{'))
            {
                checkwords = line;
                checklen = checkwords.Length;
                if (checkwords.Contains("//"))
                {
                    checkwords = checkwords.Substring(0, checkwords.IndexOf("//"));

                }
            }


            //if full css property is in single line with or without }
            if ((line.Contains("{") && line.Contains("}")) || (line.Contains("{") && line.Contains(":") && line.Contains(";")) || checkwords.IndexOf("{") < checklen - 1)
            {
                fullproperty = line;
                //checking if there is any comments with property like abc:abc;//here is selector
                if (fullproperty.Contains("//"))
                {
                    fullproperty = fullproperty.Substring(0, fullproperty.IndexOf("//"));

                }
                int sbIndex = fullproperty.IndexOf("{");
                int ebIndex = fullproperty.IndexOf("}");
                if (ebIndex > sbIndex)
                {
                    inaSingleLine = true;

                    //getting selector
                    int selectorcharLocation = fullproperty.IndexOf("{", StringComparison.Ordinal);
                    String selector = fullproperty.Substring(0, selectorcharLocation + 1);

                    if (selector.Length > 0)
                    {
                        Match selectorMatch = selectorPattern.Match(selector);
                        if (selectorMatch.Success)
                        {
                            //changing color of selector
                            int sIndex = csstextBox.Text.IndexOf(selector);
                            int sLength = selector.Length;


                            int cursorposition = csstextBox.SelectionStart;

                            csstextBox.Select(sIndex, sLength);
                            csstextBox.SelectionColor = System.Drawing.Color.FromArgb(unchecked((int)0xB59D3E)); //selector color


                            csstextBox.SelectionStart = cursorposition;
                        }
                        else
                        {
                            if (!erroradded)
                            {
                                this.errors += 1;
                                erroradded = true;
                            }

                            //change color to red
                            changeLine(csstextBox, lineno, 1);
                        }

                    }
                    else
                    {

                        if (!erroradded)
                        {
                            this.errors += 1;
                            erroradded = true;
                        }
                        //change color to red
                        changeLine(csstextBox, lineno, 1);
                    }


                    int propertycharLocation = 0;
                    //check if conatains }
                    bool bContains = false;
                    if (fullproperty.Contains("}"))
                    {
                        bContains = true;
                        propertycharLocation = fullproperty.IndexOf("}", StringComparison.Ordinal);

                    }
                    else
                    {
                        propertycharLocation = fullproperty.Length;
                    }
                    //getting properties
                    String properties = fullproperty.Substring(selectorcharLocation + 1, propertycharLocation - selectorcharLocation - 1);

                    if (properties.Length > 1)
                    {


                        Match propertyMatch = propertyPattern.Match(properties);
                        Match borderpropertyMatch = borderPattern.Match(properties);
                        if (propertyMatch.Success || borderpropertyMatch.Success)
                        {
                            //changing color of selector
                            int pIndex = csstextBox.Text.IndexOf(properties);
                            int pLength = properties.Length;

                            int cursorposition = csstextBox.SelectionStart;

                            csstextBox.Select(pIndex, pLength);
                            csstextBox.SelectionColor = System.Drawing.Color.FromArgb(unchecked((int)0x4F77B4)); //property color

                            if (bContains)
                            {
                                //changing color of last }
                                int bIndex = csstextBox.Text.IndexOf("}");

                                csstextBox.Select(bIndex, 1);
                                csstextBox.SelectionColor = System.Drawing.Color.FromArgb(unchecked((int)0xB59D3E)); //property color
                            }

                            csstextBox.SelectionStart = cursorposition;
                        }
                        else
                        {
                            if (!erroradded)
                            {
                                this.errors += 1;
                                erroradded = true;
                            }
                            //change color to red
                            changeLine(csstextBox, lineno, 1);
                        }
                    }
                    else if (fullproperty.Contains("}"))
                    {
                        //changing color of last }
                        int cursorposition = csstextBox.SelectionStart;
                        int bIndex = csstextBox.Text.IndexOf("}");

                        csstextBox.Select(bIndex, 1);
                        csstextBox.SelectionColor = System.Drawing.Color.FromArgb(unchecked((int)0xB59D3E)); //property color

                        csstextBox.SelectionStart = cursorposition;
                    }

                }
                else
                {
                    inaSingleLine = false;
                }

                //Commenting System
                if (line.Contains("//"))
                {

                    //Single Commenting
                    int charindex = line.IndexOf("//");
                    int commentIndex = csstextBox.GetFirstCharIndexFromLine(lineno) + charindex;
                    var length = line.Length;

                    int cursorposition = csstextBox.SelectionStart;
                    csstextBox.Select(commentIndex, length);
                    csstextBox.SelectionColor = System.Drawing.Color.FromArgb(unchecked((int)0xbdc3c7)); //grey color
                    csstextBox.SelectionStart = cursorposition;
                    csstextBox.DeselectAll();

                }
            }
            else
            {
                inaSingleLine = false;
            }

            fullproperty = "";
            if (!inaSingleLine)
            {
                //Checking if } exists seperately
                Match cssEndMatch = cssEndPattern.Match(line);
                if (cssEndMatch.Success)
                {
                    changeLine(csstextBox, lineno, 3);
                }


                if (line.Contains("{"))
                {
                    fullproperty = line;
                    /*//checking if there is any comments with selector like abc{//here is selector
                    if (line.Contains("//"))
                    {
                        fullproperty = line.Substring(0, line.IndexOf("{") + 1);

                    }*/

                    //property started static global var true for enter keyup

                    Match selectorMatch = selectorPattern.Match(fullproperty);
                    if (selectorMatch.Success)
                    {

                        //change color on success
                        changeLine(csstextBox, lineno, 2);


                    }
                    else
                    {
                        if (!erroradded)
                        {
                            this.errors += 1;
                            erroradded = true;
                        }
                        changeLine(csstextBox, lineno, 1);

                    }

                    /*//Selector Commenting
                    if (line.Contains("//"))
                    {
                        //Single Commenting
                        Console.WriteLine("Commenting initialized" + line);
                        int charindex = line.IndexOf("//");
                        int commentIndex = csstextBox.GetFirstCharIndexFromLine(lineno) + charindex;
                        var length = line.Length;

                        Console.WriteLine(commentIndex + "=============" + length);
                        int cursorposition = csstextBox.SelectionStart;
                        csstextBox.Select(commentIndex, length);
                        csstextBox.SelectionColor = System.Drawing.Color.FromArgb(unchecked((int)0xbdc3c7)); //grey color
                        csstextBox.SelectionStart = cursorposition;
                        csstextBox.DeselectAll();

                    }*/

                    fullproperty = "";

                }

                else if (line.Contains(":") || line.Contains(";") || (line.Contains(";") && line.Contains(":")))
                {
                    fullproperty = line;
                    fullproperty = fullproperty.Trim();
                    //checking if there is any comments with property like abc:abc;//here is selector
                    /*if (fullproperty.Contains("//"))
                    {
                        fullproperty = fullproperty.Substring(0, fullproperty.IndexOf("//"));

                    }*/
                    Match propertyMatch = propertyPattern.Match(fullproperty);
                    Match borderpropertyMatch = borderPattern.Match(fullproperty);
                    if (propertyMatch.Success || borderpropertyMatch.Success)
                    {
                        //change color on success
                        changeLine(csstextBox, lineno, 3);

                    }
                    else
                    {
                        if (!erroradded)
                        {
                            this.errors += 1;
                            erroradded = true;
                        }
                        changeLine(csstextBox, lineno, 1);

                    }

                    if (fullproperty.Contains("}"))
                    {
                        changeLine(csstextBox, lineno, 3);
                    }

                    //Property Commenting
                    /*if (line.Contains("//"))
                    {
                        //Single Commenting
                        Console.WriteLine("Commenting initialized" + line);
                        int charindex = line.IndexOf("//");
                        int commentIndex = csstextBox.GetFirstCharIndexFromLine(lineno) + charindex;
                        var length = line.Length;

                        Console.WriteLine(commentIndex + "=============" + length);
                        int cursorposition = csstextBox.SelectionStart;
                        csstextBox.Select(commentIndex, length);
                        csstextBox.SelectionColor = System.Drawing.Color.FromArgb(unchecked((int)0xbdc3c7)); //grey color
                        csstextBox.SelectionStart = cursorposition;
                        csstextBox.DeselectAll();

                    }*/

                    fullproperty = "";
                }
                else if (line.Contains("}") && !line.Contains(";") && !line.Contains(":"))
                {
                    changeLine(csstextBox, lineno, 2);

                }

            }

            //checking if line doesnot contain basic css indicators such as { : ; }
            if (!line.Contains("{") && !line.Contains(":") && !line.Contains(";") && !line.Contains("}"))
            {
                if (!erroradded)
                {
                    this.errors += 1;
                    erroradded = true;
                }
                changeLine(csstextBox, lineno, 1);
            }

            erroradded = false;
            csstextBox.DeselectAll();
        }

        //Checking grammer of clipboard css
        public void clipboardGrammerCheck(winForms.RichTextBox csstextBox)
        {
            String fullproperty = "";
            bool cssstart = false;
            bool propertyends = false;
            var csslines = csstextBox.Text.Split('\n').ToList();


            //Simple Regex ^((\.|\#)?([A-Za-z_-]+[a-z0-9_-]*)((\,)(\ )*(\.|\#)?([A-Za-z]+[A-Za-z0-9]*))*(\{))$                                                                                      \\.a, #abc, @cd{
            //Combinator Regex ^((\.|\#)?([A-Za-z_-]+[a-z0-9_-]*)((\ | \> | \+ | \~)*(\.|\#|\@)?([A-Za-z]+[A-Za-z0-9]*))*(\ )*(\{))$                                                                \\.a ~ #abc > cd  {
            //Psuedo Class Regex ^((\.|\#)?([A-Za-z_-]+[a-z0-9_-]*)(\:(hover|link|visited|active))?(\ )*(\{))$                                                                                      \\a:link {
            //Pseudo Element Regex ^((\.|\#)?([A-Za-z_-]+[a-z0-9_-]*)(\:\:(after|before|first\-letter|first\-line|marker|placeholder|selection))?(\ )*(\{))$                                       \\.a::placeholder {
            //Attribute Selector Regex ^(((\.|\#)?([A-Za-z_-]+[a-z0-9_-]*))((\ )*(\> | \+ | \~)?(\ )*(\.|\#)?([A-Za-z]+[A-Za-z0-9]*))*)?(\[([a-z]+(\~|\||\^|\$|\*)?\=\"\_?[a-z]+\"\])(\ )*(\{))$   \\\.abc > .cde[target^="_blank"] {


            Regex selectorPattern = new Regex(@"^((\ )*((\.|\#)?([A-Za-z_-]+[a-z0-9_-]*)((\,)(\ )*(\.|\#)?([A-Za-z_-]+[a-z0-9_-]*))*(\{))|((\.|\#)?([A-Za-z_-]+[a-z0-9_-]*)((\ | \> | \+ | \~)*(\.|\#)?([A-Za-z_-]+[a-z0-9_-]*))*(\ )*(\{))|((\.|\#)?([A-Za-z_-]+[a-z0-9_-]*)(\:(hover|link|visited|active))?(\ )*(\{))|((\.|\#)?([A-Za-z_-]+[a-z0-9_-]*)(\:\:(after|before|first\-letter|first\-line|marker|placeholder|selection))?(\ )*(\{))|(((\.|\#)?([A-Za-z_-]+[a-z0-9_-]*))((\ )*(\> | \+ | \~)?(\ )*(\.|\#)?([A-Za-z]+[A-Za-z0-9]*))*)?(\[([a-z]+(\~|\||\^|\$|\*)?\=""_?[a-z]+""\])(\ )*(\{)))$");


            //Simple key value property check for number, color rgb and rgba and simple text value background-color with three tier key font-variant-weight
            //^([a-z]*\-?[a-z]+(\-?[a-z]+)?(\ )*\:(\ )*(([a-z]+|(([0-9]+|\d+(\.\d+)?)(\ )?(px|pt|em|cm|\%|in|mm|in|rem))|(\#([A-Fa-f0-9]){3,6})|([a-z]+))|(rgb\((1?[0-9]{1,2}|2[0-4][0-9]|25[0-5])(\,(\ )?(1?[0-9]{1,2}|2[0-4][0-9]|25[0-5])){2}\))|(rgba\((1?[0-9]{1,2}|2[0-4][0-9]|25[0-5])(\,(\ )?(1?[0-9]{1,2}|2[0-4][0-9]|25[0-5])){2}\,(0(\.([0-9]+|\d+(\.\d+)?)(\ )?)?|1(\.0+)?)\))))?(\ )?\;)$
            //Box Model Properties Border Margin
            //^([a-z]*\-?[a-z]+(\-?[a-z]+)?(\ )*\:(\ )*(((([0-9]+|\d+(\.\d+)?)(\ )?(px|pt|em|cm|\%|in|mm|in|rem))(\ )?){1,4})?(\ )?\;)
            //Border
            //^([a-z]*\-?[a-z]+(\-?[a-z]+)?(\ )*\:(\ )*(((([0-9]+|\d+(\.\d+)?)(\ )?(px|pt|em|cm|\%|in|mm|in|rem))(\ )?){1,4})?((\ )(solid|dotted|dashed|doyble|groove|ridge|inset|outset|none|hidden))?((\ )((\#([A-Fa-f0-9]){3,6})|[a-z]+|(rgb\((1?[0-9]{1,2}|2[0-4][0-9]|25[0-5])(\,(\ )?(1?[0-9]{1,2}|2[0-4][0-9]|25[0-5])){2}\))|(rgba\((1?[0-9]{1,2}|2[0-4][0-9]|25[0-5])(\,(\ )?(1?[0-9]{1,2}|2[0-4][0-9]|25[0-5])){2}(\,(\ )?(0(\.([0-9]+|\d+(\.\d+)?)(\ )?)?|1(\.0+)?))\))))?(\ )?\;)$
            //URL Checker
            //^([a-z]*\-?[a-z]+(\-?[a-z]+)?(\ )*\:(\ )*(url\(\"((http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)?[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?)\"\))?(\ )?\;)
            //Font family
            //^((font-family)?(\ )*\:(\ )*((\"[A-Za-z\s]+\")((\,(\ )?[A-Za-z\s]*)*))(\ )?\;)
            Regex propertyPattern = new Regex(@"^(((\ )*([a-z]*\-?[a-z]+(\-?[a-z]+)?(\ )*\:(\ )*((([a-z]+|(([0-9]+|\d+(\.\d+)?)(\ )?(px|pt|em|cm|\%|in|mm|in|rem)?)|(\#([A-Fa-f0-9]){3,6})|([a-z]+))|(rgb\((1?[0-9]{1,2}|2[0-4][0-9]|25[0-5])(\,(\ )?(1?[0-9]{1,2}|2[0-4][0-9]|25[0-5])){2}\))|(rgba\((1?[0-9]{1,2}|2[0-4][0-9]|25[0-5])(\,(\ )?(1?[0-9]{1,2}|2[0-4][0-9]|25[0-5])){2}\,(0(\.([0-9]+|\d+(\.\d+)?)(\ )?)?|1(\.0+)?)\)))?|(((([0-9]+(px|pt|em|cm|\%|in|mm|in|rem)?)(\ )*){1,4})?)|((url\((\""|\')((http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)?[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?)(\""|\')\))?))(\ )?\;)|(((\ )*(font-family)?(\ )*\:(\ )*((\""[A-Za-z\s]+\"")((\,(\ )?[A-Za-z\s\-]*)*))(\ )?\;)))(\ )*(\})?)+$");
            Regex borderPattern = new Regex(@"^([a-z]*\-?[a-z]+(\-?[a-z]+)?(\ )*\:(\ )*(((([0-9]+|\d+(\.\d+)?)(\ )?(px|pt|em|cm|\%|in|mm|in|rem))(\ )?){1,4})?(\ )?\;)|([a-z]*\-?[a-z]+(\-?[a-z]+)?(\ )*\:(\ )*(((([0-9]+|\d+(\.\d+)?)(\ )?(px|pt|em|cm|\%|in|mm|in|rem))(\ )?){1,4})?((\ )(solid|dotted|dashed|doyble|groove|ridge|inset|outset|none|hidden))?((\ )((\#([A-Fa-f0-9]){3,6})|[a-z]+|(rgb\((1?[0-9]{1,2}|2[0-4][0-9]|25[0-5])(\,(\ )?(1?[0-9]{1,2}|2[0-4][0-9]|25[0-5])){2}\))|(rgba\((1?[0-9]{1,2}|2[0-4][0-9]|25[0-5])(\,(\ )?(1?[0-9]{1,2}|2[0-4][0-9]|25[0-5])){2}(\,(\ )?(0(\.([0-9]+|\d+(\.\d+)?)(\ )?)?|1(\.0+)?))\))))?(\ )?\;)$");
            Regex cssEndPattern = new Regex(@"^((\ )*\})$");
            int lineno = 0;
            bool inaSingleLine = false;
            foreach (var line in csslines)
            {

                //Commenting ??????
                /*if (line.Contains("//"))
                {
                    string commentedline = csstextBox.Text.IndexOf("//");
                    int cursorposition = csstextBox.SelectionStart;
                    csstextBox.Select();
                    csstextBox.SelectionColor = System.Drawing.Color.FromArgb(unchecked((int)0x4F77B4));
                    csstextBox.SelectionStart = cursorposition;
                }*/
                //Check Keywords


                //if full css property is in single line with or without }
                if ((line.Contains("{") && line.Contains("}")) || (line.Contains("{") && line.Contains(":") && line.Contains(";")))
                {
                    int sbIndex = line.IndexOf("{");
                    int ebIndex = line.IndexOf("}");
                    if (ebIndex > sbIndex)
                    {
                        inaSingleLine = true;

                        //getting selector
                        int selectorcharLocation = line.IndexOf("{", StringComparison.Ordinal);
                        String selector = line.Substring(0, selectorcharLocation + 1);

                        if (selector.Length > 0)
                        {
                            Match selectorMatch = selectorPattern.Match(selector);
                            if (selectorMatch.Success)
                            {
                                //changing color of selector
                                int sIndex = csstextBox.Text.IndexOf(selector);
                                int sLength = selector.Length;


                                int cursorposition = csstextBox.SelectionStart;

                                csstextBox.Select(sIndex, sLength);
                                csstextBox.SelectionColor = System.Drawing.Color.FromArgb(unchecked((int)0xB59D3E)); //selector color


                                csstextBox.SelectionStart = cursorposition;
                            }
                            else
                            {
                                //change color to red
                                changeLine(csstextBox, lineno, 1);
                            }

                        }
                        else
                        {
                            //change color to red
                            changeLine(csstextBox, lineno, 1);
                        }


                        int propertycharLocation = 0;
                        //check if conatains }
                        bool bContains = false;
                        if (line.Contains("}"))
                        {
                            bContains = true;
                            propertycharLocation = line.IndexOf("}", StringComparison.Ordinal);

                        }
                        else
                        {
                            propertycharLocation = line.Length;
                        }
                        //getting properties
                        String properties = line.Substring(selectorcharLocation + 1, propertycharLocation - selectorcharLocation - 1);

                        if (properties.Length > 1)
                        {


                            Match propertyMatch = propertyPattern.Match(properties);
                            Match borderpropertyMatch = borderPattern.Match(properties);
                            if (propertyMatch.Success || borderpropertyMatch.Success)
                            {
                                //changing color of selector
                                int pIndex = csstextBox.Text.IndexOf(properties);
                                int pLength = properties.Length;

                                int cursorposition = csstextBox.SelectionStart;

                                csstextBox.Select(pIndex, pLength);
                                csstextBox.SelectionColor = System.Drawing.Color.FromArgb(unchecked((int)0x4F77B4)); //property color

                                if (bContains)
                                {
                                    //changing color of last }
                                    int bIndex = csstextBox.Text.IndexOf("}");

                                    csstextBox.Select(bIndex, 1);
                                    csstextBox.SelectionColor = System.Drawing.Color.FromArgb(unchecked((int)0xB59D3E)); //property color
                                }

                                csstextBox.SelectionStart = cursorposition;
                            }
                            else
                            {
                                //change color to red
                                changeLine(csstextBox, lineno, 1);
                            }
                        }
                        else if (line.Contains("}"))
                        {
                            //changing color of last }
                            int cursorposition = csstextBox.SelectionStart;
                            int bIndex = csstextBox.Text.IndexOf("}");

                            csstextBox.Select(bIndex, 1);
                            csstextBox.SelectionColor = System.Drawing.Color.FromArgb(unchecked((int)0xB59D3E)); //property color

                            csstextBox.SelectionStart = cursorposition;
                        }
                    }
                    else
                    {
                        inaSingleLine = false;
                    }
                }
                else
                {
                    inaSingleLine = false;
                }


                if (!inaSingleLine)
                {

                    //Checking if } exists seperately
                    Match cssEndMatch = cssEndPattern.Match(line);
                    if (cssEndMatch.Success)
                    {
                        propertyends = true;
                        cssstart = true;
                        changeLine(csstextBox, lineno, 3);
                    }

                    //Checking if not ended selector with } and started another theory
                    if (line.Contains("{") && cssstart)
                    {
                        changeLine(csstextBox, lineno, 1);
                    }

                    if (line.Contains("{") && !(fullproperty.Contains("{") && !cssstart))
                    {
                        fullproperty += line;
                        cssstart = true;
                        propertyends = false;

                        //property started static global var true for enter keyup

                        Match selectorMatch = selectorPattern.Match(fullproperty);
                        if (selectorMatch.Success)
                        {

                            //change color on success
                            changeLine(csstextBox, lineno, 2);


                        }
                        else
                        {
                            changeLine(csstextBox, lineno, 1);

                        }
                        fullproperty = "";

                    }

                    else if (cssstart && !propertyends)
                    {
                        fullproperty += line;
                        fullproperty = fullproperty.Trim();
                        Match propertyMatch = propertyPattern.Match(fullproperty);
                        Match borderpropertyMatch = borderPattern.Match(fullproperty);
                        if (propertyMatch.Success || borderpropertyMatch.Success)
                        {
                            //change color on success
                            changeLine(csstextBox, lineno, 3);

                        }
                        else
                        {
                            changeLine(csstextBox, lineno, 1);

                        }

                        if (fullproperty.Contains("}"))
                        {
                            propertyends = true;
                            cssstart = false;
                            changeLine(csstextBox, lineno, 3);
                        }
                        fullproperty = "";
                    }
                    else if (!propertyends)
                    {
                        propertyends = true;
                        changeLine(csstextBox, lineno, 1);

                    }
                }
                lineno += 1;
                csstextBox.DeselectAll();
            }
        }

        //Inner Method of GrammerCheck for Color Management -- TextChanged Inner Event
        public void changeLine(winForms.RichTextBox csstextBox, int line, int color)
        {
            int cursorposition = csstextBox.SelectionStart;
            int s1 = csstextBox.GetFirstCharIndexFromLine(line);
            int s2 = line < csstextBox.Lines.Count() - 1 ?
                      csstextBox.GetFirstCharIndexFromLine(line + 1) - 1 :
                      csstextBox.Text.Length;
            csstextBox.Select(s1, s2 - s1);
            if (color == 1) // Fail Red
            {
                csstextBox.SelectionColor = System.Drawing.Color.Red;
            }
            else if (color == 2) // selector color
            {
                csstextBox.SelectionColor = System.Drawing.Color.FromArgb(unchecked((int)0xB59D3E));

            }
            else if (color == 3) // property color
            {
                csstextBox.SelectionColor = System.Drawing.Color.FromArgb(unchecked((int)0x4F77B4));

            }
            csstextBox.SelectionStart = cursorposition;
        }

    }
}
