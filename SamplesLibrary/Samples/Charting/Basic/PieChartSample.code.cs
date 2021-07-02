namespace SamplesLibrary.Samples.Charting.Basic
{
    public class PieChartSample : ISpreadsheetGearEngineSample
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
            SpreadsheetGear.IRange source = Workbook.Names["TotalByQuarter"].RefersToRange;

            // Set the chart's source data range, plotting series in columns.
            chart.SetSourceData(source, SpreadsheetGear.Charts.RowCol.Columns);

            // Set the chart type to a pie chart.
            chart.ChartType = SpreadsheetGear.Charts.ChartType.Pie;

            // Get a reference to the single total series.
            SpreadsheetGear.Charts.ISeries seriesTotal = chart.SeriesCollection[0];

            // Add category labels by using an existing defined name.
            seriesTotal.XValues = "=Quarters";

            // Add series data labels and change to show percentage only.
            seriesTotal.HasDataLabels = true;
            seriesTotal.DataLabels.ShowPercentage = true;
            seriesTotal.DataLabels.ShowValue = false;

            // Add a chart title and change the font size.
            chart.HasTitle = true;
            chart.ChartTitle.Text = "Percentage of Sales by Quarter";
            chart.ChartTitle.Font.Size = 12;
        }
    }
}
