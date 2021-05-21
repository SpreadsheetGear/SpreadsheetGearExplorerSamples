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

                // Get a reference to the workbook's worksheet collection.
                SpreadsheetGear.IWorksheets worksheets = workbook.Worksheets;

                // Add a new worksheet to the end of the collection.
                worksheets.Add();

                // Add a new worksheet after the first worksheet.
                worksheets.AddAfter(worksheets[0]);

                // Add a new worksheet before the first worksheet.
                worksheets.AddBefore(worksheets[0]);

                // Display the last worksheet in the WorkbookView.
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
