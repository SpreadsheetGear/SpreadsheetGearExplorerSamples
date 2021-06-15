namespace SamplesLibrary.Samples.WorkboookView.DisplayOptions
{
    public class DisplayReferenceSample : ISpreadsheetGearWindowsSample
    {
        public void InitializeSample(IWorkbookView workbookView)
        {
            // Create a workbook set using this machine's current localization settings.
            var workbookSet = SpreadsheetGear.Factory.GetWorkbookSet(System.Globalization.CultureInfo.CurrentCulture);

            // Add a workbook to the workbook set, which will have a few sheets and where the second sheet index has 
            // the name "My Worksheet".
            var workbook1 = workbookSet.Workbooks.Add();
            workbook1.Worksheets.Add();
            workbook1.Worksheets.Add();
            workbook1.FullName = "Book1";
            workbook1.Worksheets[1].Name = "My Worksheet";

            // Add a workbook that has a Defined Name with the name "MyName".
            var workbook2 = workbookSet.Workbooks.Add();
            workbook2.Worksheets.Add();
            workbook2.Worksheets.Add();
            workbook2.FullName = "Book2";
            workbook2.Names.Add("MyName", "=Sheet1!$A$1:$A$10");

            // Get the full path to a workbook file that contains 4 sheets (North, South, East, West).
            string workbookPath = Helpers.GetFullOutputFolderPath(@"Files\Windows\DisplayReferenceRegions.xlsx");

            // Open the workbook.
            var workbook4 = workbookSet.Workbooks.Open(workbookPath);
            workbook4.FullName = "Book3";

            // Attach workbookSet containing the above workbooks to the WorkbookView
            workbookView.ActiveWorkbookSet = workbookSet;
        }

        public void UpdateDisplayReference(IWorkbookView workbookView, string displayReferenceType)
        {
            workbookView.GetLock();
            try
            {
                // Obtain CultureInfo object used for the workbook set associated with this WorkbookView.
                // This is the delimiter used to separate items in the DisplayReference.
                string listSeparator = workbookView.ActiveWorkbookSet.Culture.TextInfo.ListSeparator;

                if (displayReferenceType == "Workbook")
                {
                    // Change the display reference to an entire workbook.
                    workbookView.DisplayReference = "Book2";
                    workbookView.DisplayReferenceName = null;
                }

                else if (displayReferenceType == "Worksheet")
                {
                    // Change the display reference to an entire worksheet.
                    //
                    // Note that this sample uses single quotes around the reference 
                    // because the sheet name has a space in it.
                    workbookView.DisplayReference = "'[Book1]My Worksheet'!A:XFD";

                    // Change the text displayed in the WorkbookView tabs.
                    workbookView.DisplayReferenceName = "\"My Worksheet Tab\"";
                }

                else if (displayReferenceType == "Range")
                {
                    // Change the display reference to a single range.
                    workbookView.DisplayReference = "[Book1]Sheet1!A1:E8";

                    // Change the text displayed in the WorkbookView tabs.
                    workbookView.DisplayReferenceName = "\"My Range\"";
                }

                else if (displayReferenceType == "Defined Name")
                {
                    // Change the display reference to a defined name.
                    workbookView.DisplayReference = "Book2!MyName";

                    // Change the text displayed in the WorkbookView tabs.
                    workbookView.DisplayReferenceName = "\"My Defined Name\"";
                }

                else if (displayReferenceType == "Multiple Ranges")
                {
                    // Change the display reference to multiple ranges.
                    workbookView.DisplayReference =
                        $"[Book1]Sheet1!A1:D5{listSeparator}[Book1]Sheet1!4:6{listSeparator}[Book1]Sheet1!D:F";

                    // Change the text displayed in the WorkbookView tabs.
                    workbookView.DisplayReferenceName =
                        $"\"My Range1\"{listSeparator}\"My Range2\"{listSeparator}\"My Range3\"";
                }

                else if (displayReferenceType == "Used Ranges")
                {
                    // Get a reference to a workbook.
                    SpreadsheetGear.IWorkbook workbook =
                        workbookView.ActiveWorkbookSet.Workbooks["Book3"];

                    // Get a reference to the workbook's worksheet collection.
                    SpreadsheetGear.IWorksheets worksheets = workbook.Worksheets;

                    // Get the name of the workbook.
                    string bookName = workbook.Name;

                    // Get the last sheet index.
                    int lastSheetIndex = worksheets.Count - 1;

                    // Initialize the display reference variable.
                    string displayReference = "";

                    // Dynamically build a display reference which will include
                    // the used portion of all worksheets in the workbook.
                    for (int sheetIndex = 0; sheetIndex <= lastSheetIndex; sheetIndex++)
                    {
                        // Get a reference to the worksheet at the specified index.
                        SpreadsheetGear.IWorksheet worksheet = worksheets[sheetIndex];

                        // Get a reference to the used area of the worksheet.
                        SpreadsheetGear.IRange usedRange = worksheet.UsedRange;

                        // Get the name of the worksheet.
                        string sheetName = worksheet.Name;

                        // Get the range address of the used range.
                        string rangeName = usedRange.Address;

                        // Append the information to the display reference.
                        displayReference += "'[" + bookName + "]" + sheetName + "'!" + rangeName;

                        // Add a separator if there are more ranges to add.
                        if (sheetIndex < lastSheetIndex)
                            displayReference += listSeparator;
                    }

                    // Set the display reference.
                    workbookView.DisplayReference = displayReference;

                    // Clear display names so that the actual worksheet names are used.
                    workbookView.DisplayReferenceName = null;
                }
            }
            finally
            {
                workbookView.ReleaseLock();
            }
        }
    }
}
