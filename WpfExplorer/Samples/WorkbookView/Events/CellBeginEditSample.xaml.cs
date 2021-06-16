namespace WPFExplorer.Samples.WorkbookView.Events
{
    public partial class CellBeginEditSample : SampleUserControl
    {
        private void WorkbookView_CellBeginEdit(object sender, 
            SpreadsheetGear.Windows.Controls.CellBeginEditEventArgs e)
        {
            // NOTE: GetLock() / ReleaseLock() not required because a lock is 
            // acquired before this method is invoked.

            // Check if cell B1 is selected.
            SpreadsheetGear.IRange range = workbookView.ActiveCell;
            if (range.Row == 0 && range.Column == 1)
            {
                // Sets the initial entry text to upper case.
                e.Entry = e.Entry.ToUpper();
            }
            else
            {
                // Cancel the edit for any cell other than B1.
                e.Cancel = true;
            }
        }

        #region Sample Initialization Code
        public CellBeginEditSample()
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
                cells["A1"].Value = "Enter a lower case letter:";
                cells["A1"].ColumnWidth = 30.0;
                cells["B1"].Select();
                cells["A3:C5"].Merge();
                cells["A3"].Value =
                    "This sample shows how to use the CellBeginEdit event.\n" +
                    "The event is canceled if cell B1 is not selected.\n" +
                    "The initial entry is always converted to upper case.";
            }
            finally
            {
                workbookView.ReleaseLock();
            }
        }
        #endregion
    }
}
