namespace SamplesLibrary.Samples.Workbook.Worksheet.Range.ConditionalFormats
{
    public class AlternatingRowColorsSample : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Get the full path to a workbook template file with a data range that needs formatting. 
            string workbookPath = Helpers.GetFullOutputFolderPath(@"Files\Engine\AlternatingRowColorSampleData.xlsx");

            // Open the workbook.
            Workbook = SpreadsheetGear.Factory.GetWorkbook(workbookPath);
        }

        public void RunSample()
        {
            // Create a local variable to the active worksheet.
            SpreadsheetGear.IWorksheet worksheet = Workbook.ActiveWorksheet;

            // Get range that Conditional Formatting will be applied to.
            SpreadsheetGear.IRange dataRange = worksheet.Cells["A2:D15"];

            // Apply a uniform Theme Color and TintAndShade to the entire data range.
            dataRange.Interior.ThemeColor = SpreadsheetGear.Themes.ColorSchemeIndex.Accent6;
            dataRange.Interior.TintAndShade = 0.6; // 60% lighter

            // Create an Expression-based conditional format, using the MOD(...) and ROW() 
            // functions to alternate true/false values for each row of the data range.
            SpreadsheetGear.IFormatCondition cf = dataRange.FormatConditions.Add(
                SpreadsheetGear.FormatConditionType.Expression,
                SpreadsheetGear.FormatConditionOperator.None, "=MOD(ROW(),2)=0", null);

            // For every other row, apply the same Theme Color but slightly lighter TintAndShade.
            cf.Interior.ThemeColor = SpreadsheetGear.Themes.ColorSchemeIndex.Accent6;
            cf.Interior.TintAndShade = 0.8;  // 80% lighter
        }
    }
}
