namespace SamplesLibrary.Samples.WorkboookView
{
    public class LocationToRangeSample : ISpreadsheetGearWindowsSample
    {
        public void ColorizeClickedCell(IWorkbookView workbookView, double mouseX, double mouseY)
        {
            // NOTE: Must acquire a workbook set lock.
            workbookView.GetLock();
            try
            {
                // Get the 0-based row and column indexes where the mouse was clicked.  The RangeLocationFlags
                // can be used to determine relative to what pane this position should be calculated.  In this case
                // no split panes are used.  The 'Headers' flag can be passed in to detect whether the mouse was 
                // clicked in the Row/Column Header area in which case -1 is returned.  The 'Outlines' flag could also
                // be passed in, in which case -2 is returned if the mouse was clicked in the Outlines area.
                workbookView.LocationToRange(mouseX, mouseY, out double row, out double column,
                    SpreadsheetGear.Controls.RangeLocationFlags.None);

                // Get an IRange for the row / column values determined above.
                SpreadsheetGear.IRange range = workbookView.ActiveWorksheet.Cells[(int)row, (int)column];

                // If this location is over a cell or row/col header, set the interior color.
                if (range != null)
                    range.Interior.Color = SpreadsheetGear.Colors.SlateBlue;
            }
            finally
            {
                // NOTE: Must release the workbook set lock.
                workbookView.ReleaseLock();
            }
        }
    }
}
