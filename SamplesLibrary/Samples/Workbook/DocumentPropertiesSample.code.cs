namespace SamplesLibrary.Samples.Workbook
{
    public class DocumentPropertiesSample : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Create a new workbook.
            Workbook = SpreadsheetGear.Factory.GetWorkbook();
        }

        public void RunSample()
        {
            // Set some of the Built-In Properties.
            SpreadsheetGear.IBuiltinDocumentProperties builtInProps =
                    Workbook.BuiltinDocumentProperties;
            builtInProps.Author = "John Doe";
            builtInProps.Subject = "My Subject";
            builtInProps.Title = "My Title Document Property";
            builtInProps.Category = "Spreadsheet Component Software";
            builtInProps.Keywords = "Spreadsheet, Excel, .NET";
            builtInProps.Comments = "This is a comment.";
            builtInProps.ContentStatus = "This is the status";

            // Create some Custom Properties
            SpreadsheetGear.IDocumentProperties customProps = Workbook.CustomDocumentProperties;
            customProps.Add("My Text Prop", "My Text Value");
            customProps.Add("My Date Prop", new System.DateTime(2000, 1, 1));
            customProps.Add("My Boolean Prop", true);
            customProps.Add("My Number Prop", 123.456);

            // Note about how to view the results
            Workbook.ActiveWorksheet.Cells["A1:F9"].Merge();
            Workbook.ActiveWorksheet.Cells["A1:F9"].WrapText = true;
            Workbook.ActiveWorksheet.Cells["A1"].Value = "If viewing this workbook in a SpreadsheetGear " +
                "WorkbookView control, right-click on the WorkbookView and select the 'Workbook Explorer...' " +
                "context menu option.  In the TreeView on the left pane, you should find a 'Document Properties' " +
                "node where you can view the above-created properties.  If this file was saved to disk, to view " +
                "Document Properties in Microsoft Excel, open the resultant file and go to the Ribbon > File > " +
                "Info, the view the Properties on the right side of the  pane.  Additional properties are " +
                "available by clicking on Properties and selecting 'Advanced Properties'. ";
        }
    }
}
