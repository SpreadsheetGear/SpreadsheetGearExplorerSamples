using System;
using System.Collections.Generic;
using System.Text;

namespace SamplesLibrary.Samples.Reporting
{
    public class DataSetToWorkbookSample : ISpreadsheetGearEngineSample
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
            string xmlPath = Helpers.GetFullOutputFolderPath(@"Files\Engine\NFL.xml");

            // Create a DataSet from an XML file.
            System.Data.DataSet dataset = new System.Data.DataSet();
            dataset.ReadXml(xmlPath);

            // Get the workbook set to also hold the template workbook alonside the report workbook.
            SpreadsheetGear.IWorkbookSet workbookSet = Workbook.WorkbookSet;

            // Get the full path to a workbook template file which contains formats, borders and formulas.
            string workbookPath = Helpers.GetFullOutputFolderPath(@"Files\Engine\NFLTemplate.xls");

            // Open the template workbook which contains formats, borders and formulas.
            SpreadsheetGear.IWorkbook templateWorkbook = workbookSet.Workbooks.Open(workbookPath);

            // Get the template range from a defined name in the template workbook.
            SpreadsheetGear.IRange templateRange =
                templateWorkbook.Names["NFLDivisionFormat"].RefersToRange;

            // Get the number of rows and columns in the template range.
            int templateRangeRowCount = templateRange.RowCount;
            int templateRangeColCount = templateRange.ColumnCount;

            // Get the worksheet to hold the new spreadsheet report.
            SpreadsheetGear.IWorksheet reportWorksheet = Workbook.Worksheets[0];
            reportWorksheet.WindowInfo.DisplayGridlines = false;
            reportWorksheet.Name = dataset.DataSetName;

            // Start at cell B2.
            int row = 1;
            int col = 1;

            // Insert each DataTable from the DataSet...
            foreach (System.Data.DataTable datatable in dataset.Tables)
            {
                // Get the destination range in the report worksheet.
                SpreadsheetGear.IRange dstRange = reportWorksheet.Cells[row, col,
                    row + templateRangeRowCount - 1, col + templateRangeColCount - 1];

                // Copy the template range formats and formulas to the report worksheet.
                templateRange.Copy(dstRange, SpreadsheetGear.PasteType.All,
                    SpreadsheetGear.PasteOperation.None, false, false);

                if (row == 1)
                {
                    // Copy the template range column widths to the report worksheet once.
                    templateRange.Copy(dstRange, SpreadsheetGear.PasteType.ColumnWidths,
                        SpreadsheetGear.PasteOperation.None, false, false);
                }

                // Use the TableName for the title of the range - this is a merged cell centered 
                // across the top of the destination range.
                reportWorksheet.Cells[row, col].Formula = datatable.TableName;

                // Add a defined name for the new destination range. This defined name will be 
                // adjusted by IRange.CopyFromDataTable, allowing us to skip over the newly inserted 
                // range and any summary rows added by the template.
                SpreadsheetGear.IName dstRangeName = Workbook.Names.Add(
                    datatable.TableName.Replace(" ", ""), "=" + dstRange.Address);

                // Insert the DataTable into the worksheet.  This will adjust the defined name, as 
                // well as the formats, cell borders and formulas which were copied from the template 
                // workbook.
                reportWorksheet.Cells[row + 1, col, row + 3, col].CopyFromDataTable(datatable,
                    SpreadsheetGear.Data.SetDataFlags.InsertCells);

                // Update the row counter to the end of the inserted table.
                SpreadsheetGear.IRange range = dstRangeName.RefersToRange;
                row = range.Row + range.RowCount + 1;
            }
        }
    }
}
