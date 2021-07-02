namespace SamplesLibrary.Samples.Charting.Basic
{
    public class LineChartSample : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Get the full path to a workbook with some data for the chart.
            string workbookPath = Helpers.GetFullOutputFolderPath(@"Files\Engine\ChartData.xlsx");

            // Open the workbook.
            Workbook = SpreadsheetGear.Factory.GetWorkbook(workbookPath);
        }

        public void RunSample()
        {
            // Create a local variable to the active worksheet.
            SpreadsheetGear.IWorksheet worksheet = Workbook.ActiveWorksheet;

            // Get a reference to the worksheet window info and shapes collection.
            SpreadsheetGear.IWorksheetWindowInfo windowInfo = worksheet.WindowInfo;
            SpreadsheetGear.Shapes.IShapes shapes = worksheet.Shapes;

            // Add a chart to the worksheet's shape collection.
            // NOTE: Calculate the coordinates of the chart by converting row and column
            //       coordinates to points.  Use fractional row and column values to get 
            //       coordinates anywhere in between row and column boundaries.
            double left = windowInfo.ColumnToPoints(0.15);
            double top = windowInfo.RowToPoints(0.5);
            double right = windowInfo.ColumnToPoints(5.85);
            double bottom = windowInfo.RowToPoints(13.5);
            SpreadsheetGear.Charts.IChart chart =
                shapes.AddChart(left, top, right - left, bottom - top).Chart;

            // Get the source data range from an existing defined name.
            SpreadsheetGear.IRange source = Workbook.Names["TotalByRegion"].RefersToRange;

            // Set the chart's source data range, plotting series in rows.
            chart.SetSourceData(source, SpreadsheetGear.Charts.RowCol.Rows);

            // Set the chart type to a line chart with markers.
            chart.ChartType = SpreadsheetGear.Charts.ChartType.LineMarkers;

            // Get a reference to the single total series.
            SpreadsheetGear.Charts.ISeries seriesTotal = chart.SeriesCollection[0];

            // Add category axis labels by using an existing defined name.
            seriesTotal.XValues = "=Regions";

            // Add series data labels and position them above the data points.
            seriesTotal.HasDataLabels = true;
            seriesTotal.DataLabels.Position = SpreadsheetGear.Charts.DataLabelPosition.Above;

            // Hide the legend.
            chart.HasLegend = false;

            // Hide the major gridlines on the value axis.
            chart.Axes[SpreadsheetGear.Charts.AxisType.Value].HasMajorGridlines = false;

            // Add a chart title and change the font size.
            chart.HasTitle = true;
            chart.ChartTitle.Text = "Total Sales by Region";
            chart.ChartTitle.Font.Size = 12;
        }
    }
}
