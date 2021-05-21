namespace SamplesLibrary.Samples.WorkboookView.DisplayOptions
{
    public class WorkbookWindowInfoSample : ISpreadsheetGearWindowsSample
    {
        public void ToggleScrollBars(IWorkbookView workbookView)
        {
            // NOTE: Must acquire a workbook set lock.
            workbookView.GetLock();
            try
            {
                // Get a reference to the active workbook window info.
                SpreadsheetGear.IWorkbookWindowInfo windowInfo = workbookView.ActiveWorkbookWindowInfo;

                // Toggle display of the horizontal scroll bar.
                windowInfo.DisplayHorizontalScrollBar = !windowInfo.DisplayHorizontalScrollBar;

                // Toggle display of the vertical scroll bar.
                windowInfo.DisplayVerticalScrollBar = !windowInfo.DisplayVerticalScrollBar;
            }
            finally
            {
                // NOTE: Must release the workbook set lock.
                workbookView.ReleaseLock();
            }
        }

        public void ToggleSheetTabs(IWorkbookView workbookView)
        {
            // NOTE: Must acquire a workbook set lock.
            workbookView.GetLock();
            try
            {
                // Get a reference to the active workbook window info.
                SpreadsheetGear.IWorkbookWindowInfo windowInfo = workbookView.ActiveWorkbookWindowInfo;

                // Toggle display of the workbook tabs.
                windowInfo.DisplayWorkbookTabs = !windowInfo.DisplayWorkbookTabs;
            }
            finally
            {
                // NOTE: Must release the workbook set lock.
                workbookView.ReleaseLock();
            }
        }

        public void SetTabRatio(IWorkbookView workbookView, double ratio)
        {
            // NOTE: Must acquire a workbook set lock.
            workbookView.GetLock();
            try
            {
                // Get a reference to the active workbook window info.
                SpreadsheetGear.IWorkbookWindowInfo windowInfo = workbookView.ActiveWorkbookWindowInfo;

                // Ensure tabs and scrollbars are displayed.
                windowInfo.DisplayWorkbookTabs = true;
                windowInfo.DisplayHorizontalScrollBar = true;
                windowInfo.DisplayVerticalScrollBar = true;

                // Toggle display of the workbook tabs.
                windowInfo.TabRatio = ratio;
            }
            finally
            {
                // NOTE: Must release the workbook set lock.
                workbookView.ReleaseLock();
            }
        }
    }
}
