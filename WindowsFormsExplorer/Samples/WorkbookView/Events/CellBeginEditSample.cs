namespace WindowsFormsExplorer.Samples.WorkbookView.Events
{
    public partial class CellBeginEditSample : SampleUserControl
    {
        private void WorkbookView_CellBeginEdit(
            object sender, SpreadsheetGear.Windows.Forms.CellBeginEditEventArgs e)
        {
            // NOTE: Must acquire a workbook set lock.
            workbookView.GetLock();
            try
            {
                // Check if cell B1 is selected.
                SpreadsheetGear.IRange range = workbookView.ActiveCell;
                if (range.Row == 0 && range.Column == 1)
                    // Sets the initial entry text to upper case.
                    e.Entry = e.Entry.ToUpper();
                else
                    // Cancel the edit for any cell other than B1.
                    e.Cancel = true;
            }
            finally
            {
                // NOTE: Must release the workbook set lock.
                workbookView.ReleaseLock();
            }
        }

        #region Sample Initialization Code
        public CellBeginEditSample()
        {
            InitializeComponent();
            DisposalManager.RegisterWorkbookViews(workbookView);
        }
        #endregion
    }
}
