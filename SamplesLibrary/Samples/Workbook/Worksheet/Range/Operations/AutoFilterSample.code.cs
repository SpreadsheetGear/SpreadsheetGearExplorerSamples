namespace SamplesLibrary.Samples.Workbook.Worksheet.Range.Operations
{
    public class AutoFilterSample : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Get the full path to a workbook with some data that we can apply AutoFilters to. The workbook 
            // contains 10 different sheets--each will be AutoFiltered using different criteria.
            string workbookPath = Helpers.GetFullOutputFolderPath(@"Files\Engine\AutoFilterSampleData.xlsx");

            // Open the workbook. 
            Workbook = SpreadsheetGear.Factory.GetWorkbook(workbookPath);
        }

        public void RunSample()
        {
            // EXAMPLE 1: Single Product Filter
            {
                // Get a reference to the relevant worksheet.
                SpreadsheetGear.IWorksheet worksheet = Workbook.Worksheets["Single Product"];

                // Initialize the zero-based field index within the auto filter range.
                int field = 0;

                // Initialize criteria1 as a single product name.
                string criteria1 = "Thyme";

                // Filter by a single product.  SpreadsheetGear will automatically expand the
                // A1 reference to include in the AutoFilter all cells in the surrounding region.
                worksheet.Cells["A1"].AutoFilter(field, criteria1,
                    SpreadsheetGear.AutoFilterOperator.Or, null, true);
            }

            // EXAMPLE 2: Multiple Products Filter
            {
                // Get a reference to the relevant worksheet.
                SpreadsheetGear.IWorksheet worksheet = Workbook.Worksheets["Multiple Products"];

                // Initialize the zero-based field index within the auto filter range.
                int field = 0;

                // Initialize criteria1 as an array of product names.
                string[] criteria1 = new string[3] { "Marjoram", "Oregano", "Rosemary" };

                // Filter by multiple products.
                worksheet.Cells["A1"].AutoFilter(field, criteria1,
                    SpreadsheetGear.AutoFilterOperator.Values, null, true);
            }

            // EXAMPLE 3: Top 10 Items Filter
            {
                // Get a reference to the relevant worksheet.
                SpreadsheetGear.IWorksheet worksheet = Workbook.Worksheets["Top Items"];

                // Initialize the field index within the auto filter range.
                int field = 2;

                // Initialize criteria1 as the number of top items.
                int criteria1 = 5;

                // Filter by Q1 Top Items.
                worksheet.Cells["A1"].AutoFilter(field, criteria1,
                    SpreadsheetGear.AutoFilterOperator.Top10Items, null, true);
            }

            // EXAMPLE 4: Top 10% Filter
            {
                // Get a reference to the relevant worksheet.
                SpreadsheetGear.IWorksheet worksheet = Workbook.Worksheets["Top Percent"];

                // Initialize the field index within the auto filter range.
                int field = 3;

                // Initialize criteria1 as a percentage of top items.
                int criteria1 = 10;

                // Filter by Q2 Top Percent.
                worksheet.Cells["A1"].AutoFilter(field, criteria1,
                    SpreadsheetGear.AutoFilterOperator.Top10Percent, null, true);
            }

            // EXAMPLE 5: Bottom 10 Items Filter
            {
                // Get a reference to the relevant worksheet.
                SpreadsheetGear.IWorksheet worksheet = Workbook.Worksheets["Bottom Items"];

                // Initialize the field index within the auto filter range.
                int field = 4;

                // Initialize criteria1 as the number of bottom items.
                int criteria1 = 7;

                // Filter by Q3 Bottom Items.
                worksheet.Cells["A1"].AutoFilter(field, criteria1,
                    SpreadsheetGear.AutoFilterOperator.Bottom10Items, null, true);
            }

            // EXAMPLE 6: Bottom 10% Filter
            {
                // Get a reference to the relevant worksheet.
                SpreadsheetGear.IWorksheet worksheet = Workbook.Worksheets["Bottom Percent"];

                // Initialize the field index within the auto filter range.
                int field = 5;

                // Initialize criteria1 as a percentage of bottom items.
                int criteria1 = 10;

                // Filter by Q4 Bottom Percent.
                worksheet.Cells["A1"].AutoFilter(field, criteria1,
                    SpreadsheetGear.AutoFilterOperator.Bottom10Percent, null, true);
            }

            // EXAMPLE 7: Greater Than Filter
            {
                // Get a reference to the relevant worksheet.
                SpreadsheetGear.IWorksheet worksheet = Workbook.Worksheets["Greater Than"];

                // Initialize the field index within the auto filter range.
                int field = 2;

                // Initialize criteria1 using the greater than operator.
                string criteria1 = ">1850";

                // Filter by Q1 Greater Than.
                worksheet.Cells["A1"].AutoFilter(field, criteria1,
                    SpreadsheetGear.AutoFilterOperator.Or, null, true);
            }

            // EXAMPLE 8: Between Filter
            {
                // Get a reference to the relevant worksheet.
                SpreadsheetGear.IWorksheet worksheet = Workbook.Worksheets["Between"];

                // Initialize the field index within the auto filter range.
                int field = 3;

                // Initialize criteria1 using the greater than or equal to operator.
                string criteria1 = ">=1200";

                // Initialize criteria2 using the less than or equal to operator.
                string criteria2 = "<=1400";

                // Filter by Q2 Between.
                worksheet.Cells["A1"].AutoFilter(field, criteria1,
                    SpreadsheetGear.AutoFilterOperator.And, criteria2, true);
            }

            // EXAMPLE 9: Cell Interior Color Filter
            {
                // Get a reference to the relevant worksheet.
                SpreadsheetGear.IWorksheet worksheet = Workbook.Worksheets["Green Color"];

                // Initialize the field index within the auto filter range.
                int field = 4;

                // Initialize criteria1 with a color.
                SpreadsheetGear.Color criteria1 = SpreadsheetGear.Colors.SeaGreen;

                // Filter by Q3 Color.
                worksheet.Cells["A1"].AutoFilter(field, criteria1,
                    SpreadsheetGear.AutoFilterOperator.CellColor, null, true);
            }

            // EXAMPLE 10: Red Conditional Format Icon Filter
            {
                // Get a reference to the relevant worksheet.
                SpreadsheetGear.IWorksheet worksheet = Workbook.Worksheets["Red Icon"];

                // Initialize the field index within the auto filter range.
                int field = 5;

                // Initialize criteria1 with the first icon in the ThreeTrafficLights1 icon set.
                SpreadsheetGear.IIcon criteria1 =
                    Workbook.IconSets[SpreadsheetGear.IconSet.ThreeTrafficLights1][0];

                // Filter by Q4 Icon.
                worksheet.Cells["A1"].AutoFilter(field, criteria1,
                    SpreadsheetGear.AutoFilterOperator.Icon, null, true);
            }
        }
    }
}
