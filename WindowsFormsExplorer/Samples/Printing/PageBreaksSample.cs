namespace WindowsFormsExplorer.Samples.Printing
{
    public partial class PageBreaksSample : SampleUserControl
    {
        // Most of the relevant SpreadsheetGear code for this sample is in this member's class, located within the
        // SamplesLibrary project.  It is shared sample code that can be run from this WindowsFormsExplorer samples 
        // app as well as the WPFExplorer samples app.
        public SamplesLibrary.Samples.Printing.PageBreaksSample Sample { get; private set; }

        private void buttonPrintPreview_Click(object sender, System.EventArgs e)
        {
            // Run the sample.
            Sample.Print(workbookView, radioButtonPageBreaksUsed.Checked);
        }


        #region Sample Initialization Code
        public PageBreaksSample()
        {
            InitializeComponent();
            InitializeSample();
        }

        private void InitializeSample()
        {
            DisposalManager.RegisterWorkbookViews(workbookView);
            DisposalManager.ResetWorkbookView(workbookView, false);
            Sample = new SamplesLibrary.Samples.Printing.PageBreaksSample();
            Sample.InitializeSample(workbookView);
        }
        #endregion
    }
}
