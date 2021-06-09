namespace SamplesLibrary.Samples.Shapes.FormControls
{
    public class SpinnerSample : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Create a new workbook.
            Workbook = SpreadsheetGear.Factory.GetWorkbook();
        }

        public void RunSample()
        {
            // Create some local variables to the active worksheet and its window info.
            SpreadsheetGear.IWorksheet worksheet = Workbook.ActiveWorksheet;
            SpreadsheetGear.IWorksheetWindowInfo windowInfo = worksheet.WindowInfo;

            // Calculate the left, top, width and height of the spinner by 
            // converting row and column coordinates to points.  Use fractional 
            // values to get coordinates in between row and column boundaries.
            double left = windowInfo.ColumnToPoints(1.1);
            double top = windowInfo.RowToPoints(1.4);
            double right = windowInfo.ColumnToPoints(1.9);
            double bottom = windowInfo.RowToPoints(3.6);
            double width = right - left;
            double height = bottom - top;

            // Add the spinner using the calculated bounds.
            SpreadsheetGear.Shapes.IShape shape =
                worksheet.Shapes.AddFormControl(
                SpreadsheetGear.Shapes.FormControlType.Spinner,
                left, top, width, height);

            // Get a reference to the control format.
            SpreadsheetGear.Shapes.IControlFormat controlFormat = shape.ControlFormat;

            // Link the spinner to cell A2.
            controlFormat.LinkedCell = "A2";

            // Set the spinner minimum, maximum and interval.
            controlFormat.Min = 0;
            controlFormat.Max = 100;
            controlFormat.SmallChange = 10;
        }
    }
}
