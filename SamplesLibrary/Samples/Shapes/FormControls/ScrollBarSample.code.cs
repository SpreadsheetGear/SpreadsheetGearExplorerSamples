namespace SamplesLibrary.Samples.Shapes.FormControls
{
    public class ScrollBarSample : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Get the full path to a workbook file that will help demonstrate using a ScrollBar.
            string workbookPath = Helpers.GetFullOutputFolderPath(@"Files\Engine\ScrollBarSampleFile.xlsx");

            // Open the workbook.
            Workbook = SpreadsheetGear.Factory.GetWorkbook(workbookPath);
        }

        public void RunSample()
        {
            // Create some local variables to the active worksheet and its window info
            // and cells.
            SpreadsheetGear.IWorksheet worksheet = Workbook.ActiveWorksheet;
            SpreadsheetGear.IWorksheetWindowInfo windowInfo = worksheet.WindowInfo;
            SpreadsheetGear.IRange cells = worksheet.Cells;

            // We want to position the ScrollBar control over this specific range of cells.
            SpreadsheetGear.IRange shapeOverRange = cells["B4:B15"];

            // Use the RowToPoints(...) and ColumnToPoints(...) methods to get to top-left
            // coordinates (relative to the top-left edge of the worksheet) of the beginning
            // of the range (i.e., the top-left edge of cell C4).
            double left = windowInfo.ColumnToPoints(shapeOverRange.Column);
            double top = windowInfo.RowToPoints(shapeOverRange.Row);

            // Dimensions of shape will match the range
            double width = shapeOverRange.Width;
            double height = shapeOverRange.Height;

            // Create the ScrollBar shape with the above-calculated position and dimensions.
            SpreadsheetGear.Shapes.IShape scrollBarShape = worksheet.Shapes.AddFormControl(
                SpreadsheetGear.Shapes.FormControlType.ScrollBar, left, top, width, height);

            // Get the IShape's IControlFormat object to modify various aspects of the ScrollBar.
            SpreadsheetGear.Shapes.IControlFormat scrollBarControl = scrollBarShape.ControlFormat;

            // Link the ScrollBar's value to a cell.
            scrollBarControl.LinkedCell = "N8";

            // Set min / max values ScrollBar can use.
            scrollBarControl.Min = 0;
            scrollBarControl.Max = 1000;

            // Amount applied to value when the up or down button of the ScrollBar is clicked.
            scrollBarControl.SmallChange = 10;

            // Amount applied when the scroll area of the ScrollBar is clicked.
            scrollBarControl.LargeChange = 250;
        }
    }
}
