namespace WindowsFormsExplorer.Samples.WorkbookView.Events
{
    public partial class RangeChangedSample : SampleUserControl
    {
        private void WorkbookView_RangeChanged(
            object sender, SpreadsheetGear.Windows.Forms.RangeChangedEventArgs e)
        {
            // NOTE: Must acquire a workbook set lock.
            workbookView.GetLock();
            try
            {
                // Get the changed range.
                SpreadsheetGear.IRange range = e.Range;

                // Set up some information about the event.
                string text = "The value in cell " +
                    range.Address + " has changed to " + range.Text + ".";

                // Display the information in a ToolTip.
                this.Focus();
                toolTip.Show(text, this, 200, 100, 5000);
            }
            finally
            {
                // NOTE: Must release the workbook set lock.
                workbookView.ReleaseLock();
            }
        }

        #region Sample Initialization Code
        public RangeChangedSample()
        {
            InitializeComponent();
            DisposalManager.RegisterWorkbookViews(workbookView);
        }
        #endregion
    }
}
