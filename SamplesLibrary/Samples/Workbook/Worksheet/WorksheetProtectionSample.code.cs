namespace SamplesLibrary.Samples.Workbook.Worksheet
{
    public class WorksheetProtectionSample : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Get the full path to a workbook that will demonstrate how certain aspects of a worksheet can
            // still be enabled when worksheet protection is enabled.
            string workbookPath = Helpers.GetFullOutputFolderPath(@"Files\Engine\WorksheetProtection.xlsx");

            // Open the workbook.
            Workbook = SpreadsheetGear.Factory.GetWorkbook(workbookPath);
        }

        public void RunSample()
        {
            // Create a local variable to the active worksheet.
            SpreadsheetGear.IWorksheet worksheet = Workbook.ActiveWorksheet;

            // The Protect(...) method provides full control over the various options you can use
            // to protect a worksheet.  You can provide an optional first parameter for the 
            // worksheet password.  All additional parameters are also optional, and are setup 
            // below using their default values. 
            worksheet.Protect(
                password: "MyPassword1234",
                protectDrawingObjects: true,
                protectContents: true,
                protectScenarios: true,
                userInterfaceOnly: false,
                allowFormattingCells: false,
                allowFormattingColumns: false,
                allowFormattingRows: false,
                allowInsertingColumns: false,
                allowInsertingRows: false,
                allowInsertingHyperlinks: false,
                allowDeletingColumns: false,
                allowDeletingRows: false,
                allowSorting: false,
                allowFiltering: false,
                allowUsingPivotTables: false
            );

            // Unprotect a worksheet with a password.
            worksheet.Unprotect("MyPassword1234");

            // Enables worksheet protection but without a password.
            worksheet.ProtectContents = true;

            // Modify the various aspects of a worksheet that should be protected with the 
            // IProtection interface.
            SpreadsheetGear.IProtection protectOptions = worksheet.Protection;
            protectOptions.AllowFormattingCells = false;
            protectOptions.AllowFormattingColumns = false;
            // ... See documentation or use IntelliSense for additional options...

            // Prevent IRange.Locked == true cells from being selected.
            worksheet.EnableSelection = SpreadsheetGear.EnableSelection.UnlockedCells;

            // Enable this property to allow programmatic changes to still be made to a 
            // worksheet even when worksheet protection is enabled.  UI protection is still 
            // enforced.
            worksheet.ProtectionMode = true;
            worksheet.Cells["A6"].Value = "This cell was modified while worksheet " +
                "protection was enabled because IWorksheet.ProtectionMode was set to true.";
        }
    }
}
