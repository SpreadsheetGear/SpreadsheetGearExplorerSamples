namespace SamplesLibrary.Samples.Workbook.Worksheet.Range.Formatting
{
    public class NumberFormatsSample : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Create a new workbook.
            Workbook = SpreadsheetGear.Factory.GetWorkbook();
        }

        public void RunSample()
        {
            // Create some local variables to the active sheet and its cells.
            SpreadsheetGear.IWorksheet worksheet = Workbook.ActiveWorksheet;
            SpreadsheetGear.IRange cells = worksheet.Cells;

            // Get a reference to a range of cells.
            SpreadsheetGear.IRange range = cells["A1:A9"];

            // Add data to the cells.
            range.Formula = "1234.5678";

            // Set various number formats.
            range[0, 0].NumberFormat = "General";
            range[1, 0].NumberFormat = "0";
            range[2, 0].NumberFormat = "$#,##0.00_);($#,##0.00)";
            range[3, 0].NumberFormat = "m/d/yyyy";
            range[4, 0].NumberFormat = "h:mm AM/PM";
            range[5, 0].NumberFormat = "0.00%";
            range[6, 0].NumberFormat = "# ??/??";
            range[7, 0].NumberFormat = "0.00E+00";

            // Set number format as text.
            // NOTE: Text format must be set before setting the value.
            range[8, 0].NumberFormat = "@";
            range[8, 0].Formula = "00123456";

            // Autofit the column.
            range.Columns.AutoFit();
        }
    }
}
