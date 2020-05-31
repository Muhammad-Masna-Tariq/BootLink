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
using System.Windows.Forms;

namespace Fyp
{
    class DOMHierarchy
    {
        private XmlDocument XmlDocument = new XmlDocument();
        private static string path = winForms.Application.StartupPath + @"\\DOM.html";

        public void generateDOM(winForms.TreeView treeView, winForms.RichTextBox richTextBox)
        {
            if (richTextBox.Text == "")
            {
                File.WriteAllText(path, "<html></html>");
            }
            else
            {
                File.WriteAllText(path, richTextBox.Text);
                treeView.Nodes.Clear();
                XmlDocument.Load(path);
                LoadTreeViewFromXmlDoc(XmlDocument, treeView);
                treeView.ExpandAll();
            }

        }

        public void LoadTreeViewFromXmlDoc(XmlDocument xmlDocument, winForms.TreeView treeView)
        {
            string i = "";
            treeView.Nodes.Clear();
            AddTreeViewNode(treeView.Nodes, xmlDocument.DocumentElement, i);
        }

        private void AddTreeViewNode(TreeNodeCollection parentNodes, XmlNode xmlNode, string i)
        {

            TreeNode treeNode = parentNodes.Add(i + "", xmlNode.Name);
            var attr = "";

            foreach (XmlNode childNode in xmlNode.ChildNodes)
            {
                if (childNode.Attributes != null)
                {
                    attr = childNode.Attributes["id"].Value;
                    //treeNode.Tag = 
                }
                AddTreeViewNode(treeNode.Nodes, childNode, attr);
                //treeNode.Tag = xmlNode.Value;
            }
        }

        public void findAndHighlightTag(winForms.RichTextBox htmlTextBox, string id)
        {
            int length = htmlTextBox.Text.Length;
            int index = 0;
            int lastIndex = htmlTextBox.Text.LastIndexOf(id);

            while (index < lastIndex)
            {
                htmlTextBox.Find(id, index, length, RichTextBoxFinds.MatchCase);
                htmlTextBox.SelectionBackColor = System.Drawing.Color.DarkOrange;
                htmlTextBox.Focus();
                index = htmlTextBox.Text.IndexOf(id, index) + 1;
            }
        }
    }
}
