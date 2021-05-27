namespace SamplesLibrary.Samples.Printing
{
    public class PageSetupSample : ISpreadsheetGearWindowsSample
    {
        public void PrintPreview(IWorkbookView workbookView)
        {
            // NOTE: Must acquire a workbook set lock.
            workbookView.GetLock();
            try
            {
                // Get a reference to the active worksheet.
                SpreadsheetGear.IWorksheet worksheet = workbookView.ActiveWorksheet;

                // Get a reference to the worksheet's page setup.
                SpreadsheetGear.IPageSetup pageSetup = worksheet.PageSetup;

                // Set the area of the worksheet to print.
                pageSetup.PrintArea = "B1:G39";

                // Scale printed output to 1 page tall by 1 page wide.
                pageSetup.FitToPages = true;
                pageSetup.FitToPagesTall = 1;
                pageSetup.FitToPagesWide = 1;

                // Horizontally center printed pages.
                pageSetup.CenterHorizontally = true;

                // Set the page orientation.
                pageSetup.Orientation = SpreadsheetGear.PageOrientation.Portrait;

                // Set page margins to 1 inch (72 points per inch)
                pageSetup.BottomMargin = 72;
                pageSetup.LeftMargin = 72;
                pageSetup.RightMargin = 72;
                pageSetup.TopMargin = 72;

                // Set custom center header text using the specified font name and size.
                pageSetup.CenterHeader = "&\"Times New Roman\"&16ABC Company Sales for 2009";

                // Set right footer to display default date and time.
                pageSetup.RightFooter = "&D &T";

                // Launch Print Preview dialog with the active worksheet with the page setup option we set above.
                workbookView.PrintPreview();
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
            string workbookPath = Helpers.GetFullOutputFolderPath(@"Files\Windows\PrintingPageSetup.xlsx");

            // Open workbook using the current culture.
            SpreadsheetGear.IWorkbook workbook = SpreadsheetGear.Factory.GetWorkbook(workbookPath,
                System.Globalization.CultureInfo.CurrentCulture);

            // Associate workbook with the WorkbookView control
            workbookView.ActiveWorkbook = workbook;
        }
    }
}
