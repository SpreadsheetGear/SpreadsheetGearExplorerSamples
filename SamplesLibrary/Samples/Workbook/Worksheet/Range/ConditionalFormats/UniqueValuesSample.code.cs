namespace SamplesLibrary.Samples.Workbook.Worksheet.Range.ConditionalFormats
{
    public class UniqueValuesSample : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Create a new workbook.
            Workbook = SpreadsheetGear.Factory.GetWorkbook();
        }

        public void RunSample()
        {// Create some local variables to the active worksheet and its cells.
            SpreadsheetGear.IWorksheet worksheet = Workbook.ActiveWorksheet;
            SpreadsheetGear.IRange cells = worksheet.Cells;

            // Add a title to a cell.
            cells["A1"].Formula = "Unique Values";

            // Get a reference to a range of cells.
            SpreadsheetGear.IRange range = cells["A2:A11"];

            // Load random data and format as $ using multiple cell range.
            range.Formula = "=RAND() * 1000";
            range.NumberFormat = "$#,##0_);($#,##0)";

            // Set some duplicate values.
            range[2, 0].Value = 100;
            range[5, 0].Value = 100;

            // Get a reference to the range's conditional formats collection.
            SpreadsheetGear.IFormatConditions conditions = range.FormatConditions;

            // Add unique values conditional format.
            SpreadsheetGear.IFormatCondition condition = conditions.AddUniqueValues();

            // Get a reference to the unique values condition.
            SpreadsheetGear.IUniqueValues uniqueValues = condition.UniqueValues;

            // Display formatting for values that are duplicates.
            uniqueValues.DupeUnique = SpreadsheetGear.DupeUnique.Duplicate;

            // Set font and interior formatting options.
            condition.Font.Bold = true;
            condition.Font.Italic = true;
            condition.Interior.Color = SpreadsheetGear.Colors.LightSalmon;
        }
    }
}
