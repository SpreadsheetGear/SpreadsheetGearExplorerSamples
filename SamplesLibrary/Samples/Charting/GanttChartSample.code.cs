namespace SamplesLibrary.Samples.Charting
{
    public class GanttChartSample : ISpreadsheetGearEngineSample
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

            // Load category labels using multiple cell text reference and iteration.
            int task = 1;
            foreach (SpreadsheetGear.IRange cell in cells["G2:G7"])
                cell.Formula = "Task " + task++;

            // Start with zero and use formulas to calculate each additional start value.
            cells["H2"].Formula = "0";
            cells["H3:H7"].Formula = "=H2+I2";

            // Load random duration values
            cells["I2:I7"].Formula = "=INT(RAND() * 10) + 2";

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

            // Set the chart's source data range, plotting series in columns.
            SpreadsheetGear.IRange source = cells["G2:I7"];
            chart.SetSourceData(source, SpreadsheetGear.Charts.RowCol.Columns);

            // Set the chart type to stacked bar to simulate a gantt chart.
            chart.ChartType = SpreadsheetGear.Charts.ChartType.BarStacked;

            // Set the distance between bars as a percentage of the bar width.
            chart.ChartGroups[0].GapWidth = 100;

            // Hide the first (Start) series values by setting the fill to none.
            chart.SeriesCollection[0].Format.Fill.Visible = false;

            // Change the theme color of the second (Duration) series.
            chart.SeriesCollection[1].Format.Fill.ForeColor.ThemeColor =
                SpreadsheetGear.Themes.ColorSchemeIndex.Accent4;

            // Reverse the category axis so that values are shown top to bottom.
            chart.Axes[SpreadsheetGear.Charts.AxisType.Category].ReversePlotOrder = true;

            // Add a chart title and change the font size.
            chart.HasTitle = true;
            chart.ChartTitle.Text = "Estimated Days To Completion";
            chart.ChartTitle.Font.Size = 12;

            // Delete the legend.
            chart.HasLegend = false;
        }
    }
}
