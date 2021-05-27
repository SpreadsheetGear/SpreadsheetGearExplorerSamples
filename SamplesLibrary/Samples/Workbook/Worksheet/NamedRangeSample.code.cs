namespace SamplesLibrary.Samples.Workbook.Worksheet
{
    public class NamedRangeSample : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Create a new workbook with 2 worksheets.
            Workbook = SpreadsheetGear.Factory.GetWorkbook();
            Workbook.Worksheets.Add();
        }

        public void RunSample()
        {
            // Create some local variables to each worksheet.
            SpreadsheetGear.IWorksheet sheet1 = Workbook.Worksheets["Sheet1"];
            SpreadsheetGear.IWorksheet sheet2 = Workbook.Worksheets["Sheet2"];

            // Create a named range called "MyName" on Sheet1!A1 and use it in a formula in A2
            sheet1.Cells["A1"].Value = "Hello";
            sheet1.Names.Add("MyName", "=$A$1");
            sheet1.Cells["A2"].Formula = "=MyName";

            // Create an identical named range setup, but on Sheet2.
            sheet2.Cells["A1"].Value = "World";
            sheet2.Names.Add("MyName", "=$A$1");
            sheet2.Cells["A2"].Formula = "=MyName";

            // Check value for each defined name on each sheet.
            System.Console.WriteLine(sheet1.Cells["MyName"].Value);    // OUTPUT: Hello
            System.Console.WriteLine(sheet2.Cells["MyName"].Value);    // OUTPUT: World

            // Other named range details
            {
                // Access names from IWorksheet.Names[...] by either name or index (names are 
                // stored in ascending alphabetical order).
                SpreadsheetGear.IName name = sheet1.Names["MyName"];

                // Rename a named range.
                name.Name = "MyNewName";

                // Add a comment.
                name.Comment = "My comment about this named range.";

                // Set to false to omit this name from the list of displayed names in Excel's 
                // "Name Manager" dialog and SpreadsheetGear's WorkbookExplorer dialog.
                name.Visible = false;

                // Returns an IRange of the range for which this named range refers to.  For 
                // names that don't refer to a range, null is returned.
                SpreadsheetGear.IRange range = name.RefersToRange;
                System.Console.WriteLine(range.Address);   // OUTPUT: $A$1

                // Returns a string representation of what the named range refers to, in A1 
                // notation.
                System.Console.WriteLine(name.RefersTo);   // OUTPUT: =Sheet1!$A$1

                // Returns a string representation of what the named range refers to, in R1C1
                // notation.
                System.Console.WriteLine(name.RefersToR1C1);   // OUTPUT: =Sheet1!R1C1
            }
        }
    }
}
