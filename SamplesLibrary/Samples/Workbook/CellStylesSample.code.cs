namespace SamplesLibrary.Samples.Workbook
{
    public class CellStylesSample : ISpreadsheetGearEngineSample
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

            // SAMPLE 1 - Create a new custom Style
            {
                // Create a new Style and call it "Inverted".
                SpreadsheetGear.IStyle customStyle = Workbook.Styles.Add("Inverted");
                customStyle.Font.Color = SpreadsheetGear.Colors.White;
                customStyle.Interior.Color = SpreadsheetGear.Colors.Black;

                // Add some cell data to A1:A10.
                cells["A1:A10"].Value = "Hello World!";

                // Apply custom style to A6:A10
                cells["A6:A10"].Style = customStyle;
            }

            // SAMPLE 2 - Modify a Style
            {
                // Get the "Normal" Style which is used by all cells by default.  Note that
                // the "Normal" Style font settings are also used by the row and column header
                // text.
                SpreadsheetGear.IStyle normalStyle = Workbook.Styles["Normal"];

                // Modify it by making content horizontally centered.
                normalStyle.Font.Name = "Times New Roman";

                // Add some cell data to demonstrate changed style (A1:A5 and all other cells
                // will also use the "Normal" Cell Style).
                cells["C1:C10"].Value = "Hello World!";
            }

            // AutoFit columns to fit contents.
            worksheet.UsedRange.Columns.AutoFit();
        }
    }
}
