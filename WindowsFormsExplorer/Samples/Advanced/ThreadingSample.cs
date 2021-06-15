namespace WindowsFormsExplorer.Samples.Advanced
{
    public partial class ThreadingSample : SampleUserControl
    {
        // Most of the relevant SpreadsheetGear code for this sample is in this member's class, located within the
        // SamplesLibrary project.  It is shared sample code that can be run from this WindowsFormsExplorer samples 
        // app as well as the WPFExplorer samples app.
        public SamplesLibrary.Samples.Advanced.ThreadingSample Sample { get; private set; }

        private void ButtonAddThread_Click(object sender, System.EventArgs e)
        {
            Sample.AddThread(workbookView);
        }

        private void ButtonRemoveThread_Click(object sender, System.EventArgs e)
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
