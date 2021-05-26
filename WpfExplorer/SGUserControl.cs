/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using SharedSamples;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Controls;

namespace WPFExplorer
{
    /// <summary>
    /// The base class derived from UserControl used for all WPF samples.  Includes an SGDisposalManager to help manage proper disposal 
    /// of workbook sets and WorkbookViews that are used by the samples (proper disposal is needed in order to avoid issues with 
    /// the "free" mode of the products that has row / column / worksheet / workbook limits).
    /// </summary>
    public abstract class SGUserControl : UserControl, ISample, IDisposable
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
        }

        public override void EndInit()
        {
            base.EndInit();
            WpfWorkbookView workbookView = this.FindName("workbookView") as WpfWorkbookView;
            if (workbookView != null)
            {
                DisposalManager.RegisterWorkbookViews(workbookView);
                //switch (this.GetType().Name)
                //{
                //    case "AdvancedPrintingSample":
                //    case "BasicPrintingSample":
                //    case "PageBreaksSample":
                //    case "PageSetupSample":
                //    case "DisplayReferenceSample":
                //    case "ShapeSelectionChangedSample":
                //        DisposalManager.ResetWorkbookView(workbookView, false);
                //        break;
                //    default:
                //        break;
                //}
            }
        }

        public Guid Id { get; } = Guid.NewGuid();
    }
}
