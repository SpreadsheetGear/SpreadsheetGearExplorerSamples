namespace SamplesLibrary.Samples.Workbook.Worksheet.Range.Operations
{
    public class GroupAndOutlineSample : ISpreadsheetGearEngineSample
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

            // Clear any existing outlines.
            cells.ClearOutline();

            // Set column titles and formatting.
            cells["A1"].Formula = "Region";
            cells["B1"].Formula = "Quarter";
            cells["C1"].Formula = "Sales";
            cells["A1:C1"].Font.Bold = true;

            // Call method to group and summarize each region.
            CreateRegion("East", cells["A2:C5"], cells["A6:C6"]);
            CreateRegion("West", cells["A7:C10"], cells["A11:C11"]);
            CreateRegion("North", cells["A12:C15"], cells["A16:C16"]);
            CreateRegion("South", cells["A17:C20"], cells["A21:C21"]);

            // Set summary total for all regions.
            SpreadsheetGear.IRange totalCell = cells["C22"];
            totalCell.Formula = string.Format("=SUM(C6,C11,C16,C21)");
            totalCell.NumberFormat = string.Format("$#,##0_);($#,##0)");
            totalCell.Font.Bold = true;

            // Group all regions.
            cells["A2:A21"].EntireRow.Group();

            // Collapse all region detail levels.
            worksheet.Outline.ShowLevels(2, 0);

            // Show detail for one region.
            cells["A6"].EntireRow.ShowDetail = true;
        }

        public void CreateRegion(string region, SpreadsheetGear.IRange detailCells,
                SpreadsheetGear.IRange summaryCells)
            {
                // Set region data, formulas and formatting.
                int quarter = 1;
                for (int iRow = 0; iRow < detailCells.RowCount; iRow++)
                {
                    detailCells[iRow, 0].Formula = region;
                    detailCells[iRow, 1].Formula = "Q" + quarter++;
                    detailCells[iRow, 2].Formula = "=RAND() * 10000";
                    detailCells[iRow, 2].NumberFormat = string.Format("$#,##0_);($#,##0)");
                }

                // Group the region.
                detailCells.EntireRow.Group();

                // Get the data column of the detail cells.
                int lastRow = detailCells.RowCount - 1;
                int lastColumn = detailCells.ColumnCount - 1;
                SpreadsheetGear.IRange dataCells =
                    detailCells[0, lastColumn, lastRow, lastColumn];

                // Set summary titles for the region.
                summaryCells[0, 0].Formula = region;
                summaryCells[0, 1].Formula = "Total";

                // Set summary total for the region.
                SpreadsheetGear.IRange totalCell = summaryCells[0, 2];
                totalCell.Formula = "=SUM(" + dataCells.Address + ")";
                totalCell.NumberFormat = string.Format("$#,##0_);($#,##0)");
                totalCell.Font.Bold = true;
            }
    }
}
