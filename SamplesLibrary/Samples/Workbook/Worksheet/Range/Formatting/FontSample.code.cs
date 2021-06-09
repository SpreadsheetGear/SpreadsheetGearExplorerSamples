namespace SamplesLibrary.Samples.Workbook.Worksheet.Range.Formatting
{
    public class FontSample : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Create a new workbook.
            Workbook = SpreadsheetGear.Factory.GetWorkbook();
        }

        public void RunSample()
        {
            // Create some local variables to the active worksheet and its cells.
            SpreadsheetGear.IWorksheet worksheet = Workbook.ActiveWorksheet;
            SpreadsheetGear.IRange cells = worksheet.Cells;

            // Get a reference to cell B2.
            SpreadsheetGear.IRange cell = cells["B2"];

            // Add text to the cell.
            cell.Value = "SpreadsheetGear Engine for .NET";

            // Get a reference to the range's font.
            SpreadsheetGear.IFont font = cell.Font;

            // Set various font options.
            font.Name = "Times New Roman";
            font.Size = 14;
            font.Bold = true;
            font.Color = SpreadsheetGear.Colors.Blue;

            // AutoFit the column.
            cell.EntireColumn.AutoFit();
        }
    }
}
