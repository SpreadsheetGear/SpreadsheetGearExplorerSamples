namespace SamplesLibrary.Samples.Workbook.Worksheet.Range.ConditionalFormats
{
    public class CellValueSample : ISpreadsheetGearEngineSample
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
            cells["A1"].Formula = "Cell Value";

            // Get a reference to a range of cells.
            SpreadsheetGear.IRange range = cells["A2:A11"];

            // Load random data and format as $ using multiple cell range.
            range.Formula = "=RAND() * 10000";
            range.NumberFormat = "$#,##0_);($#,##0)";

            // Get a reference to the range's conditional formats collection.
            SpreadsheetGear.IFormatConditions conditions = range.FormatConditions;

            // Add a conditional format for values less than or equal to 7000.
            SpreadsheetGear.IFormatCondition condition = conditions.Add(
                SpreadsheetGear.FormatConditionType.CellValue,
                SpreadsheetGear.FormatConditionOperator.LessEqual, "7000", null);

            // Set font and interior formatting options.
            condition.Font.Bold = false;
            condition.Font.Color = SpreadsheetGear.Colors.White;
            condition.Interior.Color = SpreadsheetGear.Colors.DarkSlateBlue;

            // Add a conditional format for values greater than 7000.
            condition = conditions.Add(
                SpreadsheetGear.FormatConditionType.CellValue,
                SpreadsheetGear.FormatConditionOperator.Greater, "7000", null);

            // Set font and interior formatting options.
            condition.Font.Bold = true;
            condition.Font.Italic = true;
            condition.Font.Color = SpreadsheetGear.Colors.White;
            condition.Interior.Color = SpreadsheetGear.Colors.Maroon;
        }
    }
}
