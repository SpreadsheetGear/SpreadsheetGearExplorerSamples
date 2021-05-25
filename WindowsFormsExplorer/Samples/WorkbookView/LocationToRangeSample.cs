namespace WindowsFormsExplorer.Samples.WorkbookView
{
    public partial class LocationToRangeSample : SampleUserControl
    {
        // Most code for this Sample is in the SamplesLibrary project and can be run from either this WindowsFormsExplorer
        // project sample or a similar sample in the WindowsFormsExplorer project.
        public SamplesLibrary.Samples.WorkboookView.LocationToRangeSample Sample { get; private set; }

        private void workbookView_MouseDown(
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
                workbookView.ActiveCell.Value = "Click on any cell to fill it with a color.";
            }
            finally
            {
                workbookView.ReleaseLock();
            }
        }
        #endregion
    }
}
