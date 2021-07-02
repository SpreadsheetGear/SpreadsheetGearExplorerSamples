namespace SamplesLibrary.Samples.Charting
{
    public class CreateChartSheetSample : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Create a new workbook.
            Workbook = SpreadsheetGear.Factory.GetWorkbook();
        }

        public void RunSample()
        {
            // Create local variables to the active worksheet and its cells.
            SpreadsheetGear.IWorksheet worksheet = Workbook.ActiveWorksheet;
            SpreadsheetGear.IRange cells = worksheet.Cells;

            // Setup some sample data to create a chart series.
            cells["A1:D8"].Formula = "=RANDBETWEEN(1, 100)";

            // Add a ChartSheet to the workbook and set its name
            SpreadsheetGear.IChartSheet chartSheet = Workbook.ChartSheets.Add();
            chartSheet.Name = "My Chart Sheet";

            // Get a reference to the IChart on the ChartSheet.
            SpreadsheetGear.Charts.IChart chart = chartSheet.Chart;

            // Populate the chart with some data.
            chart.SetSourceData(cells["A1:D8"], SpreadsheetGear.Charts.RowCol.Columns);

            // Set the ChartType.
            chart.ChartType = SpreadsheetGear.Charts.ChartType.BarClustered;
        }
    }
}
