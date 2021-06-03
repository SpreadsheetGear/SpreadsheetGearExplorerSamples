namespace SamplesLibrary.Samples.Workbook.Worksheet
{
    public class SheetVisibilitySample : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Create a new workbook with 3 worksheets.
            Workbook = SpreadsheetGear.Factory.GetWorkbook();
            Workbook.Worksheets.Add();
            Workbook.Worksheets.Add();
        }

        public void RunSample()
        {
            // A Hidden state will exclude this sheet from the tab bar, but will still make this 
            // entry visible in Excel's "Unhide Sheet..." dialog and SpreadsheetGear's WorkbookExplorer, 
            // giving the end-user a change to unhide it.
            Workbook.Worksheets["Sheet1"].Visible = SpreadsheetGear.SheetVisibility.Hidden;

            // A VeryHidden state excludes the sheet from both the tab bar and Excel and SpreadsheetGear's 
            // dialogs, effectively making it impossible for an end-user to unhide the sheet on their own 
            // (except in Excel where an experienced user could use VBA to unhide the sheet).
            Workbook.Worksheets["Sheet2"].Visible = SpreadsheetGear.SheetVisibility.VeryHidden;

            // Note about how to view more information about the results.
            Workbook.ActiveWorksheet.Cells["A1:F6"].Merge();
            Workbook.ActiveWorksheet.Cells["A1:F6"].WrapText = true;
            Workbook.ActiveWorksheet.Cells["A1"].Value = "Right-click on the WorkbookView and select the " +
                "'Workbook Explorer...' context menu option.  In the TreeView on the left pane, expand [Book1] " +
                "to view available worksheets and note that 'Sheet2' is not listed because it is 'VeryHidden'.  " +
                "Sheet1 is listed because it is 'Hidden', and could be made visible again from this dialog.";
        }
    }
}
