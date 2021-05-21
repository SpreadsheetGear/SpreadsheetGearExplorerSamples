namespace SamplesLibrary.Samples.Workbook
{
    public class SavingAndOpeningEncryptedSample : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Create a new file and add a bit of data to it and a message indicating running the sample
            // doesn't visually do anything.
            Workbook = SpreadsheetGear.Factory.GetWorkbook();
            SpreadsheetGear.IWorksheet worksheet = Workbook.ActiveWorksheet;
            SpreadsheetGear.IRange cells = worksheet.Cells;
            cells["A:A"].ColumnWidth = 75;
            cells["A1"].Value = "Hello World!";
            cells["A3:A5"].Merge();
            cells["A3"].WrapText = true;
            cells["A3"].Value = "Note this sample won't visually appear to do anything when run, as it mainly " +
                "just demonstrates usage of the API to open and save files.  You can examine the 'Temp' folder " +
                "under the executing folder to confirm that files are being saved.";
        }

        public void RunSample()
        {
            // Get path to the Output (under "bin") folder, as this is where the "Temp" directory is located and where the
            // workbook files will be saved and opened.
            string outputFolderPath = Helpers.GetFullOutputFolderPath();

            // Password-protect and encrypt a workbook by passing in a password as the third argument
            // to the IWorkbook.SaveAs(...) method.  You can find this file in the "Temp" directory
            // under the executing directory.
            Workbook.SaveAs($@"{outputFolderPath}\Temp\EncryptedWorkbook.xlsx", SpreadsheetGear.FileFormat.OpenXMLWorkbook, 
                "MyPassword");

            // To open an encrypted workbook you must first create an IWorkbookSet.
            using (SpreadsheetGear.IWorkbookSet workbookSet = SpreadsheetGear.Factory.GetWorkbookSet())
            {

                // Then use the IWorkbookSet.Workbooks.Open(...) method that accepts a password as the second parameter.
                workbookSet.Workbooks.Open($@"{outputFolderPath}\Temp\EncryptedWorkbook.xlsx", "MyPassword");

                // Similar overloads are available to open streams or byte[] arrays of workbooks:
                //   - IWorkbookSet.Workbooks.OpenFromStream(stream, password)
                //   - IWorkbookSet.Workbooks.OpenFromStream(byteArray, password)
            }
        }
    }
}
