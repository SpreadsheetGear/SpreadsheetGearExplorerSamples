namespace SamplesLibrary.Samples.Charting.Stock
{
    public class VHLCStockChartSample : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Get the full path to a workbook with some data for the chart.
            string workbookPath = Helpers.GetFullOutputFolderPath(@"Files\Engine\ChartData-Stock-V-H-L-C.xlsx");

            // Open the workbook.
            Workbook = SpreadsheetGear.Factory.GetWorkbook(workbookPath);
        }

        public void RunSample()
        {
            // Create some local variables to the active worksheet and its cells.
            SpreadsheetGear.IWorksheet worksheet = Workbook.ActiveWorksheet;
            SpreadsheetGear.IRange cells = worksheet.Cells;

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

            // Get the source data range from an existing XML File.
            SpreadsheetGear.IRange source = cells["G2:L24"];

            // Set the chart's source data range, plotting series in columns.
            chart.SetSourceData(source, SpreadsheetGear.Charts.RowCol.Columns);

            // Set the chart type to a volume-open-high-low-close stock chart.
            chart.ChartType = SpreadsheetGear.Charts.ChartType.StockVOHLC;

            // Get a reference to the first chart group used for volume series.
            SpreadsheetGear.Charts.IChartGroup volumeGroup = chart.ChartGroups[0];

            // Increase the volume series bar width by decreasing the gap width.
            volumeGroup.GapWidth = 75;

            // Get a reference to the second chart group used for stock values.
            SpreadsheetGear.Charts.IChartGroup stockGroup = chart.ChartGroups[1];

            // Change the fill color of the down bars.
            stockGroup.DownBars.Format.Fill.ForeColor.RGB = SpreadsheetGear.Colors.Red;

            // Change the fill color of the up bars.
            stockGroup.UpBars.Format.Fill.ForeColor.RGB = SpreadsheetGear.Colors.Green;

            // Get a reference to the primary category axis.
            SpreadsheetGear.Charts.IAxis categoryAxis =
                chart.Axes[SpreadsheetGear.Charts.AxisType.Category];

            // Change the primary category axis to always use a category scale.
            categoryAxis.CategoryType =
                SpreadsheetGear.Charts.CategoryType.CategoryScale;

            // Set the label frequency of the primary category axis.
            categoryAxis.TickLabelSpacing = 7;

            // Get a reference to the primary value axis.
            SpreadsheetGear.Charts.IAxis valueAxis =
                chart.Axes[SpreadsheetGear.Charts.AxisType.Value];

            // Set the min, max, and major units of the primary value axis.
            valueAxis.MinimumScale = 0;
            valueAxis.MaximumScale = 130000;
            valueAxis.MajorUnit = 26000;

            // Hide the major gridlines on the primary value axis.
            valueAxis.HasMajorGridlines = false;

            // Get a reference to the secondary value axis.
            valueAxis = chart.Axes[
                SpreadsheetGear.Charts.AxisType.Value,
                SpreadsheetGear.Charts.AxisGroup.Secondary];

            // Set the min, max, and major units of the secondary value axis.
            valueAxis.MinimumScale = 0;
            valueAxis.MaximumScale = 130;
            valueAxis.MajorUnit = 26;

            // Hide the major gridlines on the secondary value axis.
            valueAxis.HasMajorGridlines = false;

            // Delete the legend.
            chart.HasLegend = false;

            // Add a chart title and change the font size.
            chart.HasTitle = true;
            chart.ChartTitle.Text = "ABC Company (Volume-Open-High-Low-Close)";
            chart.ChartTitle.Font.Size = 10;
        }
    }
}
