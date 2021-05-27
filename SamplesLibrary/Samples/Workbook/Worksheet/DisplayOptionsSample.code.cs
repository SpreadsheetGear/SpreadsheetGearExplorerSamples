namespace SamplesLibrary.Samples.Workbook.Worksheet
{
    public class DisplayOptionsSample : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Create a new workbook.
            Workbook = SpreadsheetGear.Factory.GetWorkbook();
            // Add some cell values with their addresses.
            Workbook.ActiveWorksheet.Cells["A1:G1"].Value = new object[,] { 
                { "A1", "B1", "C1", "D1", "E1", "F1", "G1" } 
            };
        }

        public void RunSample()
        {
            // Create some local variables to the active worksheet, window info and its cells.
            SpreadsheetGear.IWorksheet worksheet = Workbook.ActiveWorksheet;
            SpreadsheetGear.IRange cells = worksheet.Cells;
            SpreadsheetGear.IWorksheetWindowInfo windowInfo = worksheet.WindowInfo;

            // Add a formula to a cell (DisplayFormulas will show the formula instead of the value).
            cells["I7"].Formula = "=PI()";

            // Set the zoom to 75%.  Available range is 10% - 400%.
            windowInfo.Zoom = 75;

            // Place a horizontal split so that 1 row is displayed above the split.
            windowInfo.SplitRows = 1;

            // Scroll the worksheet horizontally so that Column D is the first visible column.
            windowInfo.ScrollColumn = 3;

            // Place a vertical split so that 2 columns are displayed to the left of the split.
            // Note that the split is positioned relative to the first visible column (Column D
            // in this case) and not Column A, which effectively hides Columns A:B.
            windowInfo.SplitColumns = 2;

            // The vertical and horizontal splits we just created could be moved in Excel unless
            // you enable FreezePanes.  Unfrozen panes also allows for the top and left panes to
            // be scrollable.
            windowInfo.FreezePanes = true;

            // Enable or disable gridlines (enabled by default).
            windowInfo.DisplayGridlines = true;

            // Set gridline color.
            windowInfo.GridlineColor = SpreadsheetGear.Colors.LightSkyBlue;

            // Show or hide the row and column headers.
            windowInfo.DisplayHeadings = false;

            // Toggle showing either the calculated values of formulas or the formulas 
            // themselves.
            windowInfo.DisplayFormulas = true;

            // Make a more complex range selection with multiple areas, and specify a specific
            // cell within the second area of the range selection to be the active cell.
            windowInfo.SetSelection(cells["F2:H4,H6:J8,I10:K12"], cells["I7"], 1);
        }
    }
}
