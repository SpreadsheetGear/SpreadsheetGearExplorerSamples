namespace SamplesLibrary.Samples.Workbook.Worksheet.Range.Operations
{
    public class SortingSample : ISpreadsheetGearEngineSample
    {
        // Store the range that will be sorted in Range.
        public SpreadsheetGear.IRange Range { get; set; }

        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Create a new workbook and create some local variables to the active worksheet and its cells.
            Workbook = SpreadsheetGear.Factory.GetWorkbook();
            SpreadsheetGear.IWorksheet worksheet = Workbook.ActiveWorksheet;
            SpreadsheetGear.IRange cells = worksheet.Cells;

            // Get a reference to a range of cells.
            Range = cells["A1:B8"];

            // Load products in no particular order.
            Range[0, 0].Formula = "Oregano";
            Range[1, 0].Formula = "Marjoram";
            Range[2, 0].Formula = "Basil";
            Range[3, 0].Formula = "Rosemary";
            Range[4, 0].Formula = "Thyme";
            Range[5, 0].Formula = "Black Pepper";
            Range[6, 0].Formula = "Garlic Powder";
            Range[7, 0].Formula = "Chili Powder";

            // Load random data and format as $ using multiple cell range.
            SpreadsheetGear.IRange body = Range[0, 1, 7, 1];
            body.Formula = string.Format("=ROUND(RAND() * 5000, -3)");
            body.NumberFormat = string.Format("$#,##0_);($#,##0)");

            // Get rid of formulas...
            body.Value = body.Value;

            // AutoFit the range.
            Range.Columns.AutoFit();
        }

        public void RunSample()
        {
            // Set up the first sort key with a key index of one representing the second
            // column (random $ amounts) in the range, descending sort order, and the
            // normal data option.
            SpreadsheetGear.SortKey sortKey1 = new SpreadsheetGear.SortKey(
                1, SpreadsheetGear.SortOrder.Descending, SpreadsheetGear.SortDataOption.Normal);

            // Set up the second sort key with a key index of zero representing the first
            // column (products) in the range, ascending sort order, and the normal data option.
            //
            // This sort key will be used when the values in the first sort key are equal.
            SpreadsheetGear.SortKey sortKey2 = new SpreadsheetGear.SortKey(
                0, SpreadsheetGear.SortOrder.Ascending, SpreadsheetGear.SortDataOption.Normal);

            // Sort the range by rows, ignoring case, passing the sort key.
            // NOTE: Any number of sort keys may be passed to the Sort method.
            Range.Sort(SpreadsheetGear.SortOrientation.Rows, false, sortKey1, sortKey2);
        }
    }
}
