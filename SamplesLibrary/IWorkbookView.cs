﻿/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using SpreadsheetGear;
using SpreadsheetGear.Commands;
using SpreadsheetGear.Printing;
using SpreadsheetGear.Controls;

namespace SamplesLibrary
{
    /// <summary>
    /// Abstracts away a common set of properties and methods from both the Windows Forms WorkbookView control 
    /// and WPF WorkbookView control so that samples implementing <see cref="ISpreadsheetGearWindowsSample"/> 
    /// can use this common interface.
    /// </summary>
    public interface IWorkbookView
    {
        IWorkbookSet ActiveWorkbookSet { get; set; }
        IWorkbook ActiveWorkbook { get; set; }
        IWorksheet ActiveWorksheet { get; set; }
        IWorkbookWindowInfo ActiveWorkbookWindowInfo { get;  }
        IWorksheetWindowInfo ActiveWorksheetWindowInfo { get; }
        CommandManager ActiveCommandManager { get; }
        IRange RangeSelection { get; set; }
        public string DisplayReference { get; set; }
        public string DisplayReferenceName { get; set; }
        public void GetLock();
        public void ReleaseLock();
        public void Print(bool showPrintDialog);
        public void Print(PrintWhat printWhat, bool showPrintDialog);
        public void PrintPreview();
        public void PrintPreview(PrintWhat printWhat);
        public void LocationToRange(double x, double y, out double row, out double column, RangeLocationFlags flags);
    }
}
