namespace WPFExplorer.Samples.WorkbookView.Events
{
    public partial class CalculateSample : SampleUserControl
    {
        private void WorkbookView_Calculate(
            object sender, SpreadsheetGear.Windows.Controls.CalculateEventArgs e)
        {
            // NOTE: Must acquire a workbook set lock.
            workbookView.GetLock();
            try
            {
                // Get a date/time value from a cell.
                // NOTE: The NOW worksheet function is used to calculate the value.
                double value = (double)workbookView.ActiveWorksheet.Cells["B1"].Value;

                // Convert the cell value to a System.DateTime.
                System.DateTime dateTime =
                    workbookView.ActiveWorkbook.NumberToDateTime(value);

                // Display the date/time value in the textbox control.
                textBox.Text = dateTime.ToLongTimeString();
            }
            finally
            {
                // NOTE: Must release the workbook set lock.
                workbookView.ReleaseLock();
            }
        }

        private void ButtonCalculate_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            CalculateWorkbook();
        }

        private void CalculateWorkbook()
        {
            // NOTE: Must acquire a workbook set lock.
            workbookView.GetLock();
            try
            {
                // Force the NOW worksheet function to recalculate.
                workbookView.ActiveWorkbookSet.Calculate();
            }
            finally
            {
                // NOTE: Must release the workbook set lock.
                workbookView.ReleaseLock();
            }
        }

        #region Sample Initialization Code
        public CalculateSample()
        {
            InitializeComponent();
            InitializeSample();
        }

        public void InitializeSample()
        {
            DisposalManager.RegisterWorkbookViews(workbookView);

            workbookView.GetLock();
            try
            {
                var cells = workbookView.ActiveWorksheet.Cells;
                cells["A1"].Value = "Current Time:";
                cells["B1"].Formula = "=NOW()";
                cells["B1"].NumberFormat = "h:mm:ss.000 AM/PM";
                cells["A:B"].EntireColumn.AutoFit();
            }
            finally
            {
                workbookView.ReleaseLock();
            }
        }
        #endregion
    }
}
