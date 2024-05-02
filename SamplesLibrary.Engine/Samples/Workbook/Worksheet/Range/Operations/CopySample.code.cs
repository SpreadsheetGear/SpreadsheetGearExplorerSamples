// NOTE: a version of this sample is available to run on our website at:
// https://www.spreadsheetgear.com/Support/Samples/API/RangeOperationsCopy

namespace SamplesLibrary.Engine.Samples.Workbook.Worksheet.Range.Operations
{
    public class CopySample : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Get the full path to a workbook with some data that we will copy to cells on the same
            // sheet in various ways.  Copying can also be done across sheets or across workbooks.
            string workbookPath = Helpers.GetFullOutputFolderPath(@"Files\Engine\CopyPasteData.xlsx");

            // Open the workbook. 
            Workbook = SpreadsheetGear.Factory.GetWorkbook(workbookPath);
        }

        public void RunSample()
        {
            // Get a reference to the relevant worksheet and its cells.
            SpreadsheetGear.IWorksheet worksheet = Workbook.Worksheets["Sheet1"];
            SpreadsheetGear.IRange cells = worksheet.Cells;

            // Range B3:B13 contains the data we'll be copying to other cells.
            SpreadsheetGear.IRange sourceRange = cells["B3:B13"];

            // Copy all aspects of the source range to the destination range of D3:D13.
            sourceRange.Copy(cells["D3:D13"]);

            // PasteTypes - specify what aspects of the source range you want to copy to the 
            // destination range.
            {
                // Copy values only.  Note for the destination range we pass just E3 and let
                // SpreadsheetGear expand this to the full paste range (E3:E13).
                sourceRange.Copy(cells["E3"], SpreadsheetGear.PasteType.Values, 
                    SpreadsheetGear.PasteOperation.None, false, false);

                // Copy Formulas.
                sourceRange.Copy(cells["F3"], SpreadsheetGear.PasteType.Formulas, 
                    SpreadsheetGear.PasteOperation.None, false, false);

                // Copy Formulas.
                sourceRange.Copy(cells["G3"], SpreadsheetGear.PasteType.Formats, 
                    SpreadsheetGear.PasteOperation.None, false, false);

                // Copy Comments.
                sourceRange.Copy(cells["H3"], SpreadsheetGear.PasteType.Comments, 
                    SpreadsheetGear.PasteOperation.None, false, false);

                // Copy All Except Borders.
                sourceRange.Copy(cells["I3"], SpreadsheetGear.PasteType.AllExceptBorders, 
                    SpreadsheetGear.PasteOperation.None, false, false);

                // Copy Values and Number Formats.
                sourceRange.Copy(cells["J3"], SpreadsheetGear.PasteType.ValuesAndNumberFormats, 
                    SpreadsheetGear.PasteOperation.None, false, false);

                // Copy Formulas and Number Formats.
                sourceRange.Copy(cells["K3"], SpreadsheetGear.PasteType.FormulasAndNumberFormats, 
                    SpreadsheetGear.PasteOperation.None, false, false);

                // Copy Column Widths.
                sourceRange.Copy(cells["L3"], SpreadsheetGear.PasteType.ColumnWidths, 
                    SpreadsheetGear.PasteOperation.None, false, false);

                // Copy Validation.  A Validation List is setup for cells D3:D7 and will get
                // copied to M3:M7.
                sourceRange.Copy(cells["M3"], SpreadsheetGear.PasteType.Validation, 
                    SpreadsheetGear.PasteOperation.None, false, false);
            }

            // Other Paste Options
            {
                // Skip Blanks will not copy blank cells in the source range, thereby preserving any
                // existing values in the destination range.  In this example, N8's value (in the
                // destination range) of 'Orig Data' will be persisted because B8 (in the source range)
                // is blank.
                cells["N3:N13"].Value = "Orig Data";
                sourceRange.Copy(cells["N3"], SpreadsheetGear.PasteType.All, 
                    SpreadsheetGear.PasteOperation.None, true, false);

                // Repeat source range when destination range is evenly "divisible" by the source
                // range.  In this example, the source range consists of 5 cells and the destination
                // range consists of 20 cells, so the source range will repeat 4 times into the
                // destination range.
                cells["D3:D7"].Copy(cells["O3:O22"]);

                // Transpose
                sourceRange.Copy(cells["D15"], SpreadsheetGear.PasteType.Values, 
                    SpreadsheetGear.PasteOperation.None, false, true);
            }

            // Paste Operations - apply simple arithmetic operations (add, subtract, multiply and
            // divide) when the source and destination ranges are both numeric.
            {
                // Addition - the source range values will be added to the destination range values
                // of 1, (i.e., 1+1=2, 1+2=3, 1+3=4, 1+4=5, 1+5=6).
                cells["D19:D23"].Value = 1.0;
                cells["B3:B7"].Copy(cells["D19:D23"], SpreadsheetGear.PasteType.Values, 
                    SpreadsheetGear.PasteOperation.Add, false, false);

                // Subtraction - the source range values will be subtracted from the destination range
                // values of 1 (i.e., 1-1=0, 1-2=-1, 1-3=-2, 1-4=-3, 1-5=-4).
                cells["E19:E23"].Value = 1.0;
                cells["B3:B7"].Copy(cells["E19:E23"], SpreadsheetGear.PasteType.Values, 
                    SpreadsheetGear.PasteOperation.Subtract, false, false);

                // Multiplication - the source range values will be multiplied by the destination range
                // values of 2 (i.e., 2*1=2, 2*2=4, 2*3=6, 2*4=8, 2*5=10).
                cells["F19:F23"].Value = 2.0;
                cells["B3:B7"].Copy(cells["F19:F23"], SpreadsheetGear.PasteType.Values, 
                    SpreadsheetGear.PasteOperation.Multiply, false, false);

                // Division - the destination range values of 2 will be divided by the source range values
                // (i.e., 2/1=2, 2/2=1, 2/3=0.667, 2/4=0.5, 2/5=0.4).
                cells["G19:G23"].Value = 2.0;
                cells["B3:B7"].Copy(cells["G19:G23"], SpreadsheetGear.PasteType.Values, 
                    SpreadsheetGear.PasteOperation.Divide, false, false);
            }
        }
    }
}
