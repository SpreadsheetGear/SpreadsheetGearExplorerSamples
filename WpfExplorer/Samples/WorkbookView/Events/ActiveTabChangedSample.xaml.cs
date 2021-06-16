namespace WPFExplorer.Samples.WorkbookView.Events
{
    public partial class ActiveTabChangedSample : SampleUserControl
    {
        private void WorkbookView_ActiveTabChanged(
            object sender, SpreadsheetGear.Windows.Controls.ActiveTabChangedEventArgs e)
        {
            // NOTE: GetLock() / ReleaseLock() not required because a lock is 
            // acquired before this method is invoked.

            // Get the new sheet selection.
            SpreadsheetGear.ISheet sheet = e.Sheet;

            // Get the new tab index.
            int tabIndex = e.TabIndex;

            // Set up some information about the event.
            string text = sheet.Name +
                " is currently selected with a tab index of " + tabIndex + ".";

            // Display the information in the TextBlock.
            textBlock.Text = text;
        }

        #region Sample Initialization Code
        public ActiveTabChangedSample()
        {
            InitializeComponent();
            InitializeSample();
        }

        public void InitializeSample()
        {
            DisposalManager.RegisterWorkbookViews(workbookView);
            DisposalManager.ResetWorkbookView(workbookView, false);
            workbookView.GetLock();
            try
            {
                SpreadsheetGear.IWorkbookSet workbookSet =
                    SpreadsheetGear.Factory.GetWorkbookSet();
                workbookSet.SheetsInNewWorkbook = 3;
                SpreadsheetGear.IWorkbook workbook = workbookSet.Workbooks.Add();
                workbook.Worksheets["Sheet1"].Cells["A1"].Value =
                    "Select a sheet tab to display the sheet name and tab index.";
                workbook.Worksheets["Sheet2"].Cells["A1"].Value =
                    "Select a sheet tab to display the sheet name and tab index.";
                workbook.Worksheets["Sheet3"].Cells["A1"].Value =
                    "Select a sheet tab to display the sheet name and tab index.";
                workbookView.ActiveWorkbook = workbook;
            }
            finally
            {
                workbookView.ReleaseLock();
            }
        }
        #endregion
    }
}
