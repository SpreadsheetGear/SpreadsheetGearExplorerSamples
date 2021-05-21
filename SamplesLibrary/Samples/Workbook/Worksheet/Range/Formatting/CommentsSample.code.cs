namespace SamplesLibrary.Samples.Workbook.Worksheet.Range.Formatting
{
    public class CommentsSample : ISpreadsheetGearEngineSample
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

            // Add a comment that pops up when the parent cell is hovered over.
            cells["A1"].AddComment("This is a comment.");
            cells["A1"].Value = "Hover over A1 to see comment.";

            // Add a comment that is visible by default.
            SpreadsheetGear.IComment comment = cells["A6"].AddComment("This comment is visible by default.");
            comment.Visible = true;
        }
    }
}
