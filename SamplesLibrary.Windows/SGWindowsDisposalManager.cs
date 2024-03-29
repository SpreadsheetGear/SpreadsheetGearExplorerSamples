﻿/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/
using SpreadsheetGear;

namespace SamplesLibrary.Windows
{
    public class SGWindowsDisposalManager : SamplesLibrary.Engine.SGDisposalManager
    {
        /// <summary>
        /// Holds a list of WorkbookViews whose workbook sets should be disposed of when the sample is disposed.  
        /// Implemented samples should call <see cref="RegisterWorkbookViews(IWorkbookView[])"/> to register these 
        /// WorkbookView controls.
        /// </summary>
        private readonly List<IWorkbookView> _workbookViews = new List<IWorkbookView>();


        /// <summary>
        /// Stores off any WorkbookViews whose workbook sets should be disposed of when the sample is disposed.  
        /// </summary>
        public void RegisterWorkbookViews(params IWorkbookView[] workbookViews)
        {
            _workbookViews.AddRange(workbookViews);
        }


        /// <summary>
        /// Disposes of the specified WorkbookView's ActiveWorkbookSet, sets it up with a new IWorkbookSet instance
        /// and, optionally, populates it with an initial empty workbook.
        /// 
        /// <para>
        /// Proper disposal of the workbook set is necessary because these samples will most likely be run without a Signed 
        /// License (i.e., in the "Free" mode), which limits it usage to 1,000 rows x  100 columns x 10 worksheets x 
        /// 3 workbooks.  Without careful disposal of the workbooks used by a given sample, the 3-workbook limit would quickly 
        /// be exceeded after running or re-running just a few samples.
        /// </para>
        /// 
        /// <para>
        /// Licensed users of SpreadsheetGear can generate a Signed License to enable the Licensed (unlimited) mode 
        /// from https://www.spreadsheetgear.com/Downloads/Licensed.  If you are copying and pasting
        /// code from these samples into your own project, any calls to this SGDisposalManager class should be removed.
        /// </para>
        /// 
        /// <para>
        /// Evaluators can enable a 30-day trial that unlocks the Free mode limits by generating a Signed Trial 
        /// License at https://www.spreadsheetgear.com/Downloads/Evaluation.
        /// </para>
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

        private bool _disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    foreach (var wbv in _workbookViews)
                    {
                        wbv.ActiveWorkbookSet.Dispose();
                    }
                }
                _disposed = true;
            }

            base.Dispose(disposing);
        }
    }
}
