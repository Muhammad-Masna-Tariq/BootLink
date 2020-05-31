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
namespace Fyp
{
    class htmltextBoxClass : TextboxPropertiesClass
    {
        private static string EnteredString = "";
        private static Boolean is_LessThanKeyPressed = false;
        private static Boolean is_GreaterThanKeyPressed = false;
        private static Boolean is_AutoCompleteCharacterPressed = false;
        private Boolean is_SpaceBarKeyPressed = false;
        private Boolean is_TagClosedKeyPressed = false;

        //private static string TagsPattern = "^<[a-z|A-Z|0-9]*>|</[a-z|A-Z|0-9]*>|<img|/>|<[a-z|A-Z|0-9]*>|<a|<form|<table|>|<!DOCTYPE html>|<input|<link|<h[1-6]|<div|<p|<meta|<script$";
        private static string TagsPattern = "^<[a-z|A-Z|0-9]*>|</[a-z|A-Z|0-9]*>|<img|/>|<[a-z|A-Z|0-9]*>|<a|<sub|<sup|<style|<pre|<form|<table|<tr|<td|<th|<head|<body|<b|<u|<i|<title|<ul|<li|<hr|>|<!DOCTYPE html>|<input|<link|<h[1-6]|<div|<p|<meta|<script|<br|/>$";
        private static string AttributePattern = "[A-Z|a-z]*=|[A-Z|a-z]*-[A-Z|a-z]*=|[A-Z|a-z]* =|[A-Z|a-z]*-[A-Z|a-z]* =";
        private static string InvertedCommasDetection = "\"\"|\"[a-z|A-z|0-9|.|-]*\"";
        private static string ValidPattern = "^((((<[A-Za-z]+[0-9]?)(( )?(([A-Za-z])*( )*=( )*(\"(.)*\"))(( )+(([A-Za-z])*( )*=( )*(\"(.)*\")))*)*(>| />))*)(([^<>/])*)((((<[A-Za-z]+[0-9]?)(( )?(([A-Za-z])*( )*=( )*(\"(.)*\"))(( )+(([A-Za-z])*( )*=( )*(\"(.)*\")))*)*(>| />))*)(([^<>/])*)(( )*(</)([A-Za-z]+[0-9]?)*(>))*)*(( )*(</)([A-Za-z]+[0-9]?)*(>))*)$";

        private string[] tagslist =
        {
            "html",
            "head",
            "title",
            "body",
            "h1",
            "h2",
            "h3",
            "h4",
            "h5",
            "h6",
            "b",
            "u",
            "i",
            "sub",
            "sup",
            "p",
            "style",
            "pre",
            "a",
            "img",
            "table",
            "tr",
            "th",
            "td",
            "form",
            "input",
            "div",
        };

        public void InvertedCommasColorPattern(string pattern, winForms.RichTextBox htmlTextBox)
        {
            int selectionStart = htmlTextBox.SelectionStart;
            foreach (Match match in Regex.Matches(htmlTextBox.Text, pattern))
            {
                htmlTextBox.Select(match.Index, match.Length);
                htmlTextBox.SelectionColor = System.Drawing.Color.DarkMagenta;
                htmlTextBox.Select(selectionStart, 0);
                htmlTextBox.SelectionColor = htmlTextBox.ForeColor;
            }
        }

        public void AttributeKeyColorPattern(string pattern, winForms.RichTextBox htmlTextBox)
        {
            int selectionStart = htmlTextBox.SelectionStart;
            foreach (Match match in Regex.Matches(htmlTextBox.Text, pattern))
            {
                htmlTextBox.Select(match.Index, match.Length);
                htmlTextBox.SelectionColor = System.Drawing.Color.DarkGreen;
                htmlTextBox.Select(selectionStart, 0);
                htmlTextBox.SelectionColor = htmlTextBox.ForeColor;
            }
        }

        public void TagsColorPattern(string pattern, winForms.RichTextBox htmlTextBox)
        {
            int selectionStart = htmlTextBox.SelectionStart;
            foreach (Match match in Regex.Matches(htmlTextBox.Text, pattern))
            {
                htmlTextBox.Select(match.Index, match.Length);
                htmlTextBox.SelectionColor = System.Drawing.Color.DarkBlue;
                htmlTextBox.Select(selectionStart, 0);
                htmlTextBox.SelectionColor = htmlTextBox.ForeColor;
            }
        }

        public void ValidateTags(winForms.RichTextBox htmlTextBox)
        {
            /*winForms.MessageBox.Show("came here validete");
            var lines = htmlTextBox.Text.Split('\n').ToList();
            int selectionStart = htmlTextBox.SelectionStart;

            int checkline = 0;
            foreach (var line in lines)
            {
                Match match = Regex.Match(line, ValidPattern);
                if (!match.Success)
                {
                    int firstCharIndex = htmlTextBox.GetFirstCharIndexOfCurrentLine();
                    int currentLine = htmlTextBox.GetLineFromCharIndex(firstCharIndex);
                    string currentLineText = htmlTextBox.Lines[checkline];
                    htmlTextBox.Select(firstCharIndex, currentLineText.Length);
                    htmlTextBox.SelectionColor = System.Drawing.Color.Red;
                    htmlTextBox.Select(selectionStart, 0);
                    htmlTextBox.SelectionColor = htmlTextBox.ForeColor;
                    checkline++;
                    
                }
            }*/
            TagsColorPattern(TagsPattern, htmlTextBox);
            AttributeKeyColorPattern(AttributePattern, htmlTextBox);
            InvertedCommasColorPattern(InvertedCommasDetection, htmlTextBox);
        }

        public void currentValidateTags(winForms.RichTextBox htmlTextBox)
        {
            int selectionStart = htmlTextBox.SelectionStart;
            int lineno = htmlTextBox.GetLineFromCharIndex(selectionStart);
            string line;
            try
            {
                line = htmlTextBox.Lines[lineno];
            }
            catch (System.IndexOutOfRangeException e)
            {
                line = "";

            }
            Match match = Regex.Match(line, ValidPattern);
            if (match.Success)
            {
                string checkedline = line;


                List<string> abc = new List<string>();
                Regex acc = new Regex(@"\<[^>]+\>");
                int i = 0;
                foreach (Match tagmatch in Regex.Matches(checkedline, acc.ToString()))
                {
                    if(!(tagmatch.Groups[0].ToString().Contains("->") || tagmatch.Groups[0].ToString().Contains("<!-")))
                    {
                        abc.Add(tagmatch.Groups[0].ToString());
                        int sIndex = htmlTextBox.Text.IndexOf(abc[i].ToString());
                        int sLength = abc[i].ToString().Length;


                        int cursorposition = htmlTextBox.SelectionStart;

                        htmlTextBox.Select(sIndex, sLength);
                        htmlTextBox.SelectionColor = System.Drawing.Color.DarkBlue;

                        htmlTextBox.SelectionStart = cursorposition;
                        htmlTextBox.DeselectAll();
                    }

                    i++;
                }
                htmlTextBox.SelectionColor = System.Drawing.Color.Black;
            }
            else
            {
                int firstCharIndex = htmlTextBox.GetFirstCharIndexOfCurrentLine();
                int currentLine = htmlTextBox.GetLineFromCharIndex(firstCharIndex);
                string currentLineText = htmlTextBox.Lines[currentLine];
                htmlTextBox.Select(firstCharIndex, currentLineText.Length);
                htmlTextBox.SelectionColor = System.Drawing.Color.Red;
                htmlTextBox.Select(selectionStart, 0);
                htmlTextBox.SelectionColor = htmlTextBox.ForeColor;
            }
        }


        public void changeLine(winForms.RichTextBox htmlTextBox, int line, int color)
        {
            int cursorposition = htmlTextBox.SelectionStart;
            int s1 = htmlTextBox.GetFirstCharIndexFromLine(line);
            int s2 = line < htmlTextBox.Lines.Count() - 1 ?
                      htmlTextBox.GetFirstCharIndexFromLine(line + 1) - 1 :
                      htmlTextBox.Text.Length;
            htmlTextBox.Select(s1, s2 - s1);
            if (color == 1) // Fail Red
            {
                htmlTextBox.SelectionColor = System.Drawing.Color.Red;
            }
            else if (color == 2) // selector color
            {
                htmlTextBox.SelectionColor = System.Drawing.Color.FromArgb(unchecked((int)0xB59D3E));

            }
            else if (color == 3) // property color
            {
                htmlTextBox.SelectionColor = System.Drawing.Color.FromArgb(unchecked((int)0x4F77B4));

            }
            htmlTextBox.SelectionStart = cursorposition;
        }


        public void ProcessAutoCompleteBrackets(String s, winForms.RichTextBox htmlTextBox)
        {
            int selectedIndex = htmlTextBox.SelectionStart;
            switch (s)
            {
                case "(":
                    htmlTextBox.Text = htmlTextBox.Text.Insert(selectedIndex, ")");
                    htmlTextBox.SelectionStart = selectedIndex;
                    is_AutoCompleteCharacterPressed = true;
                    break;

                case "[":
                    htmlTextBox.Text = htmlTextBox.Text.Insert(selectedIndex, "]");
                    htmlTextBox.SelectionStart = selectedIndex;
                    is_AutoCompleteCharacterPressed = true;
                    break;

                case "{":
                    htmlTextBox.Text = htmlTextBox.Text.Insert(selectedIndex, "}");
                    htmlTextBox.SelectionStart = selectedIndex;
                    is_AutoCompleteCharacterPressed = true;
                    break;

                case "\"":
                    htmlTextBox.Text = htmlTextBox.Text.Insert(selectedIndex, "\"");
                    htmlTextBox.SelectionStart = selectedIndex;
                    is_AutoCompleteCharacterPressed = true;
                    break;

                case "'":
                    htmlTextBox.Text = htmlTextBox.Text.Insert(selectedIndex, "'");
                    htmlTextBox.SelectionStart = selectedIndex;
                    is_AutoCompleteCharacterPressed = true;
                    break;

                default:
                    break;
            }
        }

        public void AutoCompleteTags(string ch, winForms.RichTextBox htmlTextBox)
        {
            if (ch == "<")
            {
                is_LessThanKeyPressed = true;
                is_SpaceBarKeyPressed = false;
                EnteredString = "";
            }
            else if (ch == ">")
            {
                if (!is_TagClosedKeyPressed)
                {
                    is_GreaterThanKeyPressed = true;
                    is_SpaceBarKeyPressed = false;

                    int selectedIndex = htmlTextBox.SelectionStart;

                    for (int i = 0; i < tagslist.Length; i++)
                    {
                        if (EnteredString == tagslist[i])
                        {
                            htmlTextBox.Text = htmlTextBox.Text.Insert(selectedIndex, "</" + tagslist[i] + ">");
                            htmlTextBox.SelectionStart = htmlTextBox.SelectionStart + selectedIndex;
                            EnteredString = "";
                        }
                    }
                    is_LessThanKeyPressed = false;
                }
                else
                {
                    is_TagClosedKeyPressed = false;
                }
            }
            else
            {
                if (is_LessThanKeyPressed)
                {
                    for (char c = 'a'; c <= 'z'; c++)
                    {
                        if (c.ToString() == ch)
                        {
                            EnteredString += ch;
                        }
                        else if (c.ToString().ToUpper() == ch)
                        {
                            EnteredString += ch;
                        }
                    }
                }
            }

            // if user itself closes the tag
            if (is_LessThanKeyPressed)
            {
                if (ch == "/")
                {
                    is_TagClosedKeyPressed = true;
                    is_SpaceBarKeyPressed = true;
                    EnteredString = "";
                }
            }
        }

        public void CheckAutoComplete(winForms.KeyEventArgs e, winForms.RichTextBox htmlTextBox)
        {
            switch (e.KeyCode)
            {
                case System.Windows.Forms.Keys.Space:
                    is_SpaceBarKeyPressed = true;

                    if (is_GreaterThanKeyPressed)
                    {
                        is_GreaterThanKeyPressed = false;
                    }
                    is_LessThanKeyPressed = false;

                    for (int i = 0; i < tagslist.Length; i++)
                    {
                        if (EnteredString == tagslist[i])
                        {
                            EnteredString = tagslist[i];
                        }
                    }
                    break;

                case System.Windows.Forms.Keys.Up:
                    if (is_AutoCompleteCharacterPressed == false)
                    {
                        EnteredString = "";
                        is_AutoCompleteCharacterPressed = false;
                    }
                    is_SpaceBarKeyPressed = false;
                    break;

                case System.Windows.Forms.Keys.Down:
                    if (is_AutoCompleteCharacterPressed == false)
                    {
                        EnteredString = "";
                        is_AutoCompleteCharacterPressed = false;
                    }
                    is_SpaceBarKeyPressed = false;
                    break;

                case System.Windows.Forms.Keys.Left:
                    if (is_AutoCompleteCharacterPressed == false)
                    {
                        EnteredString = "";
                        is_AutoCompleteCharacterPressed = false;
                    }
                    is_SpaceBarKeyPressed = false;
                    break;

                case System.Windows.Forms.Keys.Right:
                    if (is_AutoCompleteCharacterPressed == false)
                    {
                        EnteredString = "";
                        is_AutoCompleteCharacterPressed = false;
                    }
                    is_SpaceBarKeyPressed = false;
                    break;

                case System.Windows.Forms.Keys.Enter:
                    EnteredString = "";
                    is_SpaceBarKeyPressed = false;
                    break;

                case System.Windows.Forms.Keys.Back:
                    int selectionPoint = htmlTextBox.SelectionStart;
                    System.Drawing.Point point = htmlTextBox.GetPositionFromCharIndex(selectionPoint);
                    char ch = htmlTextBox.GetCharFromPosition(point);
                    if (EnteredString.Length > 0)
                    {
                        if (ch != '>')
                        {
                            EnteredString = EnteredString.Remove(EnteredString.Length - 1);
                            is_LessThanKeyPressed = true;
                        }
                    }
                    if (ch == '<')
                    {
                        EnteredString = "";
                    }
                    break;
            }
        }
    }
}
