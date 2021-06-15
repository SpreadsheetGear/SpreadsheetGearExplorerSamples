using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SamplesLibrary.Samples.WorkboookView
{
    public class CultureInfoSample : ISpreadsheetGearWindowsSample
    {
        public void RunSample(IWorkbookView workbookView_deDE, IWorkbookView workbookView_selectedCulture, string cultureInfoName)
        {
            // Start by creating a new workbook that uses the German "de-DE" culture. Note this culture uses the following:
            //   - Thousands Separator:  "."
            //   - Decimal Separator:    ","
            //   - List Separator:       ";"
            //   - Short Date Format:    "dd.MM.yyyy"
            CultureInfo culture_deDe = CultureInfo.GetCultureInfo("de-DE");
            SpreadsheetGear.IWorkbook workbook_deDe = SpreadsheetGear.Factory.GetWorkbook(culture_deDe);
            SpreadsheetGear.IWorksheet worksheet_deDE = workbook_deDe.ActiveWorksheet;
            SpreadsheetGear.IRange cells_deDE = worksheet_deDE.Cells;

            // Set a number that uses an "de-DE" format.
            cells_deDE["A1"].Value = 12345;
            cells_deDE["A1"].NumberFormat = "#.##0,00";
            cells_deDE["B1"].Value = "<-- Thousands & decimal Separators change based on the selected culture.";

            // Setup a similar date format with "de-DE" conventions.
            cells_deDE["A2"].Value = System.DateTime.Today;
            cells_deDE["A2"].NumberFormat = "dd.mm.yyyy";
            cells_deDE["B2"].Value = "<-- Date Format changes based on the selected culture.";

            // Finally, add a formula that uses the "de-DE" list separator character (";").
            cells_deDE["A3"].Formula = "=SUM(1;2;3)";
            cells_deDE["B3"].Value = "<-- Formula's List Separator changes based on the selected culture.";

            // Expand column width (to avoid clipped cell content) and select A3 to show the above formula in the FormulaBar.
            cells_deDE.ColumnWidth = 12;
            cells_deDE["A3"].Select();

            // Save the workbook to a temporary file on disk.  If you locate & open this file with Microsoft Excel on your 
            // own machine, note that unless your Operating System is setup with German regional / localization settings,
            // then you won't see the above "de-DE" formatted vales.  This demonstrates that Excel files are not inherently 
            // saved with any particular localization settings.  Instead, Excel at runtime will dynamically apply the 
            // localization options used by your OS.
            workbook_deDe.SaveAs(@"Temp\CultureWorkbook.xlsx", SpreadsheetGear.FileFormat.OpenXMLWorkbook);

            // Get the CultureInfo selected in the ListBox for this sample, which is initially set to "en-US".
            CultureInfo selectedCultureInfo = CultureInfo.GetCultureInfo(cultureInfoName);

            // Now open a new workbook and pass in the Cultureinfo object that was selected.  As described above about 
            // Microsoft Excel, SpreadsheetGear will at runtime dynamically apply the specified CultureInfo settings to the 
            // workbook.  If you do not pass in any CultureInfo, SpreadsheetGear defaults to using "en-US".
            SpreadsheetGear.IWorkbook workbook_selectedCulture = SpreadsheetGear.Factory.GetWorkbook(@"Temp\CultureWorkbook.xlsx",
                selectedCultureInfo);

            // Display the workbooks in each WorkbookView.
            workbookView_deDE.ActiveWorkbook = workbook_deDe;
            workbookView_selectedCulture.ActiveWorkbook = workbook_selectedCulture;
        }

        public List<string> GetAllCultures()
        {
            // Get a list of all cultures
            var cultures = CultureInfo.GetCultures(CultureTypes.AllCultures)
                .Select(c => c.Name)        // Get culture names (i.e., "en-US", etc.)
                .Where(c => c.Length > 0)   // Ignore the invariant culture
                .ToList();

            // Reorder list to bubble common cultures to the top of the list.
            var commonCultures = new List<string>() { "en-US", "en-GB", "de-DE", "fr-FR", "ja-JP" };
            commonCultures.Reverse();
            foreach (var commonCulture in commonCultures)
            {
                var culture = cultures.SingleOrDefault(c => c == commonCulture);
                if (culture != null)
                {
                    cultures.Remove(culture);
                    cultures.Insert(0, culture);
                }
            }

            return cultures;
        }
    }
}
