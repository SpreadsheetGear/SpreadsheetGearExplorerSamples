namespace SamplesLibrary.Samples.Shapes.Lines
{
    public class LineWeightSample : ISpreadsheetGearEngineSample
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

            // Loop will generate increasingly thicker lines.
            for (int i = 0; i < 12; i++)
            {
                // Calculate Weight (in Points).
                double weight = i * 2 + 1;

                // Position line relative to "currentRow" and add a slight slope to it.
                double yStart = windowInfo.RowToPoints(currentRow.Row) - 5;
                double yEnd = yStart + 10;

                // Add the line and set its weight.
                SpreadsheetGear.Shapes.IShape lineShape = worksheet.Shapes.AddLine(xStart, yStart,
                    xEnd, yEnd);
                SpreadsheetGear.Shapes.ILineFormat lineFormat = lineShape.Line;
                lineFormat.Weight = weight;

                // Provide some information in an adjacent cell to indicate line weight.
                currentRow[0, 5].Value = $"Weight: {weight}";

                // Offset down 2 rows from the current row to prep next line.
                currentRow = currentRow.Offset(2, 0);
            }
        }
    }
}
