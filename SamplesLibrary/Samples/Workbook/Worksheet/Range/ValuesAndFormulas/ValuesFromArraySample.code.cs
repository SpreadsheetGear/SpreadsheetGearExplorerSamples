namespace SamplesLibrary.Samples.Workbook.Worksheet.Range.ValuesAndFormulas
{
    public class ValuesFromArraySample : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Create a new workbook.
            Workbook = SpreadsheetGear.Factory.GetWorkbook();
        }

        public void RunSample()
        {
            // Create some local variables to the active worksheet and its cells.
            SpreadsheetGear.IWorksheet worksheet = Workbook.ActiveWorksheet;
            SpreadsheetGear.IRange cells = worksheet.Cells;

            // Get a reference to a range of cells.
            SpreadsheetGear.IRange range = cells["A1:J25"];

            // Create an array of values matching the size of 
            // the range which is 25 rows x 10 columns.
            int rowCount = range.RowCount;
            int colCount = range.ColumnCount;
            object[,] values = new object[rowCount, colCount];
            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                    values[row, col] = "Cell=" + range.WorkbookSet.GetAddress(row, col);
            }

            // Set the array values into the range.
            range.Value = values;

            // AutoFit the range.
            range.Columns.AutoFit();
        }
    }
}
