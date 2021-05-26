namespace WindowsFormsExplorer.Samples.Printing
{
    public partial class BasicPrintingSample : SGUserControl
    {
        // Most code for this Sample is in the SharedSamples project and can be run from either this WindowsFormsExplorer
        // project sample or a similar sample in the WindowsFormsExplorer project.
        public SharedSamples.Samples.Printing.BasicPrintingSample Sample { get; private set; }

        private void buttonPrint_Click(object sender, System.EventArgs e)
        {
            // Determine what to print...
            SpreadsheetGear.Printing.PrintWhat printWhat = GetPrintWhat();

            // Call into sample to print.
            Sample.Print(workbookView, printWhat);
        }

        private void buttonPrintPreview_Click(object sender, System.EventArgs e)
        {
            // Determine what to print...
            SpreadsheetGear.Printing.PrintWhat printWhat = GetPrintWhat();

            // Call into sample to open Windows' built-in Print Preview dialog.
            Sample.PrintPreview(workbookView, printWhat);
        }


        private SpreadsheetGear.Printing.PrintWhat GetPrintWhat()
        {
            SpreadsheetGear.Printing.PrintWhat printWhat;
            if (radioButtonSheet.Checked)
                // Print the active sheet.
                printWhat = SpreadsheetGear.Printing.PrintWhat.Sheet;
            else if (radioButtonWorkbook.Checked)
                // Print the entire workbook.
                printWhat = SpreadsheetGear.Printing.PrintWhat.Workbook;
            else
                // Print the current selection.
                printWhat = SpreadsheetGear.Printing.PrintWhat.Selection;

            return printWhat;
        }


        #region Sample Initialization Code
        public BasicPrintingSample()
        {
            InitializeComponent();
            InitializeSample();
        }

        private void InitializeSample()
        {
            // DisposalManager.RegisterWorkbookViews(workbookView);
            DisposalManager.ResetWorkbookView(workbookView, false);
            Sample = new SharedSamples.Samples.Printing.BasicPrintingSample();
            Sample.InitializeSample(workbookView);
        }
        #endregion
    }
}
