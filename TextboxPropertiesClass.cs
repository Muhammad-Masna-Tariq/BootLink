using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using winForms = System.Windows.Forms;

namespace Fyp
{
    
    class TextboxPropertiesClass
    {
        public int totallines { get; set; }
        public void LineNumbers(winForms.RichTextBox textbox)
        {
            this.totallines = textbox.Lines.Count();
        }
        public static int getWidth(winForms.RichTextBox richTextBox)
        {
            int w = 25;
            // get total lines of TextBox    
            int line = richTextBox.Lines.Length;

            if (line <= 99)
            {
                w = 20 + (int)richTextBox.Font.Size;
            }
            else if (line <= 999)
            {
                w = 30 + (int)richTextBox.Font.Size;
            }
            else
            {
                w = 50 + (int)richTextBox.Font.Size;
            }

            return w;
        }

        public void AddLineNumbers(winForms.RichTextBox textBox, winForms.RichTextBox textBoxLine, System.Drawing.Point pt, int x, int y)
        {
            // get First Index & First Line from richTextBox1    
            int First_Index = textBox.GetCharIndexFromPosition(pt);
            int First_Line = textBox.GetLineFromCharIndex(First_Index);
            // set X & Y coordinates of Point pt to ClientRectangle Width & Height respectively    
            pt.X = x;
            pt.Y = y;

            // get Last Index & Last Line from richTextBox1    
            int Last_Index = textBox.GetCharIndexFromPosition(pt);
            int Last_Line = textBox.GetLineFromCharIndex(Last_Index);
            // set Center alignment to LineNumberTextBox    
            textBoxLine.SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            // set LineNumberTextBox text to null & width to getWidth() function value    
            textBoxLine.Text = "";
            textBoxLine.Width = csstextBoxClass.getWidth(textBox);
            // now add each line number to LineNumberTextBox upto last line
            for (int i = First_Line; i <= Last_Line; i++)
            {
               textBoxLine.Text += i + 1 + "\n";
            }
        }
    }
}
