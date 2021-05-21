namespace SamplesLibrary.Samples.Workbook.Worksheet.Range.Formatting
{
    public class HyperlinksSample : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Create a new workbook and add a second worksheet ("Sheet2").
            Workbook = SpreadsheetGear.Factory.GetWorkbook();
            Workbook.Worksheets.Add();
        }

        public void RunSample()
        {
            // Get a reference to "Sheet1".
            SpreadsheetGear.IWorksheet worksheet = Workbook.Worksheets["Sheet1"];

            // Get a reference to the worksheet's hyperlink collection.
            SpreadsheetGear.IHyperlinks hyperlinks = worksheet.Hyperlinks;

            // Delete all hyperlinks in the collection.
            hyperlinks.Delete();

            // Add a hyperlink referencing a range.
            hyperlinks.Add(
                worksheet.Cells["A2"], null, "C:C", null, "Column C");

            // Add a hyperlink referencing a range on another worksheet.
            hyperlinks.Add(
                worksheet.Cells["A3"], null, "Sheet2!A1:D4", null, "Range on Sheet2");

            // Add a hyperlink referencing a web page.
            hyperlinks.Add(
                worksheet.Cells["A4"],
                @"http://www.spreadsheetgear.com",
                null, null, "www.spreadsheetgear.com");

            // Add a hyperlink referencing an email address.
            hyperlinks.Add(
                worksheet.Cells["A5"],
                "mailto:sales@spreadsheetgear.com",
                null, null, "sales@spreadsheetgear.com");

            // Add a hyperlink referencing an email address with a subject.
            hyperlinks.Add(
                worksheet.Cells["A6"],
                "mailto:support@spreadsheetgear.com?subject=Support Request",
                null, null, "support@spreadsheetgear.com");

            // Make "Sheet1" the active sheet and add some text and set the column width.
            worksheet.Select();
            worksheet.Cells["A1"].Formula = "Hyperlink Examples";
            worksheet.Cells["A1"].ColumnWidth = 30;
        }
    }
}
