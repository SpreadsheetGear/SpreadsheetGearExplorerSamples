namespace WPFExplorer.Samples.WorkbookView.Events
{
    public partial class ShapeActionSample : SampleUserControl
    {
        private void WorkbookView_ShapeAction(
            object sender, SpreadsheetGear.Windows.Controls.ShapeActionEventArgs e)
        {
            // NOTE: GetLock() / ReleaseLock() not required because a lock is 
            // acquired before this method is invoked.

            switch (e.ShapeActionType)
            {
                case SpreadsheetGear.Windows.Controls.ShapeActionType.Click:
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

        #region Sample Initialization Code
        public ShapeActionSample()
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
                var shapes = workbookView.ActiveWorksheet.Shapes;
                var windowInfo = workbookView.ActiveWorksheetWindowInfo;
                double left = windowInfo.ColumnToPoints(1.05);
                double top = windowInfo.RowToPoints(1.05);
                double right = windowInfo.ColumnToPoints(2.95);
                double bottom = windowInfo.RowToPoints(2.95);
                double width = right - left;
                double height = bottom - top;
                var shape = shapes.AddFormControl(
                    SpreadsheetGear.Shapes.FormControlType.ButtonControl, left, top, width, height);
                shape.TextFrame.Characters.Text = "Click Me";
            }
            finally
            {
                workbookView.ReleaseLock();
            }
        }
        #endregion
    }
}
