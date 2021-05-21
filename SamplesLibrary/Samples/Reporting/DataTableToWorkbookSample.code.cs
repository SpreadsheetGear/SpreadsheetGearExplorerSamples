namespace SamplesLibrary.Samples.Reporting
{
    public class DataTableToWorkbookSample : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Create a new workbook that will hold the final report.
            Workbook = SpreadsheetGear.Factory.GetWorkbook();
        }

        public void RunSample()
        {
            // Get the full path to an XML file.
            string xmlPath = Helpers.GetFullOutputFolderPath(@"Files\Engine\SpiceOrder.xml");

            // Create a DataSet from an XML file.
            System.Data.DataSet dataset = new System.Data.DataSet();
            dataset.ReadXml(xmlPath);
            System.Data.DataTable datatable = dataset.Tables["OrderItems"];

            // Get a worksheet reference.
            SpreadsheetGear.IWorksheet worksheet = Workbook.Worksheets[0];
            // Set the worksheet name.
            worksheet.Name = "Spice Order";

            // Get the top left cell for the DataTable.
            SpreadsheetGear.IRange cell = worksheet.Cells["A1"];

            // Copy the DataTable to the worksheet range.
            cell.CopyFromDataTable(
                datatable, SpreadsheetGear.Data.SetDataFlags.None);

            // Auto size all worksheet columns which contain data.
            worksheet.UsedRange.Columns.AutoFit();
        }
    }
}
