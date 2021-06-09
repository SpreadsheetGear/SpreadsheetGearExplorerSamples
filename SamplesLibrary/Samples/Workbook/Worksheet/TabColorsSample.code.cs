namespace SamplesLibrary.Samples.Workbook.Worksheet
{
    public class TabColorsSample : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Create a new workbook with 4 worksheets.
            Workbook = SpreadsheetGear.Factory.GetWorkbook();
            Workbook.Worksheets.Add();
            Workbook.Worksheets.Add();
            Workbook.Worksheets.Add();
        }

        public void RunSample()
        {
            // Set tab color with pre-defined color.
            SpreadsheetGear.ITab sheet1Tab = Workbook.Sheets["Sheet1"].Tab;
            sheet1Tab.Color = SpreadsheetGear.Colors.Red;

            // Use arbitrary RGB color.
            SpreadsheetGear.ITab sheet2Tab = Workbook.Sheets["Sheet2"].Tab;
            sheet2Tab.Color = SpreadsheetGear.Color.FromArgb(0, 192, 0);

            // Use a theme color
            SpreadsheetGear.ITab sheet3Tab = Workbook.Sheets["Sheet3"].Tab;
            sheet3Tab.ThemeColor = SpreadsheetGear.Themes.ColorSchemeIndex.Accent1;
            sheet3Tab.TintAndShade = 0.25; // Make theme color 25% lighter.
        }
    }
}
