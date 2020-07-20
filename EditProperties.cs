using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;


namespace Fyp
{
    class EditProperties
    {
        public static bool copycheck = false;

        public void CopyElement(CefSharp.Wpf.ChromiumWebBrowser MainWindowBrowser)
        {
            IFrame copyFrame = MainWindowBrowser.GetMainFrame();
            copyFrame.ExecuteJavaScriptAsync("copyAllElements()");
        }


        public void PasteElement(CefSharp.Wpf.ChromiumWebBrowser MainWindowBrowser)
        {
            if (copycheck)
            {


                var clipboarddata = System.Windows.Clipboard.GetText();
                IFrame frame = MainWindowBrowser.GetMainFrame();
                frame.ExecuteJavaScriptAsync(String.Format("pasteAllElements(`{0}`)", clipboarddata));
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Please select an element to paste", "Element Selection Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }


        }


        public void SelectAllElements(CefSharp.Wpf.ChromiumWebBrowser MainWindowBrowser)
        {
            IFrame selectFrame = MainWindowBrowser.GetMainFrame();
            selectFrame.ExecuteJavaScriptAsync("selectAllElements()");
        }


        public void DeleteElement(CefSharp.Wpf.ChromiumWebBrowser MainWindowBrowser)
        {
            IFrame deleteFrame = MainWindowBrowser.GetMainFrame();
            deleteFrame.ExecuteJavaScriptAsync("deleteAllElements()");
        }
    }
}









