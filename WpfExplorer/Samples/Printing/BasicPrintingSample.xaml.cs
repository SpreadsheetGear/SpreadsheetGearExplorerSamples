namespace WPFExplorer.Samples.Printing
{
    public partial class BasicPrintingSample : SampleUserControl
    {
        // Most of the relevant SpreadsheetGear code for this sample is in this member's class, located within the
        // SamplesLibrary project.  It is shared sample code that can be run from this WPFExplorer samples app as
        // well as the WindowsFormsExplorer samples app.
        public SamplesLibrary.Samples.Printing.BasicPrintingSample Sample { get; private set; }

        private void ButtonPrint_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Determine what to print...
            SpreadsheetGear.Printing.PrintWhat printWhat = GetPrintWhat();

            // Run sample to print.
            Sample.Print(workbookView, printWhat);
        }

        private void ButtonPrintPreview_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Determine what to print...
            SpreadsheetGear.Printing.PrintWhat printWhat = GetPrintWhat();

            // Run sample to launch Windows' built-in Print Preview dialog.
            Sample.PrintPreview(workbookView, printWhat);
        }

        private SpreadsheetGear.Printing.PrintWhat GetPrintWhat()
        {
            SpreadsheetGear.Printing.PrintWhat printWhat;
            if (radioButtonSheet.IsChecked == true)
                // Print the active sheet.
                printWhat = SpreadsheetGear.Printing.PrintWhat.Sheet;
            else if (radioButtonWorkbook.IsChecked == true)
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
            DisposalManager.RegisterWorkbookViews(workbookView);
            DisposalManager.ResetWorkbookView(workbookView, false);
            Sample = new SamplesLibrary.Samples.Printing.BasicPrintingSample();
            Sample.InitializeSample(workbookView);
        }
        #endregion
    }
}
