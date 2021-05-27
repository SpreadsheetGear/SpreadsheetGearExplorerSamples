namespace WPFExplorer.Samples.Printing
{
    public partial class BasicPrintingSample : SampleUserControl
    {
        // Most code for this Sample is in the SamplesLibrary project and can be run from either this WpfExplorer
        // project sample or a similar sample in the WindowsFormsExplorer project.
        public SamplesLibrary.Samples.Printing.BasicPrintingSample Sample { get; private set; }

        private void buttonPrint_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Determine what to print...
            SpreadsheetGear.Printing.PrintWhat printWhat = GetPrintWhat();

            // Run sample to print.
            Sample.Print(workbookView, printWhat);
        }


        private void buttonPrintPreview_Click(object sender, System.Windows.RoutedEventArgs e)
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
