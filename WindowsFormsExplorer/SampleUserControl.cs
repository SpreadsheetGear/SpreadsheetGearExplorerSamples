﻿/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using SamplesLibrary.Engine;
using SamplesLibrary.Windows;
using System.Windows.Forms;

namespace WindowsFormsExplorer
{
    /// <summary>
    /// The base class derived from UserControl used for all WinForms samples.  Includes an <see cref="SGDisposalManager"/> to 
    /// help manage proper disposal of workbook sets and WorkbookViews that are used by the samples (proper disposal is needed 
    /// in order to avoid issues with the "free" mode of the products, which have row / column / worksheet / workbook limits).
    /// </summary>
    public class SampleUserControl : UserControl, ISample
    {
        public SGWindowsDisposalManager DisposalManager { get; private set; } = new SGWindowsDisposalManager();

        protected SampleUserControl() { }


        private bool _disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                DisposalManager.Dispose();
            }

            _disposed = true;
        }
    }
}
