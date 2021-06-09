namespace SamplesLibrary.Samples.Workbook.Worksheet.Range.ValuesAndFormulas
{
    public class WhatIfDataTableSample : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Get the full path to a workbook with sample data that will help demonstrate What-If 
            // Data Tables.
            string workbookPath = Helpers.GetFullOutputFolderPath(@"Files\Engine\WhatIfDataTable.xlsx");

            // Open the workbook.
            Workbook = SpreadsheetGear.Factory.GetWorkbook(workbookPath);
        }

        public void RunSample()
        {
            // Create some local variables to the active worksheet and its cells.
            SpreadsheetGear.IWorksheet worksheet = Workbook.ActiveWorksheet;
            SpreadsheetGear.IRange cells = worksheet.Cells;

            // Setup a What-If Data Table on the range C7:H12. Note you do need to include the 
            // input row (Row 7) and input column (Column C).
            cells["C7:H12"].Table(cells["D4"], cells["D3"]);
        }
    }
}
