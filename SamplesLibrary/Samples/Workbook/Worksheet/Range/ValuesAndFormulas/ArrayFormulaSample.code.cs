namespace SamplesLibrary.Samples.Workbook.Worksheet.Range.ValuesAndFormulas
{
    public class ArrayFormulaSample : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Get the full path to a workbook with sample data that helps demonstrate usage of array formulas.
            string workbookPath = Helpers.GetFullOutputFolderPath(@"Files\Engine\ArrayFormulaData.xlsx");

            // Open the workbook.
            Workbook = SpreadsheetGear.Factory.GetWorkbook(workbookPath);
        }

        public void RunSample()
        {
            // Create some local variables to the active worksheet and its cells.
            SpreadsheetGear.IWorksheet worksheet = Workbook.ActiveWorksheet;
            SpreadsheetGear.IRange cells = worksheet.Cells;

            // Use IRange.ArrayFormula to enter a formula array, in this case on the range
            // C2:C6, which provides a total (cost * quantity) for each line item.
            cells["C2:C6"].FormulaArray = "=A2:A6*B2:B6";

            // Enter a single-cell array formula to sum the total of all line items.
            cells["C8"].FormulaArray = "=SUM($A$2:$A$6*$B$2:$B$6)";
        }
    }
}
