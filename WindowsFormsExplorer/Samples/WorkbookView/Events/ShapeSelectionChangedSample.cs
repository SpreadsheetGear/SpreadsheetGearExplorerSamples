namespace WindowsFormsExplorer.Samples.WorkbookView.Events
{
    public partial class ShapeSelectionChangedSample : SampleUserControl
    {
        private void WorkbookView_ShapeSelectionChanged(
            object sender, SpreadsheetGear.Windows.Forms.ShapeSelectionChangedEventArgs e)
        {
            // NOTE: Must acquire a workbook set lock.
            workbookView.GetLock();
            try
            {
                // Get the new shape selection.
                SpreadsheetGear.Shapes.IShapeRange shapeRange = e.ShapeSelection;

                // If at least one shape is selected...
                if (shapeRange != null)
                    // display information about the first selected shape.
                    workbookView.ActiveWorksheet.Cells["B1"].Formula = shapeRange[0].Name;
                else
                    // display no selection.
                    workbookView.ActiveWorksheet.Cells["B1"].Formula = "No Selection";
            }
            finally
            {
                // NOTE: Must release the workbook set lock.
                workbookView.ReleaseLock();
            }
        }

        #region Sample Initialization Code
        public ShapeSelectionChangedSample()
        {
            InitializeComponent();
            DisposalManager.RegisterWorkbookViews(workbookView);
        }
        #endregion
    }
}
