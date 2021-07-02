namespace WPFExplorer.Samples.WorkbookView.Events
{
    public partial class CellEndEditSample : SampleUserControl
    {
        private void WorkbookView_CellEndEdit(object sender, SpreadsheetGear.Windows.Controls.CellEndEditEventArgs e)
        {
            // NOTE: GetLock() / ReleaseLock() not required because a lock is acquired before this method is invoked.

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
                        System.Windows.MessageBox.Show("The entry must be an integer greater than 0.", "SpreadsheetGear", 
                            System.Windows.MessageBoxButton.OK);
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

        #region Sample Initialization Code
        public CellEndEditSample()
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
                cells["A1"].Value = "Enter an integer value greater than 0:";
                cells["A1"].ColumnWidth = 30.0;
                cells["B1"].Select();
                cells["A3:C4"].Merge();
                cells["A3"].Value =
                    "This sample shows how to use the CellEndEdit event.\n" +
                    "The event is canceled if the value is not greater than 0.";
            }
            finally
            {
                workbookView.ReleaseLock();
            }
        }
        #endregion
    }
}
