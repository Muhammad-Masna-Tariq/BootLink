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
        public void CopyElement(CefSharp.Wpf.ChromiumWebBrowser MainWindowBrowser)
        {
            IFrame copyFrame = MainWindowBrowser.GetMainFrame();
            copyFrame.ExecuteJavaScriptAsync("copyAllElements()");
        }

        public void PasteElement(CefSharp.Wpf.ChromiumWebBrowser MainWindowBrowser)
        {
            var clipboarddata = System.Windows.Clipboard.GetText();
            IFrame frame = MainWindowBrowser.GetMainFrame();
            frame.ExecuteJavaScriptAsync(String.Format("pasteAllElements(`{0}`)", clipboarddata));
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
