namespace SamplesLibrary.Samples.Charting
{
    public class RadarChartSample : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Get the full path to a workbook with some data for the chart.
            string workbookPath = Helpers.GetFullOutputFolderPath(@"Files\Engine\ChartData-Radar.xlsx");

            // Open the workbook.
            Workbook = SpreadsheetGear.Factory.GetWorkbook(workbookPath);
        }

        public void RunSample()
        {
            // Create local variables to the active worksheet and its window info.
            SpreadsheetGear.IWorksheet worksheet = Workbook.ActiveWorksheet;
            SpreadsheetGear.IWorksheetWindowInfo windowInfo = worksheet.WindowInfo;

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

            // Get the source data range from an existing defined name.
            SpreadsheetGear.IRange source = Workbook.Names["Maintenance"].RefersToRange;

            // Set the chart's source data range, plotting series in columns.
            chart.SetSourceData(source, SpreadsheetGear.Charts.RowCol.Columns);

            // Set the chart type to filled radar.
            chart.ChartType = SpreadsheetGear.Charts.ChartType.RadarFilled;

            // Add a chart title and change the font size.
            chart.HasTitle = true;
            chart.ChartTitle.Text = "Seasonal Maintenance Costs";
            chart.ChartTitle.Font.Size = 12;
        }
    }
}
