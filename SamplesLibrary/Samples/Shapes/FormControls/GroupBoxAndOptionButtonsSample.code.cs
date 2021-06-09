namespace SamplesLibrary.Samples.Shapes.FormControls
{
    public class GroupBoxAndOptionButtonsSample : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Create a new workbook.
            Workbook = SpreadsheetGear.Factory.GetWorkbook();
        }

        public void RunSample()
        {
            // Create some local variables.
            SpreadsheetGear.IWorksheet worksheet = Workbook.ActiveWorksheet;
            SpreadsheetGear.IWorksheetWindowInfo windowInfo = worksheet.WindowInfo;
            SpreadsheetGear.IRange cells = worksheet.Cells;
            double left, top, width, height;

            // We will add an Option Button to each cell in this range.
            SpreadsheetGear.IRange optionsRange = cells["B3:B7"];
            optionsRange.ColumnWidth = 15;

            // Setup GroupBox
            {
                // Setup another IRange representing the boundaries of a GroupBox, which will 
                // contain all of the Option Buttons.
                SpreadsheetGear.IRange groupBoxRange = optionsRange[
                    -1, 0,   // Expand range up one row.
                    optionsRange.RowCount, 0   // Expand range down one row.
                ];

                // Use the RowToPoints(...) and ColumnToPoints(...) methods to get to top-left
                // coordinates (relative to the top-left edge of the worksheet) of the beginning
                // of the range (i.e., the top-left edge of cell B2)..
                left = windowInfo.ColumnToPoints(groupBoxRange.Column) - 5;
                top = windowInfo.RowToPoints(groupBoxRange.Row);
                width = groupBoxRange.Width + 10;
                height = groupBoxRange.Height - 5;

                // Create the GroupBox shape with the above-calculated position and dimensions.
                SpreadsheetGear.Shapes.IShape groupBoxShape = worksheet.Shapes.AddFormControl(
                    SpreadsheetGear.Shapes.FormControlType.GroupBox, left, top, width, height);

                // Set the GroupBox header text.
                groupBoxShape.TextFrame.Characters.Text = "My Group Box";
            }

            // Add individual OptionButtons.  Iterate through each cell in optionsRange.
            for (int i = 0; i < optionsRange.RowCount; i++)
            {
                // Get reference to desired cell.
                SpreadsheetGear.IRange cell = optionsRange[i, 0];

                // Calculate coordinates and dimensions of OptionButton.
                left = windowInfo.ColumnToPoints(cell.Column) + 10; // Add a little padding
                top = windowInfo.RowToPoints(cell.Row);
                width = cell.Width - 10;    // Offset padding from "left"
                height = cell.Height;

                // Add OptionButton and set its label text.
                SpreadsheetGear.Shapes.IShape optionShape = worksheet.Shapes.AddFormControl(
                    SpreadsheetGear.Shapes.FormControlType.OptionButton, left, top, width, height);
                optionShape.TextFrame.Characters.Text = $"My Option {i + 1}";

                // If this is the first OptionButton added, link it to a cell.  All other
                // OptionButtons added to this GroupBox will also be linked to this cell.
                if (i == 0)
                {
                    SpreadsheetGear.Shapes.IControlFormat optionControl = optionShape.ControlFormat;
                    optionControl.LinkedCell = "A1";
                }
            }

            // Set the linked cell's value to a valid index of an OptionButton.  Note that 
            // OptionButton indexes are 1-based.  This will select the 3rd OptionBox.
            cells["A1"].Value = 3;
        }
    }
}
