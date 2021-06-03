namespace SamplesLibrary.Samples.DataGrid
{
    public class SpreadsheetToDataGridFormattedSample : ISpreadsheetGearWindowsSample
    {
        public System.Data.DataTable GenerateDataTable()
        {
            // Get the full path to an XML file.
            string xmlPath = Helpers.GetFullOutputFolderPath(@"Files\Windows\SpiceOrder.xml");

            // Create a DataSet from an XML file and retrieve an order table.
            System.Data.DataSet dataset = new System.Data.DataSet();
            dataset.ReadXml(xmlPath);
            System.Data.DataTable datatable = dataset.Tables["OrderItems"];

            // Create a new workbook set, which will default to using the "en-US" CultureInfo (pass in
            // some other CultureInfo as the first argument if desired).
            using (SpreadsheetGear.IWorkbookSet workbookSet = SpreadsheetGear.Factory.GetWorkbookSet())
            {
                // Get the full path to a workbook template file, which contains number formats and formulas. 
                string workbookPath = Helpers.GetFullOutputFolderPath(@"Files\Windows\SpiceOrderTemplate.xls");

                // Open the template workbook and get an IRange from a defined name.
                SpreadsheetGear.IWorkbook workbook = workbookSet.Workbooks.Open(workbookPath);
                SpreadsheetGear.IRange range = workbook.Names["SetDataRange"].RefersToRange;

                // Insert the DataTable into the template worksheet range.  The InsertCells flag will 
                // cause the formatted range to be adjusted for the inserted data.
                range.CopyFromDataTable(datatable, SpreadsheetGear.Data.SetDataFlags.InsertCells);

                // Retrieve a DataSet from a defined name which includes the formatted range.
                System.Data.DataSet datasetOutput = workbook.GetDataSet("GetDataRange", 
                    SpreadsheetGear.Data.GetDataFlags.FormattedText);

                // Return the first (and only in this case) DataTable in the DataSet.
                return datasetOutput.Tables[0];
            }
        }
    }
}
