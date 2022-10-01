namespace SamplesLibrary.Samples.Advanced
{
    public class PerformanceSample : ISpreadsheetGearWindowsSample
    {
        public void RunSample(SpreadsheetGear.IWorkbookSet workbookSet)
        {
            // Do a little benchmark to get the code JITed.
            RunBenchmark(workbookSet, 10);

            // Do the real benchmark which creates 100,000 rows by 4 columns.
            RunBenchmark(workbookSet, 100000);
        }

        private void RunBenchmark(SpreadsheetGear.IWorkbookSet workbookSet, int rowCount)
        {
            int rowCountForTest;

            // Acquire a workbook set lock.
            workbookSet.GetLock();
            try
            {
                // Ensure that the rowCount doesn't exceed the limits of the Signed License 
                // mode that these samples are running under.
                rowCountForTest = CheckRowLimit(workbookSet, rowCount);

                // Close any previous workbook from previous tests.
                workbookSet.Workbooks.Close();

                // Obtain decimal separator character used for this workbook set to properly
                // report pre-run benchmark values.
                string decimalSeparator = workbookSet.Culture.NumberFormat.NumberDecimalSeparator;

                // Create a new workbook.
                SpreadsheetGear.IWorkbook workbook = workbookSet.Workbooks.Add();

                // iter == 0 is the slow way.
                // iter == 1 is the fast way.
                for (int iter = 0; iter < 2; iter++)
                {
                    // Ger a worksheet and a working range.
                    SpreadsheetGear.IWorksheet worksheet = null;
                    switch (iter)
                    {
                        case 0:
                            worksheet = workbook.Worksheets[0];
                            worksheet.Name = "The Slow Way";
                            break;
                        case 1:
                            worksheet = workbook.Worksheets.Add();
                            worksheet.Name = "The Fast Way";
                            break;
                    }
                    SpreadsheetGear.IRange cells = worksheet.Cells;
                    SpreadsheetGear.IRange range = cells[0, 0, rowCountForTest - 1, 3];

                    // Must call System.GC.Collect() for consistent timing.
                    System.GC.Collect();

                    // Record start time.
                    long startTime = System.DateTime.Now.Ticks;

                    // Do the work.
                    switch (iter)
                    {
                        case 0:
                            RunSlow(range);
                            cells["F1"].Formula = string.Format("The slow way took 0{0}0097776 seconds on an Intel® Core™ " +
                                "i9-9900K CPU @ 3{0}60GHz, Release Build, Run Without Debugging.", decimalSeparator);
                            break;
                        case 1:
                            RunFast(range);
                            cells["F1"].Formula = string.Format("The fast way took 0{0}0004231 seconds on an Intel® Core™ " +
                                "i9-9900K CPU @ 3{0}60GHz, Release Build, Run Without Debugging.", decimalSeparator);
                            break;
                    }

                    // Save the elapsed time in cell A2.
                    System.TimeSpan elapsedTime = new System.TimeSpan(System.DateTime.Now.Ticks - startTime);
                    cells["F2"].Formula = "Elapsed time: " + (elapsedTime.TotalMilliseconds / 1000.0) + " seconds.";

                    // Inform the user if the row count was reduced due to the limited free mode that these samples by 
                    // default run under.
                    if (rowCount != rowCountForTest)
                    {
                        int maxLicensedRows = workbookSet.MaxLicensedRows;
                        cells["F3:M9"].Merge();
                        cells["F3"].Formula = $"These samples are operating in a 'free' mode which limits, among other " +
                            $"things, the maximum number of usable rows to {maxLicensedRows}.  This benchmark was modified " +
                            $"to use {maxLicensedRows} rows instead of {workbookSet.MaxRows} so as to not exceed this " +
                            $"limit.  If you are a licensed user of SpreadsheetGear, you can generate a Signed License to " +
                            $"activate the fully-licensed and unlimited mode.  If you are not a license user but would like " +
                            $"to evaluate unlimited mode of SpreadsheetGear, you can generate a Trial Signed License to " +
                            $"unlock the unlimited mode free for 30 days.  Links to each page are provided below.";
                        cells["F3"].WrapText = true;
                        cells["F3"].Font.Bold = true;
                        cells["F3"].Font.Color = SpreadsheetGear.Colors.Crimson;
                        worksheet.Hyperlinks.Add(cells["F10"], "https://www.spreadsheetgear.com/Downloads/Licensed", 
                            null, null, "Licensed User Downloads");
                        worksheet.Hyperlinks.Add(cells["F11"], "https://www.spreadsheetgear.com/Downloads/Evaluation",
                            null, null, "Evaluation User Downloads");
                    }
                }
            }
            finally
            {
                // Release the workbook set lock.
                workbookSet.ReleaseLock();
            }
        }

        private void RunSlow(SpreadsheetGear.IRange range)
        {
            // Obtain CultureInfo object used for this range's workbook set.
            System.Globalization.CultureInfo culture = range.WorkbookSet.Culture;

            for (int row = 0; row < range.RowCount; row++)
            {
                // Set some text in column A, numbers in columns B and C and a formula in column D.
                range[row, 0].Value = "Row" + row;
                range[row, 1].Value = row;
                range[row, 2].Value = row * 2;
                range[row, 3].Formula = "=SUM(" + range.WorkbookSet.GetAddress(row + range.Row, 1, row + range.Row, 2,
                    0, 0, false, false, false, false, false, SpreadsheetGear.ReferenceStyle.A1) + ")";

                // Set a number format on the numeric cells.
                range[row, 1, row, 3].NumberFormat = "#" + culture.NumberFormat.NumberGroupSeparator + "##0";

                // Format every other row with a gray background.
                if ((row & 1) == 0)
                    range[row, 0, row, 3].Interior.Color = SpreadsheetGear.Colors.LightGray;
            }
        }

        private void RunFast(SpreadsheetGear.IRange range)
        {
            // Obtain CultureInfo object used for this workbook set
            System.Globalization.CultureInfo culture = range.WorkbookSet.Culture;

            // Get the IValues interface.
            SpreadsheetGear.Advanced.Cells.IValues values =
                (SpreadsheetGear.Advanced.Cells.IValues)range.Worksheet;

            // Get the starting row and row count.
            int startRow = range.Row;
            int rowCount = range.RowCount;

            // Loop through - but set the formula and the format once after looping.
            for (int row = 0; row < rowCount; row++)
            {
                // Set some text in column A, numbers in columns B and C.
                values.SetText(row + startRow, 0, "Row" + row);
                values.SetNumber(row + startRow, 1, row);
                values.SetNumber(row + startRow, 2, row * 2);
            }

            // Set a formula in Column D all at once which is much faster since the
            // formula is only created once and only parsed once.
            range[0, 3, rowCount - 1, 3].Formula = "=SUM(" + range.WorkbookSet.GetAddress(startRow, 1, startRow, 2,
                0, 0, false, false, false, false, false, SpreadsheetGear.ReferenceStyle.A1) + ")";

            // Set a number format on the numeric cells - much faster than one row at a time.
            range[0, 1, rowCount - 1, 3].NumberFormat = "#" + culture.NumberFormat.NumberGroupSeparator + "##0";

            // Create formula, using appropriate ListSeparator for the current Culture, for the conditional format below.
            string formula = "=MOD(ROW()" + culture.TextInfo.ListSeparator + "2)=0";

            // Format every other row with a gray background using one conditional format.
            SpreadsheetGear.IFormatCondition formatCondition =
                range.FormatConditions.Add(SpreadsheetGear.FormatConditionType.Expression,
                SpreadsheetGear.FormatConditionOperator.None, formula, "");
            formatCondition.Interior.Color = SpreadsheetGear.Colors.LightGray;
        }


        private int CheckRowLimit(SpreadsheetGear.IWorkbookSet workbookSet, int rowCount)
        {
            return System.Math.Min(rowCount, workbookSet.MaxLicensedRows);
        }
    }
}
