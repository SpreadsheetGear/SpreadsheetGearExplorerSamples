namespace SamplesLibrary.Samples.Workbook.Worksheet
{
    public class MoveAndCopySample : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Create a new workbook.
            Workbook = SpreadsheetGear.Factory.GetWorkbook();
        }

        public void RunSample()
        {
            // Get the workbook set that 'Workbook' belongs to.
            SpreadsheetGear.IWorkbookSet workbookSet = Workbook.WorkbookSet;

            // Get the full path to a workbook template file. 
            string workbookPath = Helpers.GetFullOutputFolderPath(@"Files\Engine\MoveAndCopyTemplate.xlsx");

            // Open the workbook in the Workbook Set.
            SpreadsheetGear.IWorkbook template = workbookSet.Workbooks.Open(workbookPath);

            // Make a copy of template sheet in new workbook, which will be placed after Sheet1.
            SpreadsheetGear.IWorksheet newSheet = template.Worksheets["Template Sheet"].CopyAfter(
                Workbook.Worksheets["Sheet1"]) as SpreadsheetGear.IWorksheet;

            // Rename the sheet
            newSheet.Name = "Profit Report";

            // Populate new sheet with some dummy data.
            string formula = "=ROUND(RAND()*1000000,2)";
            newSheet.Names["NorthProfit"].RefersToRange.Formula = formula;
            newSheet.Names["SouthProfit"].RefersToRange.Formula = formula;
            newSheet.Names["EastProfit"].RefersToRange.Formula = formula;
            newSheet.Names["WestProfit"].RefersToRange.Formula = formula;

            // Move the new "Profit Report" sheet before the original "Sheet1".
            newSheet.MoveBefore(Workbook.Worksheets["Sheet1"]);
        }
    }
}
