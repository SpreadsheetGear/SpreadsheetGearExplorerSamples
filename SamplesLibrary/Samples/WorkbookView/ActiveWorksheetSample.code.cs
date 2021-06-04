namespace SamplesLibrary.Samples.WorkboookView
{
    public class ActiveWorksheetSample : ISpreadsheetGearWindowsSample
    {
        public void SetActiveWorksheet(IWorkbookView workbookView)
        {
            // NOTE: Must acquire a workbook set lock.
            workbookView.GetLock();
            try
            {
                // Get a reference to the active workbook.
                SpreadsheetGear.IWorkbook workbook = workbookView.ActiveWorkbook;

                // Get a reference to the workbook's worksheet collection, which contains 
                // a single "Sheet1".
                SpreadsheetGear.IWorksheets worksheets = workbook.Worksheets;

                // Add a new worksheet to the end of the collection. New order of sheets is:
                // Sheet1, Sheet2
                worksheets.Add();

                // Add a new worksheet after the first worksheet.  New order of sheets is:
                // Sheet1, Sheet3, Sheet2
                worksheets.AddAfter(worksheets[0]);

                // Add a new worksheet before the first worksheet.  New order of sheets is:
                // Sheet4, Sheet1, Sheet3, Sheet2
                worksheets.AddBefore(worksheets[0]);

                // Display the last worksheet in the WorkbookView (Sheet2).
                workbookView.ActiveWorksheet = worksheets[worksheets.Count - 1];
            }
            finally
            {
                // NOTE: Must release the workbook set lock.
                workbookView.ReleaseLock();
            }
        }
    }
}
