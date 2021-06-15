namespace WindowsFormsExplorer.Samples.WorkbookView.UIManager
{
    public partial class CustomControlSample : SampleUserControl
    {
        public void InitializeSample()
        {
            // Create an instance of the UIManager and pass in the IWorkbookSet currently
            // attached to the WorkbookView.  UIManager's constructor will do all the 
            // plumbing to get this UIManager instance to also attach to the WorkbookView.
            new MyUIManager(workbookView.ActiveWorkbookSet);
        }

        private void ButtonRunSample_Click(object sender, System.EventArgs e)
        {
            // NOTE: Must acquire a workbook set lock.
            workbookView.GetLock();
            try
            {
                // Get the active worksheet.
                SpreadsheetGear.IWorksheet worksheet = workbookView.ActiveWorksheet;

                // Run sample just once.
                if (worksheet.Shapes.Count == 0)
                {
                    // Add a Rectangle AutoShape with a name that matches what the UIManager
                    // needs in order to replace it.
                    SpreadsheetGear.Shapes.IShape shape1 = worksheet.Shapes.AddShape(
                        SpreadsheetGear.Shapes.AutoShapeType.Rectangle, 5, 5, 100, 35);
                    shape1.Name = "MyCustomControl";

                    // Add a second Rectangle with a different name that won't match what the
                    // UIManager needs, thereby not replacing it.
                    SpreadsheetGear.Shapes.IShape shape2 = worksheet.Shapes.AddShape(
                        SpreadsheetGear.Shapes.AutoShapeType.Rectangle, 5, 50, 100, 35);
                    shape2.Name = "SomeOtherName";
                }
            }
            finally
            {
                // NOTE: Must release the workbook set lock.
                workbookView.ReleaseLock();
            }
        }

        #region Sample Initialization Code
        public CustomControlSample()
        {
            InitializeComponent();
            DisposalManager.RegisterWorkbookViews(workbookView);
            InitializeSample();
        }
        #endregion
    }
}
