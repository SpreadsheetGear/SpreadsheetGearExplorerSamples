namespace WindowsFormsExplorer.Samples.WorkbookView.Events
{
    public partial class ShowErrorSample : SampleUserControl
    {
        private void WorkbookView_ShowError(
            object sender, SpreadsheetGear.Windows.Forms.ShowErrorEventArgs e)
        {
            // NOTE: Must acquire a workbook set lock.
            workbookView.GetLock();
            try
            {
                // NOTE: This sample changes the text displayed in the default
                //       error message dialog.  You can bypass the dialog completely
                //       by simply setting ShowErrorEventArgs.Handled to true.

                // Change the default error dialog caption.
                e.Caption = "Protection Error";

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
            DisposalManager.RegisterWorkbookViews(workbookView);
        }
        #endregion
    }
}
