namespace SamplesLibrary.Samples.Workbook.Worksheet.Range.ValuesAndFormulas
{
    class GoalSeekSample : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void PreLoadWorkbook()
        {
            // Get the full path to a workbook with some data that helps demonstrate Goal Seek.
            string workbookPath = Helpers.GetFullOutputFolderPath(@"Files\Engine\GoalSeek.xlsx");

            // Open the workbook.
            Workbook = SpreadsheetGear.Factory.GetWorkbook(workbookPath);
        }

        public void RunSample()
        {
            // Create some local variables to the active sheet and its cells.
            SpreadsheetGear.IWorksheet worksheet = Workbook.ActiveWorksheet;
            SpreadsheetGear.IRange cells = worksheet.Cells;

            // Get a reference to the target cell.
            SpreadsheetGear.IRange targetCell = worksheet.Cells["TargetCell"];

            // Get a reference to the cell to change.
            SpreadsheetGear.IRange changingCell = worksheet.Cells["ChangingCell"];

            // Set up the desired monthly payment.
            double goal = 1000.0;

            // Call GoalSeek which returns true if the desired goal is achieved.
            bool achieved = targetCell.GoalSeek(goal, changingCell);

            // Display the achieved status in the worksheet.
            worksheet.Cells["GoalSeekStatusCell"].Value = achieved ? "Achieved" : "Failed";
        }
    }
}
