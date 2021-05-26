using System;

namespace WindowsFormsExplorer.Samples.Advanced
{
    public partial class PerformanceSample : SGUserControl
    {
        // Most code for this Sample is in the SharedSamples project and can be run from either this WindowsFormsExplorer
        // project sample or a similar sample in the WindowsFormsExplorer project.
        public SharedSamples.Samples.Advanced.PerformanceSample Sample { get; private set; }

        private void buttonRunSample_Click(object sender, EventArgs e)
        {
            Sample.RunSample(workbookView.ActiveWorkbookSet);
        }


        #region Sample Initialization Code
        public PerformanceSample()
        {
            InitializeComponent();
            InitializeSample();
        }

        private void InitializeSample()
        {
            Sample = new SharedSamples.Samples.Advanced.PerformanceSample();
            // DisposalManager.RegisterWorkbookViews(workbookView);
        }
        #endregion
    }
}
