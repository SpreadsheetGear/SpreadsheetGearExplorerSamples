namespace SamplesLibrary.Samples.Workbook.Worksheet.Range.ConditionalFormats
{
    public class ColorScaleSample : ISpreadsheetGearEngineSample
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
            cells["A1"].Formula = "Color Scale";

            // Get a reference to a range of cells.
            SpreadsheetGear.IRange range = cells["A2:A11"];

            // Load data and format as $ using multiple cell range.
            range.Formula = "=ROW() * 10 - 10";
            range.NumberFormat = "$#,##0_);($#,##0)";

            // Get a reference to the range's conditional formats collection.
            SpreadsheetGear.IFormatConditions conditions = range.FormatConditions;

            // Add color scale conditional format.
            SpreadsheetGear.IFormatCondition condition = conditions.AddColorScale(2);

            // Get a reference to the color scale.
            SpreadsheetGear.IColorScale colorScale = condition.ColorScale;

            // Set min and max scale values.
            colorScale.ColorScaleCriteria[0].Type = SpreadsheetGear.ConditionValueTypes.Number;
            colorScale.ColorScaleCriteria[0].Value = 0;
            colorScale.ColorScaleCriteria[1].Type = SpreadsheetGear.ConditionValueTypes.Number;
            colorScale.ColorScaleCriteria[1].Value = 100;
        }
    }
}
