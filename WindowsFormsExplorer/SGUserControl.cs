﻿/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using SamplesLibrary;
using System;
using System.Windows.Forms;

namespace WindowsFormsExplorer
{
    /// <summary>
    /// The base class derived from UserControl used for all WinForms samples.  Includes an <see cref="SGDisposalManager"/> to 
    /// help manage proper disposal of workbook sets and WorkbookViews that are used by the samples (proper disposal is needed 
    /// in order to avoid issues with the "free" mode of the products that has row / column / worksheet / workbook limiits).
    /// </summary>
    public class SGUserControl : UserControl, ISample
    {
        public SGDisposalManager DisposalManager { get; private set; } = new SGDisposalManager();

        private bool _disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                DisposalManager.Dispose();
            }
        }
    }
}
