namespace SamplesLibrary.Samples.Workbook.Worksheet.Range.Formatting
{
    public class RichTextSample : ISpreadsheetGearEngineSample
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

            // Set font size for entire text to 24 points.
            cell.Font.Size = 24;

            // Set "Spreadsheet" text to dark blue.
            SpreadsheetGear.ICharacters spreadsheetChars = cell.GetCharacters(0, 11);
            spreadsheetChars.Font.Color = SpreadsheetGear.Color.FromArgb(255, 0, 0, 128);

            // Set "Gear" text to a shade of red.
            SpreadsheetGear.ICharacters gearChars = cell.GetCharacters(11, 4);
            gearChars.Font.Color = SpreadsheetGear.Color.FromArgb(255, 233, 14, 14);

            // Set "Engine" text style.
            SpreadsheetGear.ICharacters engineChars = cell.GetCharacters(16, 6);
            engineChars.Font.Bold = true;

            // Set "for" text style.
            SpreadsheetGear.ICharacters forChars = cell.GetCharacters(23, 3);
            forChars.Font.Underline = SpreadsheetGear.UnderlineStyle.Single;

            // Set ".NET Standard" text style.
            SpreadsheetGear.ICharacters netStandardChars = cell.GetCharacters(27, 4);
            netStandardChars.Font.Italic = true;

            // AutoFit the column.
            cell.EntireColumn.AutoFit();
        }
    }
}
