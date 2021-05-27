namespace SamplesLibrary.Samples.Charting
{
    public class ScatterChartSample : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Create a new workbook.
            Workbook = SpreadsheetGear.Factory.GetWorkbook();
        }

        public void RunSample()
        {
            // Create some local variables to the active worksheet, its window info
            // and its cells.
            SpreadsheetGear.IWorksheet worksheet = Workbook.ActiveWorksheet;
            SpreadsheetGear.IWorksheetWindowInfo windowInfo = worksheet.WindowInfo;
            SpreadsheetGear.IRange cells = worksheet.Cells;

            // Get the chart's source data range and add some sample data.
            cells["G2:J30"].Formula = "=INT(RAND() * 500) + 150"; ;

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

            // Add a series and link x and y values to the source data range.
            SpreadsheetGear.Charts.ISeries series1 = chart.SeriesCollection.Add();
            series1.XValues = "=G2:G30";
            series1.Values = "=H2:H30";

            // Add a second series and link x an y values to the source data range.
            SpreadsheetGear.Charts.ISeries series2 = chart.SeriesCollection.Add();
            series2.XValues = "=I2:I30";
            series2.Values = "=J2:J30";

            // Set the chart type to XYScatter.
            chart.ChartType = SpreadsheetGear.Charts.ChartType.XYScatter;

            // Get a reference to the x value axis, add a title, and link the title to a cell.
            SpreadsheetGear.Charts.IAxis xValueAxis =
                chart.Axes[SpreadsheetGear.Charts.AxisType.Category];
            xValueAxis.HasTitle = true;
            xValueAxis.AxisTitle.Text = "X Value Axis";

            // Get a reference to the y value axis, add a title, and link the title to a cell.
            SpreadsheetGear.Charts.IAxis yValueAxis =
                chart.Axes[SpreadsheetGear.Charts.AxisType.Value];
            yValueAxis.HasTitle = true;
            yValueAxis.AxisTitle.Text = "Y Value Axis";

            // Delete the major gridlines from the y value axis.
            yValueAxis.HasMajorGridlines = false;

            // Delete the legend.
            chart.HasLegend = false;

            // Add a chart title and change the font size.
            chart.HasTitle = true;
            chart.ChartTitle.Text = "XY Scatter Plot";
            chart.ChartTitle.Font.Size = 12;
        }
    }
}
