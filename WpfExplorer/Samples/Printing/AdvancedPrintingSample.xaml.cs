namespace WPFExplorer.Samples.Printing
{
    public partial class AdvancedPrintingSample : SampleUserControl
    {
        private void ButtonPrint_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Print();
        }

        private void Print()
        {
            // NOTE: Must acquire a workbook set lock.
            workbookView.GetLock();
            try
            {
                // Create a workbook print document.
                SpreadsheetGear.Windows.Printing.WorkbookPrintDocument document =
                    CreatePrintDocument(workbookView.ActiveWorkbook);

                // Print, displaying the print dialog before printing.
                document.Print();
            }
            catch (System.Exception exc)
            {
                System.Windows.MessageBox.Show(exc.Message, "SpreadsheetGear Explorer", System.Windows.MessageBoxButton.OK);
            }
            finally
            {
                // NOTE: Must release the workbook set lock.
                workbookView.ReleaseLock();
            }
        }

        private SpreadsheetGear.Windows.Printing.WorkbookPrintDocument CreatePrintDocument(
            SpreadsheetGear.IWorkbook workbook)
        {
            // Create an empty printable list.
            System.Collections.Generic.List<SpreadsheetGear.IPrintable> printables =
                new System.Collections.Generic.List<SpreadsheetGear.IPrintable>();

            // If the range option is selected...
            if (checkBoxRange.IsChecked == true)
            {
                // Get a reference to a range from an existing defined name.
                SpreadsheetGear.IRange range = workbook.Worksheets[0].Cells["West"];

                // Add the range to the printable list.
                printables.Add(range);
            }

            // If the chart option is selected...
            if (checkBoxChart.IsChecked == true)
            {
                // Get a reference to a chart.
                SpreadsheetGear.Charts.IChart chart = workbook.Worksheets[0].Shapes["Chart 1"].Chart;

                // Add the chart to the printable list.
                printables.Add(chart);
            }

            // Create a workbook print document.
            SpreadsheetGear.Windows.Printing.WorkbookPrintDocument document =
                new SpreadsheetGear.Windows.Printing.WorkbookPrintDocument(printables);

            // Return the workbook print document.
            return document;
        }

        #region Sample Initialization Code
        public AdvancedPrintingSample()
        {
            InitializeComponent();
            DisposalManager.RegisterWorkbookViews(workbookView);
            DisposalManager.ResetWorkbookView(workbookView, false);

            // Open workbook using the current culture.
            SpreadsheetGear.IWorkbook workbook = SpreadsheetGear.Factory.GetWorkbook(@"Files\WPF\PrintingAdvanced.xlsx",
                System.Globalization.CultureInfo.CurrentCulture);

            // Associate workbook with the WorkbookView control
            workbookView.ActiveWorkbook = workbook;
        }
        #endregion
    }
}
