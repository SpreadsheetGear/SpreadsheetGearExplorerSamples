using System.Linq;

namespace SamplesLibrary.Samples.Shapes.Lines
{
    public class LineDashStyleSample : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Create a new workbook.
            Workbook = SpreadsheetGear.Factory.GetWorkbook();
        }

        public void RunSample()
        {
            // Create some local variables to the active worksheet and its window info.
            SpreadsheetGear.IWorksheet worksheet = Workbook.ActiveWorksheet;
            SpreadsheetGear.IWorksheetWindowInfo windowInfo = worksheet.WindowInfo;

            // We will position lines relative to a given range, starting in Row 2.
            SpreadsheetGear.IRange currentRow = worksheet.Cells["2:2"];

            // Position line across Columns A:E
            double xStart = 10;
            double xEnd = windowInfo.ColumnToPoints(5) - 10;

            // Convert LineDashStyle enum options into an IEnumerable.
            var lineDashStyles = System.Enum.GetValues(typeof(SpreadsheetGear.Shapes.LineDashStyle))
                .OfType<SpreadsheetGear.Shapes.LineDashStyle>();

            // Iterate over each Dash Style.
            foreach (var lineDashStyle in lineDashStyles)
            {
                // Position line relative to "currentRow" and add a slight slant to it.
                double yStart = windowInfo.RowToPoints(currentRow.Row) - 5;
                double yEnd = yStart + 10;

                // Add the line and set its weight.
                SpreadsheetGear.Shapes.IShape lineShape = worksheet.Shapes.AddLine(xStart, yStart,
                    xEnd, yEnd);
                SpreadsheetGear.Shapes.ILineFormat lineFormat = lineShape.Line;
                lineFormat.Weight = 5;

                // Set Dash Style
                lineFormat.DashStyle = lineDashStyle;

                // Provide some information in an adjacent cell to indicate dash style.
                currentRow[0, 5].Value = $"Dash Style: {lineDashStyle}";

                // Offset down 2 rows from the current row to prep next line.
                currentRow = currentRow.Offset(2, 0);
            }
        }
    }
}
