namespace WindowsFormsExplorer.Samples.WorkbookView
{
    public partial class LocationToRangeSample : SampleUserControl
    {
        // Most of the relevant SpreadsheetGear code for this sample is in this member's class, located within the
        // SamplesLibrary project.  It is shared sample code that can be run from this WindowsFormsExplorer samples 
        // app as well as the WPFExplorer samples app.
        public SamplesLibrary.Samples.WorkboookView.LocationToRangeSample Sample { get; private set; }

        private void WorkbookView_MouseDown(
            object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // Run the sample.
            Sample.ColorizeClickedCell(workbookView, e.X, e.Y);
        }

        #region Sample Initialization Code
        public LocationToRangeSample()
        {
            InitializeComponent();
            InitializeSample();
        }

        private void InitializeSample()
        {
            Sample = new SamplesLibrary.Samples.WorkboookView.LocationToRangeSample();
            DisposalManager.RegisterWorkbookViews(workbookView);
            workbookView.GetLock();
            try
            {
                workbookView.ActiveWorksheet.Cells["A1"].Value = "Click on any cell to fill it with a color.";
            }
            finally
            {
                workbookView.ReleaseLock();
            }
        }
        #endregion
    }
}
