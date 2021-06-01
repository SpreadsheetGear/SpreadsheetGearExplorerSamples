/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using SamplesLibrary;
using SpreadsheetGear.Windows.Forms;

namespace WindowsFormsExplorer
{
    /// <summary>
    /// Simple wrapper around the <see cref="WorkbookView"/> that implements <see cref="IWorkbookView"/> and is used by most <see cref="ISpreadsheetGearWindowsSample"/> samples.
    /// </summary>
    public class WinFormsWorkbookView : WorkbookView, IWorkbookView
    {
        System.Windows.Forms.IWin32Window IWorkbookView.GetOwnerWindow()
        {
            return this.TopLevelControl;
        }
    }
}
