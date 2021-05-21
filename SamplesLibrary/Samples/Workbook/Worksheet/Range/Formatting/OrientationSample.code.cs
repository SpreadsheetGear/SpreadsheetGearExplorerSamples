namespace SamplesLibrary.Samples.Workbook.Worksheet.Range.Formatting
{
    public class OrientationSample : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Get the full path to a workbook with some data that we can apply text orientation.
            string workbookPath = Helpers.GetFullOutputFolderPath(@"Files\Engine\OrientationSampleData.xlsx");

            // Open the workbook.
            Workbook = SpreadsheetGear.Factory.GetWorkbook(workbookPath);
        }

        public void RunSample()
        {
            // Create some local variables to the active worksheet and its cells.
            SpreadsheetGear.IWorksheet worksheet = Workbook.ActiveWorksheet;
            SpreadsheetGear.IRange cells = worksheet.Cells;

            // Get a reference to the range whose text orientation will be changed.
            SpreadsheetGear.IRange range = cells["D2:W2"];

            // Set the text orientation for a better fit.
            range.Orientation = 65;
        }
    }
}
