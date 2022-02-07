using System;
using System.Linq;

namespace SamplesLibrary.Samples.Shapes.Lines
{
    public class ArrowheadsSample : ISpreadsheetGearEngineSample
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

            // Create an IEnumerable out of the various ArrowheadStyle enum options.  Note that
            // "Mixed" and "None" are excluded since these aren't applicable to this sample.
            var arrowheadStyles = Enum.GetValues(typeof(SpreadsheetGear.Shapes.ArrowheadStyle))
                .OfType<SpreadsheetGear.Shapes.ArrowheadStyle>()
                .Where(a => a != SpreadsheetGear.Shapes.ArrowheadStyle.Mixed &&
                    a != SpreadsheetGear.Shapes.ArrowheadStyle.None)
                .ToList();

            // Similarly, create an IEnumerable of ArrowheadLength options, excluding "Mixed".
            var arrowheadLengths = Enum.GetValues(typeof(SpreadsheetGear.Shapes.ArrowheadLength))
                .OfType<SpreadsheetGear.Shapes.ArrowheadLength>()
                .Where(a => a != SpreadsheetGear.Shapes.ArrowheadLength.Mixed)
                .ToList();

            // Similarly, create an IEnumerable of ArrowheadWidth options, excluding "Mixed".
            var arrowheadWidths = Enum.GetValues(typeof(SpreadsheetGear.Shapes.ArrowheadWidth))
                .OfType<SpreadsheetGear.Shapes.ArrowheadWidth>()
                .Where(a => a != SpreadsheetGear.Shapes.ArrowheadWidth.Mixed)
                .ToList();

            // Expand cell size so a line and its arrowheads better fits.
            worksheet.Cells.RowHeight = 38;
            worksheet.Cells.ColumnWidth = 26;

            // Will use these two IRanges to "navigate" around the worksheet.  Since one IRange 
            // represents an entire row and the other an entire column, we can take the 
            // intersection of the two with IRange.Intersect(...) to isolate a specific cell
            // and add a line into it.
            SpreadsheetGear.IRange currentRow = worksheet.Cells["2:2"];
            SpreadsheetGear.IRange currentColumn = worksheet.Cells["B:B"];

            // To demonstrate including or omitting an End Arrowhead, we'll setup this counter
            // to only add an End Arrowhead on every other line added.
            int counter = 0;

            // Loop through various Arrowhead Styles--one style for each column across the sheet.
            foreach (SpreadsheetGear.Shapes.ArrowheadStyle arrowheadStyle in arrowheadStyles)
            {
                // Take intersection of "currentColumn" and Row 1:1 to isolate the row header
                // cell and set its value to the Arrowhead Style.
                SpreadsheetGear.IRange rowHeaderCell = currentColumn.Intersect(worksheet.Cells["1:1"]);
                rowHeaderCell.Value = arrowheadStyle.ToString();

                // Loop through each Arrowhead Width
                foreach (SpreadsheetGear.Shapes.ArrowheadWidth arrowheadWidth in arrowheadWidths)
                {
                    // Also loop through each Arrowhead Length
                    foreach (SpreadsheetGear.Shapes.ArrowheadLength arrowheadLength in arrowheadLengths)
                    {
                        // Take intersection of "currentRow" and Column A to isolate the column 
                        // header cell and set its value to the ArrowheadWidth and ArrowheadLength
                        // enum values
                        // being used.
                        SpreadsheetGear.IRange headerCol =
                            currentRow.Intersect(worksheet.Cells["A:A"]);
                        headerCol.Value = $"Arrowhead Width: {arrowheadWidth}\r\n" +
                            $"Arrowhead Height: {arrowheadLength}";

                        // Take intersection of current row and column to isolate the cell that we
                        // will add the line to.
                        SpreadsheetGear.IRange currentCell = currentRow.Intersect(currentColumn);

                        // Calculate the position of the line.
                        double xStart = windowInfo.ColumnToPoints(currentCell.Column) + 20;
                        double yStart = windowInfo.RowToPoints(currentCell.Row) + 15;
                        double xEnd = windowInfo.ColumnToPoints(currentCell.Column + 1) - 20;
                        double yEnd = windowInfo.RowToPoints(currentCell.Row + 1) - 15;

                        // Add the line and get its ILineFormat.
                        SpreadsheetGear.Shapes.IShape lineShape = worksheet.Shapes.AddLine(xStart,
                            yStart, xEnd, yEnd);
                        SpreadsheetGear.Shapes.ILineFormat lineFormat = lineShape.Line;

                        // Set the Arrowhead Style, Width and Length values.
                        lineFormat.BeginArrowheadStyle = arrowheadStyle;
                        lineFormat.BeginArrowheadWidth = arrowheadWidth;
                        lineFormat.BeginArrowheadLength = arrowheadLength;

                        // For every other line added, will do the same for the End Arrowhead.
                        if (counter % 2 == 0)
                        {
                            lineFormat.EndArrowheadStyle = arrowheadStyle;
                            lineFormat.EndArrowheadWidth = arrowheadWidth;
                            lineFormat.EndArrowheadLength = arrowheadLength;
                        }

                        // Set the weight of the line to 5 Points.
                        lineFormat.Weight = 5;

                        // Choose a random Theme Color to apply to this line.
                        lineFormat.ForeColor.ThemeColor = PickRandomThemeColor();

                        // Move the currentRow down one row and advance the End Arrowhead counter.
                        currentRow = currentRow.Offset(1, 0);
                        counter++;
                    }
                }
                // Move the currentColumn right one column and reset the currentRow back to 2:2.
                currentColumn = currentColumn.Offset(0, 1);
                currentRow = worksheet.Cells["2:2"];
            }

            // Setup some formatting of the header content.
            worksheet.UsedRange.HorizontalAlignment = SpreadsheetGear.HAlign.Center;
            worksheet.UsedRange.VerticalAlignment = SpreadsheetGear.VAlign.Center;
            worksheet.UsedRange.Font.Bold = true;
        }

        private static readonly Random _rand = new Random();
        private static SpreadsheetGear.Themes.ColorSchemeIndex PickRandomThemeColor()
        {
            // Construct a List from the ColorSchemeIndex enum that consists of the 6 "Accent"
            // colors as well as Text1 (black).
            var colors = Enum.GetValues(typeof(SpreadsheetGear.Themes.ColorSchemeIndex))
                .OfType<SpreadsheetGear.Themes.ColorSchemeIndex>()
                .Where(c =>
                    c.ToString().Contains("Accent") ||
                    c == SpreadsheetGear.Themes.ColorSchemeIndex.Text1)
                .ToList();

            // Return random color from list.
            return colors[_rand.Next(colors.Count)];
        }

    }
}
