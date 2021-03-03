namespace WindowsFormsExplorer.Samples.WorkbookView
{
    public partial class ActiveWorksheetSample : SGUserControl
    {
        // Most code for this Sample is in the SharedSamples project and can be run from either this WindowsFormsExplorer
        // project sample or a similar sample in the WindowsFormsExplorer project.
        public SharedSamples.Samples.WorkboookView.ActiveWorksheetSample Sample { get; private set; }

        private void buttonRunSample_Click(object sender, System.EventArgs e)
        {
            DisposalManager.ResetWorkbookView(workbookView);
            Sample.SetActiveWorksheet(workbookView);
        }


        #region Sample Initialization Code
        public ActiveWorksheetSample()
        {
            InitializeComponent();
            InitializeSample();
        }

        private void InitializeSample()
        {
            Sample = new SharedSamples.Samples.WorkboookView.ActiveWorksheetSample();
            DisposalManager.RegisterWorkbookViews(workbookView);
        }
        #endregion
    }
}
