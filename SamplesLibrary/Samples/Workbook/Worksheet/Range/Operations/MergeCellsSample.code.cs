namespace SamplesLibrary.Samples.Workbook.Worksheet.Range.Operations
{
    public class MergeCellsSample : ISpreadsheetGearEngineSample
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

            // Get reference to range to merge.
            SpreadsheetGear.IRange range = cells["B2:E5"];

            // Merge the range.
            range.Merge();

            // Center horizontally and vertically.
            range.HorizontalAlignment = SpreadsheetGear.HAlign.Center;
            range.VerticalAlignment = SpreadsheetGear.VAlign.Center;

            // Set the text of the merged cells.
            range.Value = "Merged Cells";
        }
    }
}
