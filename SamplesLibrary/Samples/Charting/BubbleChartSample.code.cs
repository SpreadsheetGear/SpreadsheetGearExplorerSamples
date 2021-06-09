namespace SamplesLibrary.Samples.Charting
{
    public class BubbleChartSample : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Get the full path to a workbook with some data for the chart>
            string workbookPath = Helpers.GetFullOutputFolderPath(@"Files\Engine\ChartData-Bubble.xlsx");

            // Open a workbook with some data for the chart.
            Workbook = SpreadsheetGear.Factory.GetWorkbook(workbookPath);
        }

        public void RunSample()
        {
            // Create some local variables to the active worksheet, its window info, 
            // and cells.
            SpreadsheetGear.IWorksheet worksheet = Workbook.ActiveWorksheet;
            SpreadsheetGear.IWorksheetWindowInfo windowInfo = worksheet.WindowInfo;
            SpreadsheetGear.IRange cells = worksheet.Cells;

            // Add a chart to the worksheet's shape collection.
            // NOTE: Calculate the coordinates of the chart by converting row and column
            //       coordinates to points.  Use fractional row and column values to get 
            //       coordinates anywhere in between row and column boundaries.
            double left = windowInfo.ColumnToPoints(0.15);
            double top = windowInfo.RowToPoints(0.5);
            double right = windowInfo.ColumnToPoints(5.85);
            double bottom = windowInfo.RowToPoints(13.5);
            SpreadsheetGear.Charts.IChart chart =
                worksheet.Shapes.AddChart(left, top, right - left, bottom - top).Chart;

            // Set the chart type to bubble.
            chart.ChartType = SpreadsheetGear.Charts.ChartType.Bubble;

            // Get the chart's source data range.
            SpreadsheetGear.IRange source = cells["G3:J6"];

            // for each row in the data range...
            for (int row = 0; row < source.RowCount; row++)
            {
                // Add a series to the chart's series collection.
                SpreadsheetGear.Charts.ISeries series = chart.SeriesCollection.Add();

                // Set the series name, x values, y values, and bubble size values.
                series.Name = "=" + source[row, 0].Address;
                series.XValues = source[row, 1];
                series.Values = source[row, 2];
                series.BubbleSizes = source[row, 3];
            }

            // Get a reference to the x value axis, add a title, and link the title to a cell.
            SpreadsheetGear.Charts.IAxis xValueAxis =
                chart.Axes[SpreadsheetGear.Charts.AxisType.Category];
            xValueAxis.HasTitle = true;
            xValueAxis.AxisTitle.Text = "=H2";

            // Get a reference to the y value axis, add a title, and link the title to a cell.
            SpreadsheetGear.Charts.IAxis yValueAxis =
                chart.Axes[SpreadsheetGear.Charts.AxisType.Value];
            yValueAxis.HasTitle = true;
            yValueAxis.AxisTitle.Text = "=I2";

            // Add a chart title and change the font size.
            chart.HasTitle = true;
            chart.ChartTitle.Text = "Estimated Return on Investment";
            chart.ChartTitle.Font.Size = 12;
        }
    }
}
