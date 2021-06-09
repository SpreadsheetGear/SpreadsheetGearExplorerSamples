namespace SamplesLibrary.Samples.Workbook.Worksheet.Range.Operations
{
    public class LockAndProtectCellsSample : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Create a new workbook.
            Workbook = SpreadsheetGear.Factory.GetWorkbook();
        }

        public void RunSample()
        {
            // SAMPLE 1: Protect Sheet1 without a password.
            {
                // Get reference to Sheet1 and local variable to its cells.
                SpreadsheetGear.IWorksheet worksheet = Workbook.Worksheets["Sheet1"];
                SpreadsheetGear.IRange cells = worksheet.Cells;

                // Add a couple of labels and AutoFit the column.
                cells["A1"].Value = "Row 1 is not locked - you can edit this cell.";
                cells["A2"].Value = "All other rows are locked - you cannot edit this cell.";
                cells["A3"].Value = "This sheet is not protected with a password.";
                cells["A1:A2"].Columns.AutoFit();

                // Get a reference to available cells in Row 1.  These samples run in a limited free mode
                // and so the maximum licensed rows may be different from the normal file format limits.
                SpreadsheetGear.IRange row1 = cells[0, 0, 0, Workbook.WorkbookSet.MaxLicensedColumns - 1];

                // Unlock the range of cells. (NOTE: Cells are locked by default)
                row1.Locked = false;

                // Enable protection for the worksheet.
                worksheet.ProtectContents = true;
            }

            // SAMPLE 2: Protect Sheet2 with a password.
            {
                // Add a second worksheet to the workbook and get local variable to its cells.
                SpreadsheetGear.IWorksheet worksheet = Workbook.Worksheets.Add();
                SpreadsheetGear.IRange cells = worksheet.Cells;

                // Add a couple of labels and AutoFit the column.
                cells["A1"].Value = "Row 1 is not locked - you can edit this cell.";
                cells["A2"].Value = "All other rows are locked - you cannot edit this cell.";
                cells["A3"].Value = "This sheet is protected with a password.";
                cells["A1:A2"].Columns.AutoFit();

                // Get a reference to available cells in Row 1.  These samples run in a limited free mode
                // and so the maximum licensed rows may be different from the normal file format limits.
                SpreadsheetGear.IRange row1 = cells[0, 0, 0, Workbook.WorkbookSet.MaxLicensedColumns - 1];

                // Unlock the range of cells. (NOTE: Cells are locked by default)
                row1.Locked = false;

                // Enable protection for the worksheet.
                worksheet.Protect("MyPassword");
            }
        }
    }
}
