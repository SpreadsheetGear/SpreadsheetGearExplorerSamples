namespace SamplesLibrary.Samples.WorkboookView.DisplayOptions
{
    public class WorksheetWindowInfoSample : ISpreadsheetGearWindowsSample
    {
        public void FreezePanes(IWorkbookView workbookView)
        {
            // NOTE: Must acquire a workbook set lock.
            workbookView.GetLock();
            try
            {
                // Get a reference to the active worksheet window info.
                SpreadsheetGear.IWorksheetWindowInfo windowInfo =
                    workbookView.ActiveWorksheetWindowInfo;

                // Display the first row at the top.
                windowInfo.ScrollRow = 0;

                // Display the first column at the left.
                windowInfo.ScrollColumn = 0;

                // Split two rows.
                windowInfo.SplitRows = 2;

                // Split one column.
                windowInfo.SplitColumns = 1;

                // Freeze the top and left panes.
                windowInfo.FreezePanes = true;
            }
            finally
            {
                // NOTE: Must release the workbook set lock.
                workbookView.ReleaseLock();
            }
        }

        public void ToggleGridlines(IWorkbookView workbookView)
        {
            // NOTE: Must acquire a workbook set lock.
            workbookView.GetLock();
            try
            {
                // Get a reference to the active worksheet window info.
                SpreadsheetGear.IWorksheetWindowInfo windowInfo =
                    workbookView.ActiveWorksheetWindowInfo;

                // Toggle display of gridlines.
                windowInfo.DisplayGridlines = !windowInfo.DisplayGridlines;

                // If gridlines are displayed...
                if (windowInfo.DisplayGridlines)
                {
                    // Set the color of the gridlines.
                    windowInfo.GridlineColor = SpreadsheetGear.Colors.SlateBlue;
                }
            }
            finally
            {
                // NOTE: Must release the workbook set lock.
                workbookView.ReleaseLock();
            }
        }

        public void ToggleHeadings(IWorkbookView workbookView)
        {
            // NOTE: Must acquire a workbook set lock.
            workbookView.GetLock();
            try
            {
                // Get a reference to the active worksheet window info.
                SpreadsheetGear.IWorksheetWindowInfo windowInfo =
                    workbookView.ActiveWorksheetWindowInfo;

                // Toggle display of row and column headings.
                windowInfo.DisplayHeadings = !windowInfo.DisplayHeadings;
            }
            finally
            {
                // NOTE: Must release the workbook set lock.
                workbookView.ReleaseLock();
            }
        }

        public void Zoom(IWorkbookView workbookView, int zoom)
        {
            // NOTE: Must acquire a workbook set lock.
            workbookView.GetLock();
            try
            {
                // Get a reference to the active worksheet window info.
                SpreadsheetGear.IWorksheetWindowInfo windowInfo =
                    workbookView.ActiveWorksheetWindowInfo;

                // Set the zoom factor.
                windowInfo.Zoom = zoom;
            }
            finally
            {
                // NOTE: Must release the workbook set lock.
                workbookView.ReleaseLock();
            }
        }
    }
}
