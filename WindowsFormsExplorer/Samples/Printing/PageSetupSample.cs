namespace WindowsFormsExplorer.Samples.Printing
{
    public partial class PageSetupSample : SGUserControl
    {
        // Most code for this Sample is in the SharedSamples project and can be run from either this WindowsFormsExplorer
        // project sample or a similar sample in the WindowsFormsExplorer project.
        public SharedSamples.Samples.Printing.PageSetupSample Sample { get; private set; }

        private void buttonRunSample_Click(object sender, System.EventArgs e)
        {
            // Run the sample.
            Sample.PrintPreview(workbookView);
        }


        #region Sample Initialization Code
        public PageSetupSample()
        {
            InitializeComponent();
            InitializeSample();
        }

        private void InitializeSample()
        {
            DisposalManager.RegisterWorkbookViews(workbookView);
            DisposalManager.ResetWorkbookView(workbookView, false);
            Sample = new SharedSamples.Samples.Printing.PageSetupSample();
            Sample.InitializeSample(workbookView);
        }
        #endregion
    }
}
