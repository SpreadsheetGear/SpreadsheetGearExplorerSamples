namespace SamplesLibrary.Samples.Shapes.FormControls
{
    public class ButtonSample : ISpreadsheetGearEngineSample
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

            // Calculate the left, top, width and height of the button by 
            // converting row and column coordinates to points.  Use fractional 
            // values to get coordinates in between row and column boundaries.
            double left = windowInfo.ColumnToPoints(0.5);
            double top = windowInfo.RowToPoints(0.5);
            double right = windowInfo.ColumnToPoints(3.5);
            double bottom = windowInfo.RowToPoints(2.5);
            double width = right - left;
            double height = bottom - top;

            // Add a button using the calculated bounds.
            SpreadsheetGear.Shapes.IShape shape =
                worksheet.Shapes.AddFormControl(
                SpreadsheetGear.Shapes.FormControlType.ButtonControl,
                left, top, width, height);

            // Give the first button a name if desired.
            shape.Name = "MyButton";

            // Set the text of the first button.
            shape.TextFrame.Characters.Text = "My Button";
        }
    }
}
