namespace WPFExplorer.Samples.WorkbookView.Events
{
    public partial class ShowErrorSample : SampleUserControl
    {
        private void WorkbookView_ShowError(
            object sender, SpreadsheetGear.Windows.Controls.ShowErrorEventArgs e)
        {
            // NOTE: Must acquire a workbook set lock.
            workbookView.GetLock();
            try
            {
                // NOTE: This sample changes the text displayed in the default
                //       error message dialog.  You can bypass the dialog completely
                //       by simply setting ShowErrorEventArgs.Handled to true.

                // Change the default error dialog caption.
                e.Caption = "Custom Protection Error Message";

                // Change the default error dialog message.
                e.Message = "Access Denied!\r\n\r\nYou do not have permission to edit this worksheet.";
            }
            finally
            {
                // NOTE: Must release the workbook set lock.
                workbookView.ReleaseLock();
            }
        }

        #region Sample Initialization Code
        public ShowErrorSample()
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
                var worksheet = workbookView.ActiveWorksheet;
                worksheet.Cells["A1"].Value =
                    "Type a value into any cell to display a custom error message.";
                worksheet.ProtectContents = true;
            }
            finally
            {
                workbookView.ReleaseLock();
            }
        }
        #endregion
    }
}
