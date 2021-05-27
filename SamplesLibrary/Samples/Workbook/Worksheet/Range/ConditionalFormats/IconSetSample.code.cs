namespace SamplesLibrary.Samples.Workbook.Worksheet.Range.ConditionalFormats
{
    public class IconSetSample : ISpreadsheetGearEngineSample
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
            cells["A1"].Formula = "Icon Set";

            // Get a reference to a range of cells.
            SpreadsheetGear.IRange range = cells["A2:A11"];

            // Load random data and format as $ using multiple cell range.
            range.Formula = "=RAND() * 10000";
            range.NumberFormat = "$#,##0_);($#,##0)";

            // Get a reference to the range's conditional formats collection.
            SpreadsheetGear.IFormatConditions conditions = range.FormatConditions;

            // Add icon set conditional format.
            SpreadsheetGear.IFormatCondition condition = conditions.AddIconSetCondition();

            // Get a reference to the icon set condition.
            SpreadsheetGear.IIconSetCondition iconSet = condition.IconSetCondition;

            // Set the icon set type.
            iconSet.IconSet = Workbook.IconSets[SpreadsheetGear.IconSet.FiveArrows];

            // AutoFit the column.
            range.EntireColumn.AutoFit();
        }
    }
}
