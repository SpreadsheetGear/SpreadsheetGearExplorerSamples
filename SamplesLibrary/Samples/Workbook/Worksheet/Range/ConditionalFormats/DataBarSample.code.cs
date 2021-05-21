namespace SamplesLibrary.Samples.Workbook.Worksheet.Range.ConditionalFormats
{
    public class DataBarSample : ISpreadsheetGearEngineSample
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
            cells["A1"].Formula = "Data Bar";

            // Get a reference to a range of cells.
            SpreadsheetGear.IRange range = cells["A2:A11"];

            // Load data and format as $ using multiple cell range.
            range.Formula = "=ROW() * 10 - 10";
            range.NumberFormat = "$#,##0_);($#,##0)";

            // Get a reference to the range's conditional formats collection.
            SpreadsheetGear.IFormatConditions conditions = range.FormatConditions;

            // Add data bar conditional format.
            SpreadsheetGear.IFormatCondition condition = conditions.AddDatabar();

            // Get a reference to the data bar condition.
            SpreadsheetGear.IDatabar dataBar = condition.Databar;

            // Get a reference to the data bar border and apply formatting.
            SpreadsheetGear.IDataBarBorder barBorder = dataBar.BarBorder;
            barBorder.Type = SpreadsheetGear.DataBarBorderType.Solid;
            barBorder.Color.ThemeColor = SpreadsheetGear.Themes.ColorSchemeIndex.Accent1;

            // Set min and max scale values.
            dataBar.MinPoint.Modify(SpreadsheetGear.ConditionValueTypes.Number, 0);
            dataBar.MaxPoint.Modify(SpreadsheetGear.ConditionValueTypes.Number, 100);
        }
    }
}
