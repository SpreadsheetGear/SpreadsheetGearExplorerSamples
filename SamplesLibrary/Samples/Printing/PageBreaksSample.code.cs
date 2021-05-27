namespace SamplesLibrary.Samples.Printing
{
    public class PageBreaksSample : ISpreadsheetGearWindowsSample
    {
        public void Print(IWorkbookView workbookView, bool addPageBreaks)
        {
            // NOTE: Must acquire a workbook set lock.
            workbookView.GetLock();
            try
            {
                // Get a reference to the active worksheet's cells.
                SpreadsheetGear.IRange cells = workbookView.ActiveWorksheet.Cells;

                // If page breaks should be added...
                if (addPageBreaks)
                {
                    // Add manual page breaks above and to the left of a named range.
                    cells["West"].PageBreak = SpreadsheetGear.PageBreak.Manual;
                }
                else
                {
                    // Remove all page breaks from all worksheet cells.
                    cells.PageBreak = SpreadsheetGear.PageBreak.None;
                }

                // Print, displaying the print preview dialog before printing.
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
            string workbookPath = Helpers.GetFullOutputFolderPath(@"Files\Windows\PrintingPageBreaks.xlsx");

            // Open workbook using the current culture.
            SpreadsheetGear.IWorkbook workbook = SpreadsheetGear.Factory.GetWorkbook(workbookPath,
                System.Globalization.CultureInfo.CurrentCulture);

            // Associate workbook with the WorkbookView control
            workbookView.ActiveWorkbook = workbook;
        }
    }
}
