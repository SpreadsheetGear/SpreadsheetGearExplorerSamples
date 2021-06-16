namespace WPFExplorer.Samples.WorkbookView.Events
{
    public partial class RangeChangedSample : SampleUserControl
    {
        private void WorkbookView_RangeChanged(
            object sender, SpreadsheetGear.Windows.Controls.RangeChangedEventArgs e)
        {
            // NOTE: GetLock() / ReleaseLock() not required because a lock is 
            // acquired before this method is invoked.

            // Get the changed range.
            SpreadsheetGear.IRange range = e.Range;

            // Set up some information about the event.
            string text = "The value in cell " +
                range.Address + " has changed to " + range.Text + ".";

            // Display the information in the TextBlock
            textBlock.Text = text;
        }

        #region Sample Initialization Code
        public RangeChangedSample()
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
                cells["A1"].Value = "Select a month from the list:";
                cells["A1"].ColumnWidth = 25.0;
                cells["B1"].Validation.Add(
                    SpreadsheetGear.ValidationType.List,
                    SpreadsheetGear.ValidationAlertStyle.Stop,
                    SpreadsheetGear.ValidationOperator.Default,
                    "January,February,March,April,May,June,July,August,September,October,November,December", null);
                cells["B1"].Value = "January";
                cells["B1"].Select();
            }
            finally
            {
                workbookView.ReleaseLock();
            }
        }
        #endregion
    }
}
