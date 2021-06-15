namespace SamplesLibrary.Samples.Workbook.Worksheet.Range.Operations
{
    public class FillDataSeriesSample : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Get the full path to a workbook with some data that we can apply a Data Series Fill.
            string workbookPath = Helpers.GetFullOutputFolderPath(@"Files\Engine\DataSeries.xlsx");

            // Open the workbook.
            Workbook = SpreadsheetGear.Factory.GetWorkbook(workbookPath);
        }

        public void RunSample()
        {
            // Create some local variables to the active worksheet and its cells.
            SpreadsheetGear.IWorksheet worksheet = Workbook.ActiveWorksheet;
            SpreadsheetGear.IRange cells = worksheet.Cells;

            // Auto fill by month name.
            cells["A2:A13"].DataSeries(true,
                SpreadsheetGear.DataSeriesType.AutoFill,
                SpreadsheetGear.DataSeriesDate.Day, 1, 1, false);

            // Fill by day.
            cells["B2:B13"].DataSeries(true,
                SpreadsheetGear.DataSeriesType.Chronological,
                SpreadsheetGear.DataSeriesDate.Day, 1, System.Double.MaxValue, false);

            // Fill by month.
            cells["C2:C13"].DataSeries(true,
                SpreadsheetGear.DataSeriesType.Chronological,
                SpreadsheetGear.DataSeriesDate.Month, 1, System.Double.MaxValue, false);

            // Fill by year.
            cells["D2:D13"].DataSeries(true,
                SpreadsheetGear.DataSeriesType.Chronological,
                SpreadsheetGear.DataSeriesDate.Year, 1, System.Double.MaxValue, false);

            // Fill linear.
            cells["E2:E13"].DataSeries(true,
                SpreadsheetGear.DataSeriesType.DataSeriesLinear,
                SpreadsheetGear.DataSeriesDate.Day, 1, System.Double.MaxValue, false);

            // Fill linear trend.
            cells["F2:F13"].DataSeries(true,
                SpreadsheetGear.DataSeriesType.DataSeriesLinear,
                SpreadsheetGear.DataSeriesDate.Day, 1, 1, true);
        }
    }
}
