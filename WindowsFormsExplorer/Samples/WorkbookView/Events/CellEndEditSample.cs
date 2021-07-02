namespace WindowsFormsExplorer.Samples.WorkbookView.Events
{
    public partial class CellEndEditSample : SampleUserControl
    {
        private void WorkbookView_CellEndEdit(
            object sender, SpreadsheetGear.Windows.Forms.CellEndEditEventArgs e)
        {
            // NOTE: Must acquire a workbook set lock.
            workbookView.GetLock();
            try
            {
                // Check if cell B1 is selected.
                SpreadsheetGear.IRange range = workbookView.ActiveCell;
                if (range.Row == 0 && range.Column == 1)
                {
                    // Try to convert the entry to an integer.
                    bool validInt = System.Int32.TryParse(e.Entry, out int result);

                    // Check if the entry is valid.
                    if (!validInt || result <= 0)
                    {
                        // Unwind the workbook set lock.
                        int rewindCount = workbookView.UnwindLock();
                        try
                        {
                            // Show a message and cancel CellEndEdit.
                            System.Windows.Forms.MessageBox.Show(
                                "The entry must be an integer greater than 0.", "SpreadsheetGear");
                            e.Cancel = true;
                        }
                        finally
                        {
                            // Rewind the workbook set lock.
                            workbookView.RewindLock(rewindCount);
                        }
                    }
                }
            }
            finally
            {
                // NOTE: Must release the workbook set lock.
                workbookView.ReleaseLock();
            }
        }

        #region Sample Initialization Code
        public CellEndEditSample()
        {
            InitializeComponent();
            DisposalManager.RegisterWorkbookViews(workbookView);
        }
        #endregion
    }
}
