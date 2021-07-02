namespace SamplesLibrary.Samples.Charting.Basic
{
    public class BarChartSample : ISpreadsheetGearEngineSample
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
            SpreadsheetGear.IRange source = Workbook.Names["RegionalSales"].RefersToRange;

            // Set the chart's source data range, plotting series in columns.
            chart.SetSourceData(source, SpreadsheetGear.Charts.RowCol.Columns);

            // Set the chart type to a stacked bar.
            chart.ChartType = SpreadsheetGear.Charts.ChartType.BarStacked;

            // Set the distance between bars as a percentage of the bar width.
            chart.ChartGroups[0].GapWidth = 50;

            // Add a chart title and change the font size.
            chart.HasTitle = true;
            chart.ChartTitle.Text = "Combined Sales by Quarter";
            chart.ChartTitle.Font.Size = 12;

            // Get a reference to the value axis and set the gridline dash style.
            SpreadsheetGear.Charts.IAxis valueAxis =
                chart.Axes[SpreadsheetGear.Charts.AxisType.Value];
            valueAxis.MajorGridlines.Format.Line.DashStyle =
                SpreadsheetGear.Shapes.LineDashStyle.Dash;
        }
    }
}
