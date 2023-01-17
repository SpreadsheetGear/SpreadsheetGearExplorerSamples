/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using SpreadsheetGear;
using System;
using System.Collections.Generic;

namespace SamplesLibrary.Engine
{
    /// <summary>
    /// <para>
    /// A helper class to manage disposal of WorkbookView and IWorkbookSet objects used in the samples.
    /// </para>
    /// 
    /// <para>
    /// Proper disposal is necessary because these samples will most likely be run without a Signed License 
    /// (i.e., in the "Free" mode), which limits it usage to 1,000 rows x  100 columns x 10 worksheets x 
    /// 3 workbooks.  Without careful disposal of the workbooks used by a given sample, the 3-workbook limit 
    /// would quickly be exceeded after running or re-running just a few samples.
    /// </para>
    /// 
    /// <para>
    /// Licensed users of SpreadsheetGear can generate a Signed License to enable the Licensed (unlimited) mode 
    /// from https://www.spreadsheetgear.com/Downloads/Licensed.  If you are copying and pasting
    /// code from these samples, any calls to this SGDisposalManager class should be removed.
    /// </para>
    /// 
    /// <para>
    /// Evaluators can enable a 30-day trial that unlocks the Free mode limits by generating a Signed Trial 
    /// License at https://www.spreadsheetgear.com/Downloads/Evaluation.
    /// </para>
    /// </summary>
    public class SGDisposalManager : IDisposable
    {
        /// <summary>
        /// Holds a list of IWorkbookSets that should be disposed of when the sample is disposed.  Implemented samples 
        /// should call <see cref="RegisterIWorkbookSets(IWorkbookSet[])"/> to add to this list.  For WorkbookViews, use 
        /// <see cref="RegisterWorkbookViews(IWorkbookView[])"/> to dispose its ActiveWorkbookSet.
        /// </summary>
        private readonly List<IWorkbookSet> _workbookSets = new List<IWorkbookSet>();


        /// <summary>
        /// Stores off any IWorkbookSets that should be disposed of when the sample  is disposed.
        /// </summary>
        public void RegisterIWorkbookSets(params IWorkbookSet[] workbookSets)
        {
            _workbookSets.AddRange(workbookSets);
        }


        public void Dispose() => Dispose(true);

        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
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
