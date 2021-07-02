namespace WindowsFormsExplorer.Samples.Printing
{
    public partial class AdvancedPrintingSample : SampleUserControl
    {
        private void ButtonPrint_Click(object sender, System.EventArgs e)
        {
            // NOTE: Must acquire a workbook set lock.
            workbookView.GetLock();
            try
            {
                // Create a workbook print document.
                SpreadsheetGear.Drawing.Printing.WorkbookPrintDocument document =
                    CreatePrintDocument(workbookView.ActiveWorkbook);

                using (document)
                {
                    // Create a print dialog.
                    System.Windows.Forms.PrintDialog dialog = new System.Windows.Forms.PrintDialog {
                        // Set the print dialogs print document.
                        Document = document
                    };

                    // Work around this issue:
                    // http://stackoverflow.com/questions/6385844/printdialog-showdialog-not-showing-the-print-dialog-in-windows-7-with-64-bit

                    if (System.IntPtr.Size > 4)
                        dialog.UseEXDialog = true;

                    // Show the print dialog and check the return status...
                    if (dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        // Print the document.
                        document.Print();
                    }
                }
            }
            catch (System.Exception exc)
            {
                System.Windows.Forms.MessageBox.Show(this, exc.Message, "SpreadsheetGear Explorer",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                // NOTE: Must release the workbook set lock.
                workbookView.ReleaseLock();
            }
        }

        private void ButtonPrintPreview_Click(object sender, System.EventArgs e)
        {
            // NOTE: Must acquire a workbook set lock.
            workbookView.GetLock();
            try
            {
                // Create a workbook print document.
                SpreadsheetGear.Drawing.Printing.WorkbookPrintDocument document =
                    CreatePrintDocument(workbookView.ActiveWorkbook);

                using (document)
                {
                    // Create a custom print preview dialog.
                    CustomPrintPreviewDialog dialog = new CustomPrintPreviewDialog {
                        // Set the print preview dialogs print document.
                        Document = document
                    };

                    // Show the print preview dialog.
                    dialog.ShowDialog(this);
                }
            }
            catch (System.Exception exc)
            {
                System.Windows.Forms.MessageBox.Show(this, exc.Message, "SpreadsheetGear Explorer",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                // NOTE: Must release the workbook set lock.
                workbookView.ReleaseLock();
            }
        }

        private SpreadsheetGear.Drawing.Printing.WorkbookPrintDocument CreatePrintDocument(
            SpreadsheetGear.IWorkbook workbook)
        {
            // Create an empty printable list.
            System.Collections.Generic.List<SpreadsheetGear.IPrintable> printables =
                new System.Collections.Generic.List<SpreadsheetGear.IPrintable>();

            // If the range option is selected...
            if (checkBoxRange.Checked)
            {
                // Get a reference to a range from an existing defined name.
                SpreadsheetGear.IRange range = workbook.Worksheets[0].Cells["West"];

                // Add the range to the printable list.
                printables.Add(range);
            }

            // If the chart option is selected...
            if (checkBoxChart.Checked)
            {
                // Get a reference to a chart.
                SpreadsheetGear.Charts.IChart chart =
                    workbook.Worksheets[0].Shapes["Chart 1"].Chart;

                // Add the chart to the printable list.
                printables.Add(chart);
            }

            // Create a workbook print document.
            SpreadsheetGear.Drawing.Printing.WorkbookPrintDocument document =
                new SpreadsheetGear.Drawing.Printing.WorkbookPrintDocument(printables);

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
            SpreadsheetGear.IWorkbook workbook = SpreadsheetGear.Factory.GetWorkbook(@"Files\WinForms\PrintingAdvanced.xlsx",
                System.Globalization.CultureInfo.CurrentCulture);

            // Associate workbook with the WorkbookView control
            workbookView.ActiveWorkbook = workbook;
        }
        #endregion
    }
}
