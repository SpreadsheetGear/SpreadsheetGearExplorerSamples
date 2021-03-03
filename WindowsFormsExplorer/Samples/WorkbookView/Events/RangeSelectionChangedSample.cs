namespace WindowsFormsExplorer.Samples.WorkbookView.Events
{
    public partial class RangeSelectionChangedSample : SGUserControl
    {
        private void workbookView_RangeSelectionChanged(
            object sender, SpreadsheetGear.Windows.Forms.RangeSelectionChangedEventArgs e)
        {
            // NOTE: Must acquire a workbook set lock.
            workbookView.GetLock();
            try
            {
                // Get the new range selection.
                SpreadsheetGear.IRange range = e.RangeSelection;

                // Display information about the selected range.
                workbookView.ActiveWorksheet.Cells["B1"].Formula = range.Address;
            }
            finally
            {
                // NOTE: Must release the workbook set lock.
                workbookView.ReleaseLock();
            }
        }

        public RangeSelectionChangedSample()
        {
            InitializeComponent();
            DisposalManager.RegisterWorkbookViews(workbookView);
        }
    }
}
