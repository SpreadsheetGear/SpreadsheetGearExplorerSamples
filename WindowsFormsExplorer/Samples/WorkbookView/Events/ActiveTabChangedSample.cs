namespace WindowsFormsExplorer.Samples.WorkbookView.Events
{
    public partial class ActiveTabChangedSample : SampleUserControl
    {
        private void WorkbookView_ActiveTabChanged(
            object sender, SpreadsheetGear.Windows.Forms.ActiveTabChangedEventArgs e)
        {
            // NOTE: Must acquire a workbook set lock.
            workbookView.GetLock();
            try
            {
                // Get the new sheet selection.
                SpreadsheetGear.ISheet sheet = e.Sheet;

                // Get the new tab index.
                int tabIndex = e.TabIndex;

                // Set up some information about the event.
                string text = sheet.Name +
                    " is currently selected with a tab index of " + tabIndex + ".";

                // Display the information in a ToolTip.
                toolTip.Show(text, this, 160, 80, 5000);
            }
            finally
            {
                // NOTE: Must release the workbook set lock.
                workbookView.ReleaseLock();
            }
        }

        #region Sample Initialization Code
        public ActiveTabChangedSample()
        {
            InitializeComponent();
            InitializeSample();
        }

        private void InitializeSample()
        {
            DisposalManager.RegisterWorkbookViews(workbookView);
        }
        #endregion
    }
}
