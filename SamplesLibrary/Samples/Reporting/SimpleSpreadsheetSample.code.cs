namespace SamplesLibrary.Samples.Reporting
{
    public class SimpleSpreadsheetSample : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Obtain CultureInfo object used on this machine.
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CurrentCulture;

            // Create a new workbook that will use this CultureInfo.
            Workbook = SpreadsheetGear.Factory.GetWorkbook(culture);
        }

        public void RunSample()
        {
            // Get culture being used by the workbook.
            System.Globalization.CultureInfo culture = Workbook.WorkbookSet.Culture;

            // Get a worksheet reference.
            SpreadsheetGear.IWorksheet worksheet = Workbook.Worksheets[0];

            // Get the worksheet cells reference.
            SpreadsheetGear.IRange cells = worksheet.Cells;

            // Set the worksheet name.
            worksheet.Name = $"{System.DateTime.Today.Year} Sales";

            // Load column titles and center.
            cells["B1"].Formula = "North";
            cells["C1"].Formula = "South";
            cells["D1"].Formula = "East";
            cells["E1"].Formula = "West";
            cells["B1:E1"].HorizontalAlignment = SpreadsheetGear.HAlign.Center;

            // Load row titles using multiple cell text reference and iteration.
            int quarter = 1;
            foreach (SpreadsheetGear.IRange cell in cells["A2:A5"])
                cell.Formula = "Q" + quarter++;

            // Load random data and format as $ using multiple cell range.  Note the number group
            // separator character is specified from the culture object used by the workbook.
            SpreadsheetGear.IRange body = cells[1, 1, 4, 4];
            body.Formula = "=RAND() * 10000";
            body.NumberFormat = string.Format("$#{0}##0_);($#{0}##0)", culture.NumberFormat.NumberGroupSeparator);
        }
    }
}
