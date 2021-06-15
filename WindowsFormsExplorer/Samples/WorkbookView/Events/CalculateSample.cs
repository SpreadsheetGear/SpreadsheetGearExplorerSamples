namespace WindowsFormsExplorer.Samples.WorkbookView.Events
{
    public partial class CalculateSample : SampleUserControl
    {
        private void ButtonCalculate_Click(object sender, System.EventArgs e)
        {
            CalculateWorkbook(workbookView);
        }

        private void WorkbookView_Calculate(
            object sender, SpreadsheetGear.Windows.Forms.CalculateEventArgs e)
        {
            // NOTE: Must acquire a workbook set lock.
            workbookView.GetLock();
            try
            {
                // Get a date/time value from a cell.
                // NOTE: The NOW worksheet function is used to calculate the value.
                double value =
                    (double)workbookView.ActiveWorksheet.Cells["B1"].Value;

                // Convert the cell value to a System.DateTime.
                System.DateTime dateTime =
                    workbookView.ActiveWorkbook.NumberToDateTime(value);

                // Set the date/time value of the DateTimePicker control.
                dateTimePicker1.Value = dateTime;
            }
            finally
            {
                // NOTE: Must release the workbook set lock.
                workbookView.ReleaseLock();
            }
        }

        private void CalculateWorkbook(SpreadsheetGear.Windows.Forms.WorkbookView workbookView)
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
            DisposalManager.RegisterWorkbookViews(workbookView);
        }
        #endregion
    }
}
