namespace SamplesLibrary.Samples.Workbook.Worksheet.Range.ConditionalFormats
{
    public class CustomExpressionSample : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Get the full path to a workbook template file with a data range that will be formatted with a 
            // conditional format. 
            string workbookPath = Helpers.GetFullOutputFolderPath(@"Files\Engine\CustomExpressionSampleData.xlsx");

            // Open the workbook.
            Workbook = SpreadsheetGear.Factory.GetWorkbook(workbookPath);
        }

        public void RunSample()
        {
            // Create a local variable to the active worksheet.
            SpreadsheetGear.IWorksheet worksheet = Workbook.ActiveWorksheet;

            // Get range that Conditional Formatting will be applied to.
            SpreadsheetGear.IRange dataRange = worksheet.Cells["A2:B25"];

            // Create an Expression-based conditional format that locates any release date
            // in November.  Note the column reference is absolute ('$B') whereas the row column
            // is relative ('2' and not '$2'), which will cause the expression to evaluate the
            // same across each row based on the value in Column B.
            SpreadsheetGear.IFormatCondition cf = dataRange.FormatConditions.Add(
                SpreadsheetGear.FormatConditionType.Expression,
                SpreadsheetGear.FormatConditionOperator.None, @"=ISNUMBER(SEARCH(""November"",$B2))",
                null);

            // For every other row, apply a highlight-like Theme Color
            cf.Interior.ThemeColor = SpreadsheetGear.Themes.ColorSchemeIndex.Accent4;
            cf.Interior.TintAndShade = 0.8;  // 80% lighter
        }
    }
}
