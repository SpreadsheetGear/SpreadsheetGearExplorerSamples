/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using SamplesLibrary;
using SpreadsheetGear.Windows.Controls;

namespace WPFExplorer
{
    /// <summary>
    /// Simple wrapper around the <see cref="WorkbookView"/> that implements <see cref="IWorkbookView"/> and is used by most <see cref="ISpreadsheetGearWindowsSample"/> samples.
    /// </summary>
    public class WpfWorkbookView : WorkbookView, IWorkbookView
    {
        System.Windows.Forms.IWin32Window IWorkbookView.GetOwnerWindow()
        {
            System.Windows.FrameworkElement element = this;
            while (element != null && element.Parent is System.Windows.FrameworkElement parent)
                element = parent;
            return new Win32Window(element);
        }

        internal class Win32Window : System.Windows.Forms.IWin32Window
        {
            private readonly System.IntPtr _handle;

            internal Win32Window(System.Windows.Media.Visual visual)
            {
                var source = System.Windows.PresentationSource.FromVisual(visual);
                var sourceHwnd = source as System.Windows.Interop.HwndSource;
                _handle = sourceHwnd.Handle;
            }

            System.IntPtr System.Windows.Forms.IWin32Window.Handle
            {
                get
                {
                    return _handle;
                }
            }
        }
    }
}
