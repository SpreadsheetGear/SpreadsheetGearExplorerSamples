namespace SamplesLibrary.Samples.DataGrid
{
    public class SpreadsheetToDataGridSample : ISpreadsheetGearWindowsSample
    {
        public System.Data.DataTable GenerateDataTable()
        {
            // Create a new workbook set, which will default to using the "en-US" CultureInfo (pass in
            // some other CultureInfo as the first argument if desired).
            using (SpreadsheetGear.IWorkbookSet workbookSet = SpreadsheetGear.Factory.GetWorkbookSet())
            {
                // Get the full path to a workbook file.
                string workbookPath = Helpers.GetFullOutputFolderPath(@"Files\Windows\SpiceOrder.xlsx");

                // Open workbook using the current culture.
                SpreadsheetGear.IWorkbook workbook = workbookSet.Workbooks.Open(workbookPath);

                // Get a DataSet from an existing defined name.
                System.Data.DataSet dataSet = workbook.GetDataSet("orderrange", 
                    SpreadsheetGear.Data.GetDataFlags.FormattedText);

                // Return the first (and only in this case) DataTable in the DataSet.
                return dataSet.Tables[0];
            }
        }
    }
}
