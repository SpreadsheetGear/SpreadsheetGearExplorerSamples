namespace WPFExplorer.Samples.WorkbookView.Events
{
    public partial class RangeSelectionChangedSample : SampleUserControl
    {
        private void WorkbookView_RangeSelectionChanged(
            object sender, SpreadsheetGear.Windows.Controls.RangeSelectionChangedEventArgs e)
        {
            // NOTE: GetLock() / ReleaseLock() not required because a lock is 
            // acquired before this method is invoked.

            // Get the new range selection.
            SpreadsheetGear.IRange range = e.RangeSelection;

            // Display information about the selected range.
            workbookView.ActiveWorksheet.Cells["B1"].Formula = range.Address;
        }

        #region Sample Initialization Code
        public RangeSelectionChangedSample()
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
                SpreadsheetGear.IRange cells = workbookView.ActiveWorksheet.Cells;
                cells["A1"].Value = "The address of the current range selection is:";
                cells["A3:A4"].Merge();
                cells["A3"].Value = "Select a range with the mouse or keyboard to\nupdate cell B1 with the address of the range.";
                cells["A:A"].ColumnWidth = 40.0;
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
