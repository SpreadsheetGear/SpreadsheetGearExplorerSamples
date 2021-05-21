namespace SamplesLibrary.Samples.Reporting
{
    public class WorkbookConsolidationSample : ISpreadsheetGearWindowsSample
    {
        public void RunReport(IWorkbookView workbookView, string region)
        {
            // NOTE: Must acquire a workbook set lock.
            workbookView.GetLock();
            try
            {
                // Get the active workbook set of the WorkbookView, into which all workbooks will be 
                // created or opened.
                SpreadsheetGear.IWorkbookSet workbookSet = workbookView.ActiveWorkbookSet;

                SpreadsheetGear.IWorkbook workbook;
                if (region == "All")
                {
                    // Create a new workbook and name the first sheet.
                    workbook = workbookSet.Workbooks.Add();
                    SpreadsheetGear.IWorksheet worksheet = workbook.Worksheets[0];
                    worksheet.Name = "Total Sales";

                    // Copy all region templates to the new worksheet.
                    CopyRegion(worksheet, "East",
                        SpreadsheetGear.PasteOperation.None);
                    CopyRegion(worksheet, "West",
                        SpreadsheetGear.PasteOperation.Add);

                    // Auto size all worksheet columns which contain data.
                    worksheet.UsedRange.Columns.AutoFit();
                }
                else
                {
                    // Get a workbook for the selected region.
                    workbook = GetWorkbookForRegion(workbookSet, region);
                }

                // Set the new workbook as the active workbook.
                workbookView.ActiveWorkbook = workbook;
            }
            finally
            {
                // NOTE: Must release the workbook set lock.
                workbookView.ReleaseLock();
            }
        }

        private void CopyRegion(
            SpreadsheetGear.IWorksheet dstWorksheet,
            string region, SpreadsheetGear.PasteOperation pasteOperation)
        {
            // Open the specified region workbook and get the source range.
            SpreadsheetGear.IWorkbook srcWorkbook = GetWorkbookForRegion(dstWorksheet.WorkbookSet, region);
            SpreadsheetGear.IRange srcRange =
                srcWorkbook.Names["YearSales"].RefersToRange;

            // Set up our destination range to match the size of the source range.
            string address = srcRange.Address;
            SpreadsheetGear.IRange dstRange = dstWorksheet.Cells[address];

            // Copy the source range values and formats to the destination range.
            // We have to call copy twice here since there is currently no PasteType
            // which does values and all formats together. This is a limitaion in 
            // the Excel API, but probably should be added to the SpreadsheetGear API.
            srcRange.Copy(dstRange,
                SpreadsheetGear.PasteType.Values,
                pasteOperation, true, false);

            srcRange.Copy(dstRange,
                SpreadsheetGear.PasteType.Formats,
                pasteOperation, true, false);

            // Set the destination worksheet row heights to match the source range.
            dstWorksheet.Cells.RowHeight = srcRange.RowHeight;
        }

        private SpreadsheetGear.IWorkbook GetWorkbookForRegion(SpreadsheetGear.IWorkbookSet workbookSet, string region)
        {
            // Get the filename from the region name.
            string filename;
            switch (region)
            {
                case "East":
                default:
                    filename = @"Files\Windows\SpiceEast.xls";
                    break;
                case "West":
                    filename = @"Files\Windows\SpiceWest.xls";
                    break;
            }

            // Get the full path to the workbook file.
            string workbookPath = Helpers.GetFullOutputFolderPath(filename);

            // Return a workbook from the filename.
            return workbookSet.Workbooks.Open(workbookPath);
        }
    }
}
