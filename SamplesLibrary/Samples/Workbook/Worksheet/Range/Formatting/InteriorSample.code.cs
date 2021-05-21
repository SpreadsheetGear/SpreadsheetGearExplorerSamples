namespace SamplesLibrary.Samples.Workbook.Worksheet.Range.Formatting
{
    public class InteriorSample : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Create a new workbook.
            Workbook = SpreadsheetGear.Factory.GetWorkbook();
        }

        public void RunSample()
        {
            // Create some local variables to the active worksheet and its cells.
            SpreadsheetGear.IWorksheet worksheet = Workbook.ActiveWorksheet;
            SpreadsheetGear.IRange cells = worksheet.Cells;

            // EXAMPLE 1: Set a variety of colors for the following cells
            {
                cells["B2"].Interior.Color = SpreadsheetGear.Colors.Red;
                cells["C2"].Interior.Color = SpreadsheetGear.Colors.Orange;
                cells["D2"].Interior.Color = SpreadsheetGear.Colors.Yellow;
                cells["E2"].Interior.Color = SpreadsheetGear.Colors.Green;
                cells["F2"].Interior.Color = SpreadsheetGear.Colors.Blue;
                cells["G2"].Interior.Color = SpreadsheetGear.Colors.Purple;
            }

            // EXAMPLE 2: Use theme colors in combination with "tint and shade" 
            // to demonstrate creating a fuller range of colors.
            {
                SpreadsheetGear.Themes.ColorSchemeIndex[] themeColors = {
                    SpreadsheetGear.Themes.ColorSchemeIndex.Accent1,
                    SpreadsheetGear.Themes.ColorSchemeIndex.Accent2,
                    SpreadsheetGear.Themes.ColorSchemeIndex.Accent3,
                    SpreadsheetGear.Themes.ColorSchemeIndex.Accent4,
                    SpreadsheetGear.Themes.ColorSchemeIndex.Accent5,
                    SpreadsheetGear.Themes.ColorSchemeIndex.Accent6
                };

                // Iterate through each theme color and set some range based 
                // off startingRange.
                SpreadsheetGear.IRange startingRange = cells["B4:B17"];
                for (int i = 0; i < themeColors.Length; i++)
                {
                    SpreadsheetGear.IRange currentRange = startingRange.Offset(0, i);

                    // Set the whole range to use the specified theme color.
                    currentRange.Interior.ThemeColor = themeColors[i];

                    // TintAndShade values of 1.0 and -1.0 indicate white and black, 
                    // respectively.  Setting limits here to avoid displaying these max 
                    // B&W values.
                    double brightnessLimit = 0.9;
                    double darknessLimit = -0.9;

                    // Gradually darken the theme color as we iterate down the range
                    for (int j = 0; j < currentRange.RowCount; j++)
                    {
                        currentRange[j, 0].Interior.TintAndShade = brightnessLimit -
                            (((double)j / (double)currentRange.RowCount) *
                            (brightnessLimit - darknessLimit));
                    }
                }
            }

            // EXAMPLE 3: Set I2:J4 to a red and yellow pattern.
            {
                SpreadsheetGear.IInterior interior = cells["I2:J4"].Interior;
                interior.Color = SpreadsheetGear.Colors.Red;
                interior.Pattern = SpreadsheetGear.Pattern.Gray16;
                interior.PatternColor = SpreadsheetGear.Colors.Yellow;
            }

            // EXAMPLE 4: Set each cell in I6:J8 to a linear gradient.
            {
                SpreadsheetGear.IInterior interior = cells["I6:J8"].Interior;
                interior.Pattern = SpreadsheetGear.Pattern.LinearGradient;

                // Get a reference to the linear gradient.
                SpreadsheetGear.ILinearGradient linearGradient =
                    interior.Gradient as SpreadsheetGear.ILinearGradient;

                // Set the angle of the linear gradient to 90 degrees.
                linearGradient.Degree = 45;
            }

            // EXAMPLE 5: Set I10:J12 to a rectangular gradient.
            {
                SpreadsheetGear.IInterior interior = cells["I10:J12"].Interior;
                interior.Pattern = SpreadsheetGear.Pattern.RectangularGradient;

                // Merge the cells.
                cells["I10:J12"].Merge();

                // Get a reference to the rectangular gradient.
                SpreadsheetGear.IRectangularGradient rectGradient =
                    interior.Gradient as SpreadsheetGear.IRectangularGradient;

                // Set the rectangular gradient to fill from center.
                rectGradient.RectangleBottom = 0.5;
                rectGradient.RectangleLeft = 0.5;
                rectGradient.RectangleRight = 0.5;
                rectGradient.RectangleTop = 0.5;

                // Get a reference to the rectangular gradient color stops.
                SpreadsheetGear.IColorStops colorStops = rectGradient.ColorStops;

                // Clear the default color stops.
                colorStops.Clear();

                // Add custom color stops.
                colorStops.Add(0.0).Color = SpreadsheetGear.Colors.White;
                colorStops.Add(1.0).ThemeColor = SpreadsheetGear.Themes.ColorSchemeIndex.Accent6;
            }
        }
    }
}
