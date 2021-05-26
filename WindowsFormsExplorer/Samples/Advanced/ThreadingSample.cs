namespace WindowsFormsExplorer.Samples.Advanced
{
    public partial class ThreadingSample : SGUserControl
    {
        // Most code for this Sample is in the SharedSamples project and can be run from either this WindowsFormsExplorer
        // project sample or a similar sample in the WindowsFormsExplorer project.
        public SharedSamples.Samples.Advanced.ThreadingSample Sample { get; private set; }


        private void buttonAddThread_Click(object sender, System.EventArgs e)
        {
            Sample.AddThread(workbookView);
        }

        private void buttonRemoveThread_Click(object sender, System.EventArgs e)
        {
            Sample.RemoveThread(workbookView);
        }


        #region Sample Initialization Code
        public ThreadingSample()
        {
            InitializeComponent();
            InitializeSample();
        }

        private void InitializeSample()
        {
            Sample = new SharedSamples.Samples.Advanced.ThreadingSample();
            // DisposalManager.RegisterWorkbookViews(workbookView);
            Sample.InitializeSample(workbookView);
        }
        #endregion
    }
}
