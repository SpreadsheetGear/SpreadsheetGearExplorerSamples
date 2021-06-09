namespace SamplesLibrary.Samples.Shapes.FormControls
{
    public class CheckBoxSample : ISpreadsheetGearEngineSample
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

            // Calculate the left, top, width and height of the checkbox by 
            // converting row and column coordinates to points.  Use fractional 
            // values to get coordinates in between row and column boundaries.
            double left = windowInfo.ColumnToPoints(1.1);
            double top = windowInfo.RowToPoints(1.1);
            double right = windowInfo.ColumnToPoints(3.9);
            double bottom = windowInfo.RowToPoints(2.9);
            double width = right - left;
            double height = bottom - top;

            // Add the checkbox using the calculated bounds.
            SpreadsheetGear.Shapes.IShape shape =
                worksheet.Shapes.AddFormControl(
                SpreadsheetGear.Shapes.FormControlType.CheckBox,
                left, top, width, height);

            // Link the checkbox to cell A2.
            shape.ControlFormat.LinkedCell = "A2";

            // Set the text of the checkbox.
            shape.TextFrame.Characters.Text = "Click Here to Toggle Cell A2";
        }
    }
}
