namespace WindowsFormsExplorer.Samples.WorkbookView.Events
{
    public partial class ShapeActionSample : SampleUserControl
    {
        private void WorkbookView_ShapeAction(
            object sender, SpreadsheetGear.Windows.Forms.ShapeActionEventArgs e)
        {
            // NOTE: Must acquire a workbook set lock.
            workbookView.GetLock();
            try
            {
                switch (e.ShapeActionType)
                {
                    case SpreadsheetGear.Windows.Forms.ShapeActionType.Click:
                        // Get a reference to a cell.
                        SpreadsheetGear.IRange cell =
                            workbookView.ActiveWorksheet.Cells["B6"];

                        // Add text to the cell.
                        cell.Value = "SpreadsheetGear for .NET";

                        // Set various font options.
                        SpreadsheetGear.IFont font = cell.Font;
                        font.Name = "Times New Roman";
                        font.Size = 18;
                        font.Bold = true;
                        font.Color = SpreadsheetGear.Colors.SlateBlue;
                        break;
                }
            }
            finally
            {
                // NOTE: Must release the workbook set lock.
                workbookView.ReleaseLock();
            }
        }

        #region Sample Initialization Code
        public ShapeActionSample()
        {
            InitializeComponent();
            DisposalManager.RegisterWorkbookViews(workbookView);
        }
        #endregion
    }
}
