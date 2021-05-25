namespace WindowsFormsExplorer.Samples.Advanced
{
    public partial class ThreadingSample : SampleUserControl
    {
        // Most code for this Sample is in the SamplesLibrary project and can be run from either this WindowsFormsExplorer
        // project sample or a similar sample in the WindowsFormsExplorer project.
        public SamplesLibrary.Samples.Advanced.ThreadingSample Sample { get; private set; }


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
            Sample = new SamplesLibrary.Samples.Advanced.ThreadingSample();
            DisposalManager.RegisterWorkbookViews(workbookView);
            Sample.InitializeSample(workbookView);
        }
        #endregion
    }
}
