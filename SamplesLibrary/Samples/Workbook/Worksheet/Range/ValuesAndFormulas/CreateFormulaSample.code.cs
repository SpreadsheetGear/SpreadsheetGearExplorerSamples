namespace SamplesLibrary.Samples.Workbook.Worksheet.Range.ValuesAndFormulas
{
    public class CreateFormulaSample : ISpreadsheetGearEngineSample
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

            // Set B2 to use the formula =RAND().
            cells["B2"].Formula = "=RAND()";
        }
    }
}
