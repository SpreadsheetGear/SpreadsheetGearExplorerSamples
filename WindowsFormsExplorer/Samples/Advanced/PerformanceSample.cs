using System;

namespace WindowsFormsExplorer.Samples.Advanced
{
    public partial class PerformanceSample : SampleUserControl
    {
        // Most of the relevant SpreadsheetGear code for this sample is in this member's class, located within the
        // SamplesLibrary project.  It is shared sample code that can be run from this WindowsFormsExplorer samples 
        // app as well as the WPFExplorer samples app.
        public SamplesLibrary.Samples.Advanced.PerformanceSample Sample { get; private set; }

        private void ButtonRunSample_Click(object sender, EventArgs e)
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
            Sample = new SamplesLibrary.Samples.Advanced.PerformanceSample();
            DisposalManager.RegisterWorkbookViews(workbookView);
        }
        #endregion
    }
}
