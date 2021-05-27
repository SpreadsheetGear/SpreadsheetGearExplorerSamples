namespace SamplesLibrary.Samples.Workbook.Worksheet.Range.Formatting
{
    public class BordersSample : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Create a new workbook.
            Workbook = SpreadsheetGear.Factory.GetWorkbook();
        }

        public void RunSample()
        {
            // Create a local variable to the active worksheet.
            SpreadsheetGear.IWorksheet worksheet = Workbook.ActiveWorksheet;

            // Used throughout the below samples to set border formats.
            SpreadsheetGear.IBorder border;

            // Setup range to change borders.
            SpreadsheetGear.IRange range = worksheet.Cells["B2:D8"];

            // EXAMPLE 1: Set top border style.
            {
                // Get a reference to the top border of the range.
                border = range.Borders[SpreadsheetGear.BordersIndex.EdgeTop];

                // Set the border LineStyle, Weight, and Color.
                border.LineStyle = SpreadsheetGear.LineStyle.Continuous;
                border.Weight = SpreadsheetGear.BorderWeight.Thick;
                border.Color = SpreadsheetGear.Colors.Blue;
            }

            // EXAMPLE 2: Set left border style.
            {
                // Get a reference to the left border of the range.
                border = range.Borders[SpreadsheetGear.BordersIndex.EdgeLeft];

                // Set the border LineStyle, Weight, and Color.
                border.LineStyle = SpreadsheetGear.LineStyle.Continuous;
                border.Weight = SpreadsheetGear.BorderWeight.Medium;
                border.ThemeColor = SpreadsheetGear.Themes.ColorSchemeIndex.Accent1;
            }

            // EXAMPLE 3: Set bottom border style.
            {
                // Get a reference to the bottom border of the range.
                border = range.Borders[SpreadsheetGear.BordersIndex.EdgeBottom];

                // Set the border LineStyle, Weight, and Color.
                border.LineStyle = SpreadsheetGear.LineStyle.Continuous;
                border.Weight = SpreadsheetGear.BorderWeight.Thin;
                border.ThemeColor = SpreadsheetGear.Themes.ColorSchemeIndex.Accent2;
                border.TintAndShade = -0.5;
            }

            // EXAMPLE 4: Set right border style.
            {
                // Get a reference to the right border of the range.
                border = range.Borders[SpreadsheetGear.BordersIndex.EdgeRight];

                // Set the border LineStyle, Weight, and Color.
                border.LineStyle = SpreadsheetGear.LineStyle.Double;
                border.Weight = SpreadsheetGear.BorderWeight.Thick;
                border.Color = SpreadsheetGear.Color.FromArgb(255, 0, 0);
            }

            // EXAMPLE 5: Set inside horizontal borders style.
            {
                // Get a reference to the inside horizontal borders of the range.
                border = range.Borders[SpreadsheetGear.BordersIndex.InsideHorizontal];

                // Set the border LineStyle, Weight, and Color.
                border.LineStyle = SpreadsheetGear.LineStyle.Continuous;
                border.Weight = SpreadsheetGear.BorderWeight.Thin;
                border.ColorIndex = 23;
            }

            // EXAMPLE 6: Set inside vertical borders style.
            {
                // Get a reference to the inside vertical borders of the range.
                border = range.Borders[SpreadsheetGear.BordersIndex.InsideVertical];

                // Set the border LineStyle, Weight, and Color.
                border.LineStyle = SpreadsheetGear.LineStyle.Continuous;
                border.Weight = SpreadsheetGear.BorderWeight.Thin;
                border.Color = SpreadsheetGear.Colors.Black;
            }

            // EXAMPLE 7: Set all borders at once.
            {
                // Get a reference to the range to change borders.
                range = worksheet.Cells["B10:D16"];

                // Get a reference to the inside vertical borders of the range.
                SpreadsheetGear.IBorders borders = range.Borders;

                // Set the border LineStyle, Weight, and Color.
                borders.LineStyle = SpreadsheetGear.LineStyle.Continuous;
                borders.Weight = SpreadsheetGear.BorderWeight.Medium;
                borders.Color = SpreadsheetGear.Colors.Orange;
            }
        }
    }
}
