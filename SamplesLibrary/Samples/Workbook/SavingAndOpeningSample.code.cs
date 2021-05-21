namespace SamplesLibrary.Samples.Workbook
{
    public class SavingAndOpeningSample : ISpreadsheetGearEngineSample
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

            // Supported file formats can be found in the SpreadsheetGear.FileFormat enum:
            //  - OpenXMLWorkbook - Excel Open XML (*.xlsx)
            //  - OpenXMLWorkbookMacroEnabled - Macro-Enabled Excel Open XML (*.xlsm)
            //  - Excel8 - Excel 97-2003 (*.xls)
            //  - CSV - ASCII text-based comma-delimited (*.csv)
            //  - UnicodeText - Unicode text-based tab-delimited (*.txt)

            // Save to file on disk with IWorkbook.SaveAs(...).  You can find these files in the "Temp" directory
            // under the executing directory.
            Workbook.SaveAs($@"{outputFolderPath}\Temp\Workbook.xlsx", SpreadsheetGear.FileFormat.OpenXMLWorkbook);
            Workbook.SaveAs($@"{outputFolderPath}\Temp\Workbook.xlsm", SpreadsheetGear.FileFormat.OpenXMLWorkbookMacroEnabled);
            Workbook.SaveAs($@"{outputFolderPath}\Temp\Workbook.xls", SpreadsheetGear.FileFormat.Excel8);
            Workbook.SaveAs($@"{outputFolderPath}\Temp\Workbook.csv", SpreadsheetGear.FileFormat.CSV);
            Workbook.SaveAs($@"{outputFolderPath}\Temp\Workbook.txt", SpreadsheetGear.FileFormat.UnicodeText);

            // Save to a Stream with IWorkbook.SaveToStream(...)
            System.IO.Stream workbookStream = Workbook.SaveToStream(SpreadsheetGear.FileFormat.OpenXMLWorkbook);

            // Save to a byte[] array with IWorkbook.SaveToStream(...)
            byte[] workbookBytes = Workbook.SaveToMemory(SpreadsheetGear.FileFormat.OpenXMLWorkbook);

            // Open from disk using Factory.GetWorkbook(...).  SpreadsheetGear will automatically detect the 
            // file format and open appropriately.
            SpreadsheetGear.IWorkbook workbook1 = 
                SpreadsheetGear.Factory.GetWorkbook($@"{outputFolderPath}\Temp\Workbook.xlsx");

            // Alternatively, you can open a workbook by first creating an IWorkbookSet.  This allows you
            // to open a workbook on disk...
            using (SpreadsheetGear.IWorkbookSet workbookSet = SpreadsheetGear.Factory.GetWorkbookSet())
            {
                // Open file on disk.
                SpreadsheetGear.IWorkbook workbookFromDisk = 
                    workbookSet.Workbooks.Open($@"{outputFolderPath}\Temp\Workbook.xlsx");

                // Do something with workbook...
            }

            // ...or stream...
            using (SpreadsheetGear.IWorkbookSet workbookSet = SpreadsheetGear.Factory.GetWorkbookSet())
            {
                // Open file from stream.
                SpreadsheetGear.IWorkbook workbookFromStream = workbookSet.Workbooks.OpenFromStream(workbookStream);

                // Do something with workbook...
            }

            // ...or byte array...
            using (SpreadsheetGear.IWorkbookSet workbookSet = SpreadsheetGear.Factory.GetWorkbookSet())
            {
                // Open file on disk.
                SpreadsheetGear.IWorkbook workbookFromBytes = workbookSet.Workbooks.OpenFromMemory(workbookBytes);

                // Do something with workbook...
            }

            // Properly dispose of workbook set created by workbook1 to avoid issues with the free mode that
            // these samples run under.
            workbook1.WorkbookSet.Dispose();
        }
    }
}
