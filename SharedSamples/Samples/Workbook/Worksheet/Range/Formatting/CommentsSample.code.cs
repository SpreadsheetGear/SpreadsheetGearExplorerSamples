namespace SharedSamples.Samples.Workbook.Worksheet.Range.Formatting
{
    public class CommentsSample : SharedEngineSample
    {
        public override void PreLoadWorkbook()
        {
            // Create a new workbook.
            Workbook = SpreadsheetGear.Factory.GetWorkbook();
        }

        public override void RunSample()
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
