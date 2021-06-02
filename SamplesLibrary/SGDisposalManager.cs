/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using SpreadsheetGear;
using System;
using System.Collections.Generic;
using System.Text;

namespace SamplesLibrary
{
    /// <summary>
    /// A helper class to manage disposal of WorkbookView and IWorkbookSet objects used in the samples.
    /// Proper disposal is necessary because these samples will most likely be run without a Signed License, which 
    /// limits it usage to 1,000 rows x  100 columns x 10 worksheets x 3 workbooks, and so eventually exceed one of 
    /// these limites while switching between samples or re-running samples.
    /// </summary>
    public class SGDisposalManager : IDisposable
    {
        /// <summary>
        /// Holds a list of WorkbookViews whose workbook sets should be disposed of when the sample is disposed.  
        /// Implemented samples should call <see cref="RegisterWorkbookViews(IWorkbookView[])"/> to register these 
        /// WorkbookView controls.
        /// </summary>
        private List<IWorkbookView> _workbookViews = new List<IWorkbookView>();

        /// <summary>
        /// Stores off any WorkbookViews whose workbook sets should be disposed of when the sample is disposed.  
        /// </summary>
        public void RegisterWorkbookViews(params IWorkbookView[] workbookViews)
        {
            _workbookViews.AddRange(workbookViews);
        }

        /// <summary>
        /// Holds a list of IWorkbookSets that should be disposed of when the sample is disposed.  Implemented samples 
        /// should call <see cref="RegisterIWorkbookSets(IWorkbookSet[])"/> to add to this list.  For WorkbookViews, use 
        /// <see cref="RegisterWorkbookViews(IWorkbookView[])"/> to dispose its ActiveWorkbookSet.
        /// </summary>
        private List<IWorkbookSet> _workbookSets = new List<IWorkbookSet>();

        /// <summary>
        /// Stores off any IWorkbookSets that should be disposed of when the sample  is disposed.
        /// </summary>
        public void RegisterIWorkbookSets(params IWorkbookSet[] workbookSets)
        {
            _workbookSets.AddRange(workbookSets);
        }

        /// <summary>
        /// Disposes of the specified WorkbookView's ActiveWorkbookSet and sets it up with a new workbook set
        /// and, optionally, an initial workbook as well.
        /// </summary>
        /// <param name="workbookView">The WorkbookView to reset.</param>
        /// <param name="includeInitialWorkbook">Create a new empty workbook in the new workbook set.</param>
        public void ResetWorkbookView(IWorkbookView workbookView, bool includeInitialWorkbook = true)
        {
            workbookView.GetLock();
            try
            {
                var wbsNew = Factory.GetWorkbookSet();
                var wbsOld = workbookView.ActiveWorkbookSet;

                workbookView.ActiveWorkbookSet = wbsNew;
                wbsOld.Dispose();
                if (includeInitialWorkbook)
                    workbookView.ActiveWorkbookSet.Workbooks.Add();
            }
            finally
            {
                workbookView.ReleaseLock();
            }
        }


        public void Dispose() => Dispose(true);

        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                foreach (var wbv in _workbookViews)
                {
                    wbv.ActiveWorkbookSet.Dispose();
                    //ResetWorkbookView(wbv, false);
                }
                foreach (var wbs in _workbookSets)
                {
                    if (!wbs.IsDisposed)
                        wbs.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
