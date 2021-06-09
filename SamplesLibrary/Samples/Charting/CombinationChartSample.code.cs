namespace SamplesLibrary.Samples.Charting
{
    public class CombinationChartSample : ISpreadsheetGearEngineSample
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

            // Load some sample data.
            cells["G3:G7"].Value =
                new string[,] { { "Mon" }, { "Tue" }, { "Wed" }, { "Thu" }, { "Fri" } };
            cells["H2:K2"].Value =
                new string[,] { { "Breakfast", "Lunch", "Dinner", "Total" } };
            cells["H3:J7"].Formula = "=INT(RAND() * 500) + 300";
            cells["K3:K7"].Formula = "=SUM(H3:J3)";

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
            SpreadsheetGear.IRange source = cells["G2:K7"];
            chart.SetSourceData(source, SpreadsheetGear.Charts.RowCol.Columns);

            // Set the chart type to a 100% stacked column.
            chart.ChartType = SpreadsheetGear.Charts.ChartType.ColumnStacked100;

            // Get a reference to the chart's series collection and each series.
            SpreadsheetGear.Charts.ISeriesCollection seriesCollection = chart.SeriesCollection;
            SpreadsheetGear.Charts.ISeries seriesBreakfast = seriesCollection[0];
            SpreadsheetGear.Charts.ISeries seriesLunch = seriesCollection[1];
            SpreadsheetGear.Charts.ISeries seriesDinner = seriesCollection[2];
            SpreadsheetGear.Charts.ISeries seriesTotal = seriesCollection[3];

            // Change the last series chart type and plot it on the secondary axis. 
            // NOTE: This creates a combination chart using multiple chart groups
            //       and utilizes both primary and secondary axes sets, allowing for
            //       disproportionate ranges of values to be plotted separately.
            seriesTotal.ChartType = SpreadsheetGear.Charts.ChartType.Line;
            seriesTotal.AxisGroup = SpreadsheetGear.Charts.AxisGroup.Secondary;

            // Change the fill color of each primary series.
            seriesBreakfast.Format.Fill.ForeColor.RGB = SpreadsheetGear.Colors.DarkOrange;
            seriesLunch.Format.Fill.ForeColor.RGB = SpreadsheetGear.Colors.OrangeRed;
            seriesDinner.Format.Fill.ForeColor.RGB = SpreadsheetGear.Colors.Red;

            // Change the line color of the total series.
            seriesTotal.Format.Line.ForeColor.RGB = SpreadsheetGear.Colors.Yellow;

            // Add data labels to the total series and get a reference to the data labels.
            seriesTotal.HasDataLabels = true;
            SpreadsheetGear.Charts.IDataLabels dataLabels = seriesTotal.DataLabels;

            // Position each data label below each data point.
            dataLabels.Position = SpreadsheetGear.Charts.DataLabelPosition.Below;

            // Change the fill formatting of the data labels.
            SpreadsheetGear.Shapes.IFillFormat fillFormat = dataLabels.Format.Fill;
            fillFormat.ForeColor.RGB = SpreadsheetGear.SystemColors.Window;
            fillFormat.Visible = true;

            // Change the line formatting of the data labels.
            SpreadsheetGear.Shapes.ILineFormat lineFormat = dataLabels.Format.Line;
            lineFormat.ForeColor.RGB = SpreadsheetGear.SystemColors.WindowText;
            lineFormat.Visible = true;

            // Change the legend position to the top of the chart.
            chart.Legend.Position = SpreadsheetGear.Charts.LegendPosition.Top;

            // Get a reference to the primary value axis, hide major
            // gridlines, and use a fixed major unit scaling value.
            SpreadsheetGear.Charts.IAxis valueAxis =
                chart.Axes[SpreadsheetGear.Charts.AxisType.Value];
            valueAxis.HasMajorGridlines = false;
            valueAxis.MajorUnit = 0.25;

            // Change the chart font name and size.
            chart.ChartArea.Font.Name = "Verdana";
            chart.ChartArea.Font.Size = 8;

            // Add a chart title and change the font size.
            chart.HasTitle = true;
            chart.ChartTitle.Text = "Weekday Calorie Intake";
            chart.ChartTitle.Font.Size = 9;
        }
    }
}
