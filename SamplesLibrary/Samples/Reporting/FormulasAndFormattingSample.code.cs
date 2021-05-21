namespace SamplesLibrary.Samples.Reporting
{
    public class FormulasAndFormattingSample : ISpreadsheetGearEngineSample
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

            // Construct a sheet name.
            string sheetName = $"{System.DateTime.Today.Year} Sales";

            // Get a worksheet and change the name.
            SpreadsheetGear.IWorksheet worksheet = Workbook.Worksheets[0];
            worksheet.Name = sheetName;

            // Get the worksheet cells reference.
            SpreadsheetGear.IRange cells = worksheet.Cells;

            // Add column headers.
            cells["B1"].Formula = "Jan";
            cells["C1"].Formula = "Feb";
            cells["D1"].Formula = "Mar";

            // Add row headers.
            cells["A2"].Formula = "West";
            cells["A3"].Formula = "Central";
            cells["A4"].Formula = "East";

            // Add random data.
            cells["B2:D4"].Formula = "=RAND()*10000";

            // Center the column headers.
            cells["B1:D1"].HorizontalAlignment = SpreadsheetGear.HAlign.Center;

            // Bold the row and column headers.
            cells["B1:D1"].Union(cells["A2:A4"]).Font.Bold = true;

            // Add defined names.
            SpreadsheetGear.INames names = Workbook.Names;
            names.Add("Jan", $"='{sheetName}'!$B$2:$B$4");
            names.Add("Feb", $"='{sheetName}'!$C$2:$C$4");
            names.Add("Mar", $"='{sheetName}'!$D$2:$D$4");
            names.Add("Sales", $"='{sheetName}'!$B$2:$D$4");

            // Format sales data as currency.  Note we will use the NumberGroupSeparator specified in the culture
            // being used for this workbook.
            cells["Sales"].NumberFormat = string.Format("$#{0}##0", culture.NumberFormat.NumberGroupSeparator);

            // Merge some cells.
            cells["A6:C6"].Merge();

            // Add a hyperlink.
            worksheet.Hyperlinks.Add(cells["A6"], @"https://www.spreadsheetgear.com",
                null, "SpreadsheetGear Home Page", "SpreadsheetGear Home Page");
        }
    }
}
