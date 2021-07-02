namespace SamplesLibrary.Samples.Shapes
{
    public class TextBoxSample : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Create a new workbook.
            Workbook = SpreadsheetGear.Factory.GetWorkbook();
        }

        public void RunSample()
        {
            // Create local variables to the active worksheet and its window info.
            SpreadsheetGear.IWorksheet worksheet = Workbook.ActiveWorksheet;
            SpreadsheetGear.IWorksheetWindowInfo windowInfo = worksheet.WindowInfo;

            // Calculate the left, top, width and height of the textbox by 
            // converting row and column coordinates to points.  Use fractional 
            // values to get coordinates in between row and column boundaries.
            double left = windowInfo.ColumnToPoints(0.5);
            double top = windowInfo.RowToPoints(1.5);
            double right = windowInfo.ColumnToPoints(5.5);
            double bottom = windowInfo.RowToPoints(10.5);
            double width = right - left;
            double height = bottom - top;

            // Add the textbox using the calculated bounds.
            SpreadsheetGear.Shapes.IShape shape =
                worksheet.Shapes.AddTextBox(left, top, width, height);

            // Get a reference to the shape's textframe and characters.
            SpreadsheetGear.Shapes.ITextFrame textFrame = shape.TextFrame;
            SpreadsheetGear.ICharacters characters = textFrame.Characters;

            // Set the text to display in the textbox.
            characters.Text =
                "SpreadsheetGear...\r\n\r\nIncludes API and " +
                "GUI support for cell comments, data validation, " +
                "pictures, text boxes, check boxes, dropdowns, " +
                "list boxes, spinners, scrollbars, buttons, lines, " +
                "many AutoShapes and more...";

            // Set various font options.
            SpreadsheetGear.IFont font = characters.Font;
            font.Italic = true;
            font.Name = "Times New Roman";
            font.Size = 12;

            // Select the textbox.
            shape.Select(true);
        }
    }
}
