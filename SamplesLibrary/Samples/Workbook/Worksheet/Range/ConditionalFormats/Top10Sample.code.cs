namespace SamplesLibrary.Samples.Workbook.Worksheet.Range.ConditionalFormats
{
    public class Top10Sample : ISpreadsheetGearEngineSample
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

            // Add a title to a cell.
            cells["A1"].Formula = "Top 10";

            // Get a reference to a range of cells.
            SpreadsheetGear.IRange range = cells["A2:A11"];

            // Load random data and format as $ using multiple cell range.
            range.Formula = "=RAND() * 10000";
            range.NumberFormat = "$#,##0_);($#,##0)";

            // Get a reference to the range's conditional formats collection.
            SpreadsheetGear.IFormatConditions conditions = range.FormatConditions;

            // Add Top 10 conditional format.
            SpreadsheetGear.IFormatCondition condition = conditions.AddTop10();

            // Get a reference to the Top 10 condition.
            SpreadsheetGear.ITop10 top10 = condition.Top10;

            // Set the rank to only format the top 2 values.
            top10.Rank = 2;

            // Set font and interior formatting options.
            condition.Font.Bold = true;
            condition.Font.Italic = true;
            condition.Font.Color = SpreadsheetGear.Colors.White;
            condition.Interior.Color = SpreadsheetGear.Colors.Green;
        }
    }
}
