namespace SamplesLibrary.Samples.Printing
{
    public class BasicPrintingSample : ISpreadsheetGearWindowsSample
    {
        public void Print(IWorkbookView workbookView, SpreadsheetGear.Printing.PrintWhat printWhat)
        {
            // NOTE: Must acquire a workbook set lock.
            workbookView.GetLock();
            try
            {
                // Print, displaying the print dialog before printing.
                workbookView.Print(printWhat, true);
            }
            finally
            {
                // NOTE: Must release the workbook set lock.
                workbookView.ReleaseLock();
            }
        }


        public void PrintPreview(IWorkbookView workbookView, SpreadsheetGear.Printing.PrintWhat printWhat)
        {
            // NOTE: Must acquire a workbook set lock.
            workbookView.GetLock();
            try
            {
                // Open up Windows' build-in Print Preview dialog.
                workbookView.PrintPreview(printWhat);
            }
            finally
            {
                // NOTE: Must release the workbook set lock.
                workbookView.ReleaseLock();
            }
        }


        public void InitializeSample(IWorkbookView workbookView)
        {
            // Get the full path to a workbook file.
            string workbookPath = Helpers.GetFullOutputFolderPath(@"Files\Windows\PrintingBasicRegions.xlsx");

            // Open workbook using the current culture.
            SpreadsheetGear.IWorkbook workbook = SpreadsheetGear.Factory.GetWorkbook(workbookPath,
                System.Globalization.CultureInfo.CurrentCulture);

            // Associate workbook with the WorkbookView control
            workbookView.ActiveWorkbook = workbook;
        }
    }
}
