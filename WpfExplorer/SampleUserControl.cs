/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using SamplesLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Controls;

namespace WPFExplorer
{
    /// <summary>
    /// The base class derived from UserControl used for all WPF samples.  Includes an SGDisposalManager to help manage proper disposal 
    /// of workbook sets and WorkbookViews that are used by the samples (proper disposal is needed in order to avoid issues with 
    /// the "free" mode of the products, which have row / column / worksheet / workbook limits).
    /// </summary>
    public abstract class SampleUserControl : UserControl, ISample, IDisposable
    {
        public SGDisposalManager DisposalManager { get; private set; } = new SGDisposalManager();

        public void Dispose() => Dispose(true);

        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                DisposalManager.Dispose();
            }

            _disposed = true;
        }

        public Guid Id { get; } = Guid.NewGuid();
    }
}
