namespace SamplesLibrary.Samples.Shapes.FormControls
{
    public class ComboBoxSample : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Create a new workbook.
            Workbook = SpreadsheetGear.Factory.GetWorkbook();
        }

        public void RunSample()
        {
            // Create some local variables to the active worksheet and its window info
            // and cells.
            SpreadsheetGear.IWorksheet worksheet = Workbook.ActiveWorksheet;
            SpreadsheetGear.IWorksheetWindowInfo windowInfo = worksheet.WindowInfo;
            SpreadsheetGear.IRange cells = worksheet.Cells;

            // Populate some cells which will be linked to from the ComboBox.
            cells["A50"].Value = "January";
            cells["A51"].Value = "February";
            cells["A52"].Value = "March";
            cells["A53"].Value = "April";
            cells["A54"].Value = "May";
            cells["A55"].Value = "June";
            cells["A56"].Value = "July";
            cells["A57"].Value = "August";
            cells["A58"].Value = "September";
            cells["A59"].Value = "October";
            cells["A60"].Value = "November";
            cells["A61"].Value = "December";

            // Calculate the left, top, width and height of the ComboBox by 
            // converting row and column coordinates to points.  Use fractional 
            // values to get coordinates in between row and column boundaries.
            double left = windowInfo.ColumnToPoints(1.1);
            double top = windowInfo.RowToPoints(1.4);
            double right = windowInfo.ColumnToPoints(2.9);
            double bottom = windowInfo.RowToPoints(2.6);
            double width = right - left;
            double height = bottom - top;

            // Add the ComboBox using the calculated bounds.
            SpreadsheetGear.Shapes.IShape shape =
                worksheet.Shapes.AddFormControl(
                SpreadsheetGear.Shapes.FormControlType.DropDown,
                left, top, width, height);

            // Get a reference to the control format.
            SpreadsheetGear.Shapes.IControlFormat controlFormat = shape.ControlFormat;

            // Fill the ComboBox with a range of existing values.
            controlFormat.ListFillRange = "A50:A61";

            // Link the ComboBox to cell A2.
            controlFormat.LinkedCell = "A2";

            // Set the number of items to display when the control is dropped down.
            controlFormat.DropDownLines = controlFormat.ListCount;

            // Select the first item in the list.
            controlFormat.ListIndex = 0;
        }
    }
}
